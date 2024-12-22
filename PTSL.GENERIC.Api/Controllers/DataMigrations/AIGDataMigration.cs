using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class AIGDataMigration : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public AIGDataMigration(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("AIG-Data-Migration")]
    public async Task<IActionResult> Migrate(string filePath, bool shouldMigrate)
    {
        var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

        var dt = new DataTable();

        var command = $"SELECT * From [AIG$]";

        // Read from Excel
        using (var connection = new OleDbConnection(conString))
        {
            using var sqlCommand = new OleDbCommand(command, connection);
            await connection.OpenAsync();

            using var adapter = new OleDbDataAdapter(sqlCommand);
            adapter.Fill(dt);

            await connection.CloseAsync();
        }

        // Save to SQL SERVER
        var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
        var aigList = new List<AIGBasicInformation>();
        var skippedList = new List<ValueTuple<double, string, string>>();
        foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
        {
            var aig = new AIGBasicInformation();
            aig.CreatedAt = DateTime.Now;
            aig.CreatedBy = 3;
            aig.IsActive = true;

            var sl = row.Field<double>("Serial No");
            var forest_circle = row.Field<string>("Forest Circle").Trim();
            var forest_division = row.Field<string>("Forest Division").Trim();
            var forest_range = row.Field<string>("Forest Range").Trim();
            var forest_beat = row.Field<string>("Forest Beat").Trim();
            var fcv_vcf = row.Field<string>("Forest FCV/VCF").Trim();

            if (string.IsNullOrEmpty(fcv_vcf) == false)
            {
                var circle = await _writeOnlyCtx.Set<ForestCircle>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestCircles\" e where e.\"Name\" like '%{forest_circle}%'")
                    .FirstOrDefaultAsync();
                if (circle is null)
                {
                    skippedList.Add((sl, forest_circle, $"Forest Circle '{forest_circle}' is not found in DB"));
                    //continue;
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
                    .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{fcv_vcf}%' and e.\"ForestBeatId\" = {beat?.Id ?? -1}")
                    .FirstOrDefaultAsync();
                if (fcvVcf is null)
                {
                    skippedList.Add((sl, fcv_vcf, $"Forest FCV/VCF '{fcv_vcf}' is not found in DB"));
                    continue;
                }

                aig.ForestCircleId = division.ForestCircleId;
                aig.ForestDivisionId = range.ForestDivisionId;
                aig.ForestRangeId = range.Id;
                aig.ForestBeatId = beat.Id;
                aig.ForestFcvVcfId = fcvVcf.Id;

                if (aig?.ForestCircleId is null && aig?.ForestDivisionId is null && aig?.ForestRangeId is null && aig?.ForestBeatId is null && aig?.ForestFcvVcfId is null)
                {
                    continue;
                }
            }

            var civil_division = row.Field<string>("Division").Trim();
            var civil_district = row.Field<string>("District").Trim();
            var upazilla = row.Field<string>("Upazilla").Trim();
            var union = row.Field<string>("Union").Trim();

            if (string.IsNullOrEmpty(union) == false)
            {
                var civil_div = await _writeOnlyCtx.Set<Division>()
                    .FromSqlRaw($"select * from \"GS\".\"Division\" e where e.\"DivisionName\" ilike '%{civil_division}%'")
                    .FirstOrDefaultAsync();
                if (civil_div is null)
                {
                    skippedList.Add((sl, civil_division, $"Division '{civil_division}' is not found in DB"));
                    continue;
                }

                var civil_dis = await _writeOnlyCtx.Set<District>()
                    .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{civil_district}%'")
                    .FirstOrDefaultAsync();
                if (civil_dis is null)
                {
                    skippedList.Add((sl, civil_district, $"District '{civil_district}' is not found in DB"));
                    continue;
                }

                var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                    .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{upazilla}%'")
                    .FirstOrDefaultAsync();
                if (civil_upazilla is null)
                {
                    skippedList.Add((sl, upazilla, $"Upazilla '{upazilla}' is not found in DB"));
                    //continue;
                }

                var civil_union = await _writeOnlyCtx.Set<Union>()
                    .FromSqlRaw($"select * from \"GS\".\"Union\" e where e.\"Name\" ilike '%{union}%'")
                    .FirstOrDefaultAsync();

                /*
                if (civil_union is null && civil_upazilla is not null)
                {
                    var new_union = new Union
                    {
                        Name = union,
                        NameBn = union,
                        UpazillaId = civil_upazilla.Id
                    };
                    _writeOnlyCtx.Set<Union>().Add(new_union);
                    await _writeOnlyCtx.SaveChangesAsync();

                    civil_union = new_union;
                }
                */

                if (civil_div is not null)
                {
                    aig.DivisionId = civil_div.Id;
                }

                if (civil_dis is not null)
                {
                    aig.DistrictId = civil_dis.Id;
                }

                if (civil_upazilla is not null)
                {
                    aig.UpazillaId = civil_upazilla.Id;
                }
                
                if (civil_union is not null)
                {
                    aig.UnionId = civil_union.Id;
                }
            }

            var ngo = DataRowHelper.GetStringValue(row, "Ngo");
            var ngo_db = await _writeOnlyCtx.Set<Ngo>()
                .FromSql($"select * from \"BEN\".\"Ngos\" e where e.\"Name\" like '%{ngo}%'")
                .FirstOrDefaultAsync();
            if (ngo_db is null)
            {
                if (ngo_db is null)
                {
                    skippedList.Add((sl, ngo, "NGO is not found in DB"));
                    continue;
                }

                aig.NgoId = ngo_db.Id;
            }

            var totalLoanAmount = DataRowHelper.GetDoubleValue(row, "Total Loan Amount");
            aig.TotalAllocatedLoanAmount = totalLoanAmount;
            aig.MaximumRepaymentMonth = DataRowHelper.GetIntValue(row, "Total Repayment Month");

            var serviceCharge = DataRowHelper.GetStringValue(row, "Service Charge Percentage");
            serviceCharge = serviceCharge.Replace("%", "");
            _ = double.TryParse(serviceCharge, out var serviceChargePercentage);
            aig.ServiceChargePercentage = serviceChargePercentage;

            var securityCharge = DataRowHelper.GetStringValue(row, "Security Charge Percentage");
            securityCharge = securityCharge.Replace("%", "");
            _ = double.TryParse(securityCharge, out var securityChargePercentage);
            aig.SecurityChargePercentage = securityChargePercentage;

            aig.StartDate = DataRowHelper.GetDateTimeValue(row, "StartDate") ?? DateTime.MinValue;
            aig.EndDate = DataRowHelper.GetDateTimeValue(row, "EndDate") ?? DateTime.MinValue;
            aig.IsRecievedTrainingInTrade = true;

            // TODO: LDF Count, Beneficiary
            var beneficiarySerialNo = DataRowHelper.GetStringValue(row, "Beneficiary Household Serial No");
            var beneficiaryName = DataRowHelper.GetStringValue(row, "Beneficiary Name");
            var beneficiaryNid = DataRowHelper.GetStringValue(row, "Beneficiary Nid");
            var beneficiaryPhone = DataRowHelper.GetStringValue(row, "Beneficiary Phone");

            var survey = await _writeOnlyCtx.Set<Survey>()
                .FromSqlRaw($"SELECT * FROM \"BEN\".\"Surveys\" s WHERE s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiarySerialNo}' AND s.\"BeneficiaryNid\" LIKE '%{beneficiaryNid}%' OR s.\"BeneficiaryPhone\" LIKE '%{beneficiaryPhone}%' OR s.\"BeneficiaryPhoneBn\" LIKE '%{beneficiaryPhone}%' OR s.\"BeneficiaryName\" LIKE '%{beneficiaryName}%' ORDER BY CASE WHEN s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiarySerialNo}' THEN 1 WHEN s.\"BeneficiaryNid\" LIKE '%{beneficiaryNid}%' THEN 2 ELSE 3 END")
                .FirstOrDefaultAsync();
            if (survey is null)
            {
                skippedList.Add((sl, beneficiaryNid, "Beneficiary nid is not found in DB"));
                continue;
            }

            var sixtyPercentage = DataRowHelper.GetDoubleValue(row, "Amount For 60%");
            if (sixtyPercentage > 0)
            {
                aig.FirstSixtyPercentageLDF = new FirstSixtyPercentageLDF
                {
                    LDFAmount = sixtyPercentage,
                    GraceMonth = DataRowHelper.GetIntValue(row, "Total Grace Month For 60%"),
                    DisbursementDate = aig.StartDate,
                    ServiceChargePercentage = serviceChargePercentage,
                    SecurityChargePercentage = securityChargePercentage,
                    IsAgreeToInvestInOwnIncomeActivities = true,
                    ShallAdhereTheCOM = true,
                    IsAttendedEightyPercentageOfMeetings = true,
                    IsFirstInstallmentIsCertifiedBySocialAuditCommittee = true,
                    HasBankAccountInHisOwnName = true,
                    IsPayingRegularIncomingInstallments = true,
                    IsAgreedToKeepIncomeAndExpenditureFund = true,
                };

                aig.FirstSixtyPercentageLDF
                    .SetServiceCharge()
                    .SetSecurityCharge();
            }

            var fortyPercentage = DataRowHelper.GetDoubleValue(row, "Amount For 40%");
            if (fortyPercentage > 0)
            {
                aig.SecondFourtyPercentageLDF = new SecondFourtyPercentageLDF
                {
                    LDFAmount = fortyPercentage,
                    ServiceChargePercentage = serviceChargePercentage,
                    SecurityChargePercentage = securityChargePercentage,
                    DisbursementDate = DateTime.MinValue,
                    HasInvestedSeventyPercentageOfTheLoan = true,
                    IsPaidTheLoanInstallmentThreeConsecutiveMonths = true,
                    IsAttendedRegularMeetings = true,
                    DidNotBreakTheTenPrinciples = true,
                    IsLivelihoodDevelopmentFundCertifiedAndApproved = true,
                    IncomeExpenditureFundLoansUpdatedAndCertified = true,
                };

                aig.SecondFourtyPercentageLDF
                    .SetServiceCharge()
                    .SetSecurityCharge();
            }

            aigList.Add(aig);
        }

        if (shouldMigrate)
        {
            await _writeOnlyCtx.Set<AIGBasicInformation>().AddRangeAsync(aigList);
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

        await System.IO.File.WriteAllTextAsync($"D:\\sufl_assets\\_Data_\\NGO_ESDO_Mymensingh New\\Migrating\\{Path.GetFileName(filePath)}.json", System.Text.Json.JsonSerializer.Serialize(skippedListJsonFormat, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true,
        }));

        return Ok($"Completed. Skipped: {skippedList.Count}");
    }

    /*
    [HttpPost("AIG-Beneficiary-Data-Mismatch")]
    public async Task<IActionResult> DataMismatch(string filePath)
    {
        var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

        var dt = new DataTable();

        var command = $"SELECT * From [AIG$]";

        // Read from Excel
        using (var connection = new OleDbConnection(conString))
        {
            using var sqlCommand = new OleDbCommand(command, connection);
            await connection.OpenAsync();

            using var adapter = new OleDbDataAdapter(sqlCommand);
            adapter.Fill(dt);

            await connection.CloseAsync();
        }

        // Save to SQL SERVER
        var skippedList = new List<AigNidError>();

        foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
        {
            var aig = new AigNid();

            aig.SL = DataRowHelper.GetLongValue(row, "Serial No");
            aig.Nid = DataRowHelper.GetStringValue(row, "Beneficiary Nid");

            var nid = await _writeOnlyCtx.Set<Survey>()
                .FromSqlRaw($"select * from \"BEN\".\"Surveys\" s where lower(s.\"BeneficiaryNid\") like '%{aig.Nid}%'")
                .FirstOrDefaultAsync();
            if (nid is null)
            {
                skippedList.Add(new AigNidError
                {
                    SL = aig.SL,
                    Nid = aig.Nid,
                    ErrorReason = "Nid not found",
                });
            }
        }

        await System.IO.File.WriteAllTextAsync("D:\\sufl_assets\\_Data_\\Mymensingh\\AIG\\problem-aig.txt", System.Text.Json.JsonSerializer.Serialize(skippedList, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true,
        }));

        return Ok($"Completed. Skipped: {skippedList.Count}");
    }
    */
}

public class AigNid
{
    public long SL { get; set; }
    public string Nid { get; set; }
}

public class AigNidError : AigNid
{
    public string ErrorReason { get; set; }
}
