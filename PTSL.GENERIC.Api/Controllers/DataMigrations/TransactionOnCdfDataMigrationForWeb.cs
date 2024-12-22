using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class TransactionOnCdfDataMigrationForWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public TransactionOnCdfDataMigrationForWeb(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("TransactionOnCdf-list-for-web/{shouldMigrate}")]
    public async Task<IActionResult> TransactionOnCdfList([FromRoute] bool shouldMigrate, IFormFile excelFile)
    {
        try
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await excelFile.CopyToAsync(stream);
            }

            var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

            DataTable dt = new DataTable();

            var command = $"SELECT * From [TransactionOnCdfList$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using (var sqlCommand = new OleDbCommand(command, connection))
                {
                    await connection.OpenAsync();
                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(dt);
                    await connection.CloseAsync();
                }
            }

            // Save to SQL SERVER
            var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
            var TransactionOnCdfList = new List<Transaction>();
            var skippedList = new List<ValueTuple<double, string, string>>();
           
            foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
            {
                var TransactionOnCdf = new Transaction();
                var checkId = DataRowHelper.GetLongValue(row, "Serial No");
                if (checkId > 0)
                {
                   
                    TransactionOnCdf.CreatedAt = DateTime.Now;
                    TransactionOnCdf.CreatedBy = 3;
                    TransactionOnCdf.IsActive = true;

                    var sl = DataRowHelper.GetIntValue(row, "Serial No");
                    var forest_circle = row.Field<string>("ForestCircle")?.Trim();
                    var forest_division = row.Field<string>("ForestDivision")?.Trim();
                    var fund_type = row.Field<string>("FundType")?.Trim();
                    var financial_year = row.Field<string>("FinancialYear")?.Trim();
                    var from_date = row.Field<string>("FromDate")?.Trim();
                    var to_date = row.Field<string>("ToDate")?.Trim();
                    var account = row.Field<string>("Account")?.Trim();
                    var month = row.Field<string>("Month")?.Trim();
                    var forest_range = row.Field<string>("ForestRange")?.Trim();
                    var forest_beat = row.Field<string>("ForestBeat")?.Trim();
                    var forest_FcvVcf = row.Field<string>("ForestFcvVcf")?.Trim();
                    var year = row.Field<string>("Year")?.Trim();


                    if (string.IsNullOrEmpty(forest_FcvVcf) == false)
                    {
                        var circle = await _writeOnlyCtx.Set<ForestCircle>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestCircles\" e where e.\"Name\" like '%{forest_circle}%'")
                            .FirstOrDefaultAsync();
                        if (circle is null)
                        {
                            skippedList.Add((sl, forest_circle, $"Forest Circle '{forest_circle}' is not found in DB"));
                            continue;
                        }

                        var division = await _writeOnlyCtx.Set<ForestDivision>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%' and e.\"ForestCircleId\" = {circle?.Id ?? -1}")
                            .FirstOrDefaultAsync();
                        if (division is null)
                        {
                            skippedList.Add((sl, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                            continue;
                        }

                        var range = await _writeOnlyCtx.Set<ForestRange>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%' and e.\"ForestDivisionId\" = {division?.Id ?? -1}")
                            .FirstOrDefaultAsync();
                        if (range is null)
                        {
                            skippedList.Add((sl, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                            continue;
                        }

                        var beat = await _writeOnlyCtx.Set<ForestBeat>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%' and e.\"ForestRangeId\" = {range?.Id ?? -1}")
                            .FirstOrDefaultAsync();
                        if (beat is null)
                        {
                            skippedList.Add((sl, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                            continue;
                        }

                        var fcvVcf = await _writeOnlyCtx.Set<ForestFcvVcf>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{forest_FcvVcf}%' and e.\"ForestBeatId\" = {beat?.Id ?? -1}")
                            .FirstOrDefaultAsync();
                        if (fcvVcf is null)
                        {
                            skippedList.Add((sl, forest_FcvVcf, $"Forest FCV/VCF '{forest_FcvVcf}' is not found in DB"));
                            continue;
                        }

                        //Other
                        var fundType = await _writeOnlyCtx.Set<FundType>()
                         .FirstOrDefaultAsync(x => x.Name.Equals(fund_type));
                        if (fundType is null)
                        {
                            skippedList.Add((sl, fund_type, $"Fund Type '{fund_type}' is not found in DB"));
                            continue;
                        }

                        var financialYear = await _writeOnlyCtx.Set<FinancialYear>()
                         .FromSqlRaw($"select * from \"GS\".\"FinancialYears\" e where e.\"Name\" like '%{financial_year}%'")
                         .FirstOrDefaultAsync();
                        if (financialYear is null)
                        {
                            skippedList.Add((sl, financial_year, $"Financial Year '{financial_year}' is not found in DB"));
                            continue;
                        }

                        var accounts = await _writeOnlyCtx.Set<Account>()
                       .FromSqlRaw($"select * from \"AccountManagement\".\"Accounts\" e where e.\"AccountNumber\" like '%{account}%'")
                       .FirstOrDefaultAsync();
                        if (accounts is null)
                        {
                            skippedList.Add((sl, account, $"Accounts '{account}' is not found in DB"));
                            continue;
                        }

                        TransactionOnCdf.ForestCircleId = division.ForestCircleId;
                        TransactionOnCdf.ForestDivisionId = range.ForestDivisionId;
                        TransactionOnCdf.ForestRangeId = range?.Id;
                        TransactionOnCdf.ForestBeatId = beat?.Id;
                        TransactionOnCdf.ForestFcvVcfId = fcvVcf?.Id;
                        //Other fild
                        TransactionOnCdf.FundTypeId = fundType.Id;
                        TransactionOnCdf.FinancialYearId = financialYear.Id;
                        TransactionOnCdf.FromDate = Convert.ToDateTime(from_date);
                        TransactionOnCdf.ToDate = Convert.ToDateTime(to_date);
                        TransactionOnCdf.AccountId = accounts.Id;
                        TransactionOnCdf.ExpenseYear = year;

                        if (month.Equals("January", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.January;
                        }
                        if (month.Equals("February", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.February;
                        }
                        if (month.Equals("March", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.March;
                        }
                        if (month.Equals("April", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.April;
                        }
                        if (month.Equals("May", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.May;
                        }
                        if (month.Equals("June", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.June;
                        }
                        if (month.Equals("July", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.July;
                        }
                        if (month.Equals("August", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.August;
                        }
                        if (month.Equals("September", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.September;
                        }
                        if (month.Equals("October", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.October;
                        }
                        if (month.Equals("November", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.November;
                        }
                        if (month.Equals("December", StringComparison.InvariantCultureIgnoreCase))
                        {
                            TransactionOnCdf.ExpenseMonth = Months.December;
                        }

                        //TransactionOnCdf.ExpenseMonth = Enum.Parse(typeof(PTSL.GENERIC.Common.Enum.Months), 1);
                        //if (TransactionOnCdf.ForestCircleId is null && TransactionOnCdf.ForestDivisionId is null && TransactionOnCdf.ForestRangeId is null && TransactionOnCdf.ForestBeatId is null && TransactionOnCdf.ForestFcvVcfId is null)
                        //{
                        //    continue;
                        //}
                    }
                    #region ExpenseDetailsForCDFs
                    DataTable dtb = new DataTable();
                     

                    var commandb = $"SELECT * From [ExpenseDetailsForCDF$]";

                    // Read from Excel
                    using (var connection = new OleDbConnection(conString))
                    {
                        using var sqlCommand = new OleDbCommand(commandb, connection);

                        await connection.OpenAsync();
                        using var adapter = new OleDbDataAdapter(sqlCommand);
                        adapter.Fill(dtb);
                        await connection.CloseAsync();
                    }

                    foreach (var row1 in dtb.Rows.Cast<DataRow>().Skip(0))
                    {
                        var checkId1 = DataRowHelper.GetLongValue(row1, "TransactionOnCdfSerialNo");
                        if (checkId1 > 0 && checkId1 == checkId)
                        {
                            var p = new ExpenseDetailsForCDF();
                            p.CreatedAt = DateTime.Now;
                            p.CreatedBy = 3;
                            p.IsActive = true;

                            var serialNo = DataRowHelper.GetLongValue(row1, "TransactionOnCdfSerialNo");
                            var expense_scheme = DataRowHelper.GetStringValue(row1, "ExpenseScheme");
                            var amount = DataRowHelper.GetStringValue(row1, "Amount");
                            var date = DataRowHelper.GetStringValue(row1, "Date");
                            var remarks = DataRowHelper.GetStringValue(row1, "Remarks");


                            p.TransactionId = serialNo;
                            p.ExpenseScheme = expense_scheme;
                            p.ExpenseAmount = Convert.ToDouble(amount);
                            p.ExpenseDate = Convert.ToDateTime(date);
                            p.Remarks = remarks;

                            TransactionOnCdf?.ExpenseDetailsForCDFs?.Add(p);

                        }

                    }
                    #endregion
                    TransactionOnCdfList.Add(TransactionOnCdf);
                }

            }

          



            if (shouldMigrate)
            {
                await _writeOnlyCtx.Set<Transaction>().AddRangeAsync(TransactionOnCdfList);
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            var skippedListJsonFormat = skippedList
                .Select(x => new
                {
                    SerialNo = x.Item1,
                    Value = x.Item2,
                    Message = x.Item3
                })
                .DistinctBy(x => x.Value)
                .ToList();

            if (skippedListJsonFormat.Count > 0)
            {
                return Ok(skippedListJsonFormat);
            }

            return Ok(new List<object>()
            {
                new
                {
                    SerialNo = 0,
                    Value = "",
                    Message = "All ok"
                },
            });
        }
        catch (Exception ex)
        {
            return Ok(new List<object>()
            {
                new
                {
                    SerialNo = 0,
                    Value = "",
                    Message = ex.Message
                },
            });
        }
    }
}

