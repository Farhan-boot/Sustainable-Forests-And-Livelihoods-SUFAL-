using System.Data;
using System.Data.OleDb;

using AutoMapper.Execution;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Api.Migrations;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.GeneralSetup;


namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class SavingsAccountMigrationWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public SavingsAccountMigrationWeb(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("SavingsAccount-Migration-Web/{shouldMigrate}")]
    public async Task<IActionResult> Migrate([FromRoute] bool shouldMigrate, IFormFile excelFile)
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

            var savingsAccountDataTable = new DataTable();
            var beneficiaryDataTable = new DataTable();

            {
                var command = $"SELECT * From [AccountInformation$]";

                // Read from Excel
                using (var connection = new OleDbConnection(conString))
                {
                    using var sqlCommand = new OleDbCommand(command, connection);
                    await connection.OpenAsync();

                    using var adapter = new OleDbDataAdapter(sqlCommand);
                    adapter.Fill(savingsAccountDataTable);

                    await connection.CloseAsync();
                }
            }

            // Meetings
            var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            var savingsAccountList = new List<Common.Entity.BeneficiarySavingsAccount.SavingsAccount>();
            var skippedList = new List<ValueTuple<double, string, string>>();

            foreach (var row in savingsAccountDataTable.Rows.Cast<DataRow>().Skip(0))
            {

                var checkId = DataRowHelper.GetDoubleValue(row, "Serial No");
                if (checkId > 0)
                {
                    var savingsAccount = new Common.Entity.BeneficiarySavingsAccount.SavingsAccount();
                    savingsAccount.CreatedAt = DateTime.Now;
                    savingsAccount.CreatedBy = 3;
                    savingsAccount.IsActive = true;

                    savingsAccount.Id = DataRowHelper.GetLongValue(row, "Serial No");
                    var forest_circle = DataRowHelper.GetStringValue(row, "Forest Circle")?.Trim();
                    var forest_division = DataRowHelper.GetStringValue(row, "Forest Division")?.Trim();
                    var forest_range = DataRowHelper.GetStringValue(row, "Forest Range")?.Trim();
                    var forest_beat = DataRowHelper.GetStringValue(row, "Forest Beat")?.Trim();


                    var civil_division = DataRowHelper.GetStringValue(row, "Division")?.Trim();
                    var civil_district = DataRowHelper.GetStringValue(row, "District")?.Trim();
                    var upazilla = DataRowHelper.GetStringValue(row, "Upazilla")?.Trim();
                    var union = DataRowHelper.GetStringValue(row, "Union")?.Trim();

                    var civil_div = await _writeOnlyCtx.Set<Division>()
                        .FromSqlRaw($"select * from \"GS\".\"Division\" e where e.\"DivisionName\" ilike '%{civil_division}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(civil_division) || civil_div is null)
                    {
                        skippedList.Add((savingsAccount.Id, civil_division, $"Division '{civil_division}' is not found in DB"));
                        //continue;
                        savingsAccount.DivisionId = null;
                    }
                    else
                    {
                        savingsAccount.DivisionId = civil_div.Id;
                    }

                    var civil_dis = await _writeOnlyCtx.Set<District>()
                        .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{civil_district.Replace("'", "''")}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(civil_district) || civil_dis is null)
                    {
                        skippedList.Add((savingsAccount.Id, civil_district, $"District '{civil_district}' is not found in DB"));
                        //continue;
                        savingsAccount.DistrictId = null;
                    }
                    else
                    {
                        savingsAccount.DistrictId = civil_dis.Id;
                    }

                    var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                        .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{upazilla}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(upazilla) || civil_upazilla is null)
                    {
                        skippedList.Add((savingsAccount.Id, upazilla, $"Upazilla '{upazilla}' is not found in DB"));
                        //continue;
                        savingsAccount.UpazillaId = null;
                    }
                    else
                    {
                        savingsAccount.UpazillaId = civil_upazilla.Id;
                    }

                    var civil_union = await _writeOnlyCtx.Set<Union>()
                        .FromSqlRaw($"select * from \"GS\".\"Union\" e where e.\"Name\" ilike '%{union}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(union) || civil_union is null)
                    {
                        skippedList.Add((savingsAccount.Id, union, $"Union '{union}' is not found in DB"));
                        //continue;
                        savingsAccount.UnionId = null;
                    }
                    else
                    {
                        savingsAccount.UnionId = civil_union.Id;
                    }

                    var ngo = DataRowHelper.GetStringValue(row, "Ngo");
                    var ngo_db = await _writeOnlyCtx.Set<Ngo>()
                        .FromSqlRaw($"select * from \"BEN\".\"Ngos\" e where e.\"Name\" like '%{ngo}%'")
                        .FirstOrDefaultAsync();
                    if (ngo_db is null)
                    {
                        skippedList.Add((savingsAccount.Id, ngo, $"NGO {ngo} is not found in DB"));
                        //continue;
                        savingsAccount.NgoId = null;
                    }
                    if (ngo_db is not null)
                    {
                        savingsAccount.NgoId = ngo_db.Id;
                    }


                    var fcv_vcf = DataRowHelper.GetStringValue(row, "Forest FcvVcf")?.Trim();

                    if (string.IsNullOrEmpty(fcv_vcf) == false)
                    {
                        var circle = await _writeOnlyCtx.Set<ForestCircle>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestCircles\" e where e.\"Name\" like '%{forest_circle}%'")
                            .FirstOrDefaultAsync();
                        if (string.IsNullOrEmpty(forest_circle) || circle is null)
                        {
                            skippedList.Add((savingsAccount.Id, forest_circle, $"Forest Circle '{forest_circle}' is not found in DB"));
                            //continue;
                            savingsAccount.ForestCircleId = null;
                        }
                        else
                        {
                            savingsAccount.ForestCircleId = circle.Id;
                        }

                        var division = await _writeOnlyCtx.Set<ForestDivision>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%'")
                            .FirstOrDefaultAsync();
                        if (string.IsNullOrEmpty(forest_division) || division is null)
                        {
                            skippedList.Add((savingsAccount.Id, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                            //continue;
                            savingsAccount.ForestDivisionId = null;
                        }
                        else
                        {
                            savingsAccount.ForestDivisionId = division.Id;
                        }

                        var range = await _writeOnlyCtx.Set<ForestRange>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%'")
                            .FirstOrDefaultAsync();
                        if (string.IsNullOrEmpty(forest_range) || range is null)
                        {
                            skippedList.Add((savingsAccount.Id, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                            //continue;
                            savingsAccount.ForestRangeId = null;
                        }
                        else
                        {
                            savingsAccount.ForestRangeId = range.Id;
                        }

                        var beat = await _writeOnlyCtx.Set<ForestBeat>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%'")
                            .FirstOrDefaultAsync();
                        if (string.IsNullOrEmpty(forest_beat) || beat is null)
                        {
                            skippedList.Add((savingsAccount.Id, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                            //continue;
                            savingsAccount.ForestBeatId = null;
                        }
                        else
                        {
                            savingsAccount.ForestBeatId = beat.Id;
                        }
                        
                        var fcvVcf = await _writeOnlyCtx.Set<ForestFcvVcf>()
                            .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{fcv_vcf}%'")
                            .FirstOrDefaultAsync();
                        if (string.IsNullOrEmpty(fcv_vcf) || fcvVcf is null)
                        {
                            skippedList.Add((savingsAccount.Id, fcv_vcf, $"Forest FCV/VCF '{fcv_vcf}' is not found in DB"));
                            //continue;
                            savingsAccount.FcvId = null;
                        }
                        else
                        {
                            savingsAccount.FcvId = fcvVcf.Id;
                        }
                    }


                    var beneficiaryId = DataRowHelper.GetStringValue(row, "Beneficiary ID")?.Trim();

                    var survey = await _writeOnlyCtx.Set<Survey>()
                         .FromSqlRaw($"select * from \"BEN\".\"Surveys\" e where e.\"BeneficiaryId\" like '%{beneficiaryId}%'")
                         .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(beneficiaryId) || survey is null)
                    {
                        skippedList.Add((savingsAccount.Id, beneficiaryId, $"BeneficiaryId '{beneficiaryId}' is not found in DB"));
                        //continue;
                        savingsAccount.SurveyId = null;
                    }
                    else
                    {
                        savingsAccount.SurveyId = survey.Id;
                    }


                    var installmentAmount = DataRowHelper.GetIntValue(row, "Installment Amount");
                    savingsAccount.AmountLimit =Convert.ToDecimal(installmentAmount);

                    var accountType = DataRowHelper.GetStringValue(row, "Account Type");
                    if (accountType.Equals("Monthly"))
                    {
                        savingsAccount.AccountTypeId = 1;
                    }
                    if (accountType.Equals("Weekly"))
                    {
                        savingsAccount.AccountTypeId = 2;
                    }
                    if (accountType.Equals("Half Monthly"))
                    {
                        savingsAccount.AccountTypeId = 3;
                    }

                    //var accountOpeningDate = DataRowHelper.GetIntValue(row, "Account Opening Date");
                    //savingsAccount.UpdatedAt = Convert.ToDecimal(installmentAmount);

                    savingsAccountList.Add(savingsAccount);
                }
            }

            //#region Beneficiary
            //DataTable dtb = new DataTable();

            //var commandb = $"SELECT * From [Beneficiary$]";

            //// Read from Excel
            //using (var connection = new OleDbConnection(conString))
            //{
            //    using var sqlCommand = new OleDbCommand(commandb, connection);

            //    await connection.OpenAsync();
            //    using var adapter = new OleDbDataAdapter(sqlCommand);
            //    adapter.Fill(dtb);
            //    await connection.CloseAsync();
            //}

            //foreach (var row in dtb.Rows.Cast<DataRow>().Skip(0))
            //{
            //    var checkId = DataRowHelper.GetLongValue(row, "TrainingSerialNo");
            //    if (checkId > 0)
            //    {
            //        var p = new MeetingParticipantsMap();
            //        p.CreatedAt = DateTime.Now;
            //        p.CreatedBy = 3;
            //        p.IsActive = true;

            //        var serialNo = DataRowHelper.GetLongValue(row, "Training Serial No");
            //        var training = meetingList.Where(x => x.Id == serialNo).FirstOrDefault();
            //        if (training is null)
            //        {
            //            skippedList.Add((serialNo, "", $"Meeting id with {serialNo} not found in Beneficiary tab"));
            //            continue;
            //        }

            //        // Search Beneficiary
            //        var beneficiaryPhone = DataRowHelper.GetStringValue(row, "BeneficiaryPhone");
            //        var beneficiaryNid = DataRowHelper.GetStringValue(row, "BeneficiaryNID");
            //        var beneficiarySerialNo = DataRowHelper.GetStringValue(row, "BeneficiaryId");
            //        var beneficiaryName = DataRowHelper.GetStringValue(row, "BeneficiaryName");

            //        var survey = await _writeOnlyCtx.Set<Survey>()
            //            .FromSqlRaw($"SELECT * FROM \"BEN\".\"Surveys\" s WHERE s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiarySerialNo}' AND s.\"BeneficiaryNid\" LIKE '%{beneficiaryNid}%' OR s.\"BeneficiaryPhone\" LIKE '%{beneficiaryPhone}%' OR s.\"BeneficiaryPhoneBn\" LIKE '%{beneficiaryPhone}%' OR s.\"BeneficiaryName\" LIKE '%{beneficiaryName}%' ORDER BY CASE WHEN s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiarySerialNo}' THEN 1 WHEN s.\"BeneficiaryNid\" LIKE '%{beneficiaryNid}%' THEN 2 ELSE 3 END")
            //            .FirstOrDefaultAsync();
            //        if (survey is null)
            //        {
            //            skippedList.Add((serialNo, beneficiaryNid, "Beneficiary nid is not found in DB"));
            //            continue;
            //        }
            //        p.SurveyId = survey?.Id;
            //        p.ParticipentType = Common.Enum.Capacity.ParticipentType.Beneficiary;

            //        if (training.MeetingParticipantsMaps is null)
            //        {
            //            training.MeetingParticipantsMaps = new List<MeetingParticipantsMap>();
            //        }
            //        training.MeetingParticipantsMaps.Add(p);
            //    }
            //}
            //#endregion

            foreach (var item in savingsAccountList)
            {
                item.Id = 0;
            }

            if (shouldMigrate)
            {
                _writeOnlyCtx.Set<Common.Entity.BeneficiarySavingsAccount.SavingsAccount>().AddRange(savingsAccountList);
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            var skippedSavingsAccountListJsonFormat = skippedList
                .Select(x => new
                {
                    SerialNo = x.Item1,
                    Value = x.Item2,
                    Message = x.Item3
                })
                .DistinctBy(x => x.Value)
                .ToList();

            if (skippedSavingsAccountListJsonFormat.Count > 0)
            {
                return Ok(skippedSavingsAccountListJsonFormat);
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
        catch (OleDbException ex)
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
