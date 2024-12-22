using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class CommitteeMigration : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CommitteeMigration(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("committee-data-migration")]
    public async Task<IActionResult> Migrate(string filePath)
    {
        var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

        var dt = new DataTable();

        var command = $"SELECT * From [Committee$]";

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
        var committeeManagementList = new List<CommitteeManagement>();
        var skippedList = new List<ValueTuple<double, string, string>>();
        foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
        {
            var cm = new CommitteeManagement();
            cm.CreatedAt = DateTime.Now;
            cm.CreatedBy = 3;
            cm.IsActive = true;

            var sl = row.Field<double>("Sl");
            var forest_circle = DataRowHelper.GetStringValue(row, "ForestCircle");
            var forest_division = DataRowHelper.GetStringValue(row, "ForestDivision");
            var forest_range = DataRowHelper.GetStringValue(row, "ForestRange");
            var forest_beat = DataRowHelper.GetStringValue(row, "ForestBeat");
            var fcv_vcf = DataRowHelper.GetStringValue(row, "ForestFCV/VCF");


            long forestCircleLongId = 0;
            long forestDivisionLongId = 0;
            long forestRangeLongId = 0;
            long forestBeatLongId = 0;
            long forestFcvVcfLongId = 0;

            if (string.IsNullOrEmpty(fcv_vcf) == false)
            {
                var circle = await _writeOnlyCtx.Set<ForestCircle>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestCircles\" e where e.\"Name\" like '%{forest_circle}%'")
                    .FirstOrDefaultAsync();
                if (circle is null)
                {
                    skippedList.Add((sl, forest_circle, $"Forest Circle '{forest_circle}' is not found in DB"));
                    continue;
                }
                forestCircleLongId = circle.Id;

                var division = await _writeOnlyCtx.Set<ForestDivision>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%'")
                    .FirstOrDefaultAsync();
                if (division is null)
                {
                    skippedList.Add((sl, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                    continue;
                }
                forestDivisionLongId = division.Id;

                var range = await _writeOnlyCtx.Set<ForestRange>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%'")
                    .FirstOrDefaultAsync();
                if (range is null)
                {
                    skippedList.Add((sl, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                    continue;
                }
                forestRangeLongId = range.Id;

                var beat = await _writeOnlyCtx.Set<ForestBeat>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%'")
                    .FirstOrDefaultAsync();
                if (beat is null)
                {
                    skippedList.Add((sl, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                    continue;
                }
                forestBeatLongId = beat.Id;

                var fcvVcf = await _writeOnlyCtx.Set<ForestFcvVcf>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{fcv_vcf}%'")
                    .FirstOrDefaultAsync();
                if (fcvVcf is null)
                {
                    skippedList.Add((sl, fcv_vcf, $"Forest FCV/VCF '{fcv_vcf}' is not found in DB"));
                    continue;
                }
                forestFcvVcfLongId = fcvVcf.Id;

                cm.ForestCircleId = circle.Id;
                cm.ForestDivisionId = division.Id;
                cm.ForestRangeId = range.Id;
                cm.ForestBeatId = beat.Id;
                cm.ForestFcvVcfId = fcvVcf.Id;
            }

            var civil_division = row.Field<string>("Division")?.Trim();
            var civil_district = row.Field<string>("District")?.Trim();
            var upazilla = row.Field<string>("Upazilla")?.Trim();
            var union = row.Field<string>("Union")?.Trim();

            long civilDivisionLongId = 0;
            long civilDistrictLongId = 0;
            long civilUpazillaLongId = 0;
            long civilUnionLongId = 0;

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
                civilDivisionLongId = civil_div.Id;

                var civil_dis = await _writeOnlyCtx.Set<District>()
                    .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{civil_district}%' and e.\"DivisionId\" = {civil_div.Id}")
                    .FirstOrDefaultAsync();
                if (civil_dis is null)
                {
                    skippedList.Add((sl, civil_district, $"District '{civil_district}' is not found in DB"));
                    continue;
                }
                civilDistrictLongId = civil_dis.Id;

                var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                    .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{upazilla}%' and e.\"DistrictId\" = {civil_dis.Id}")
                    .FirstOrDefaultAsync();
                if (civil_upazilla is null)
                {
                    skippedList.Add((sl, upazilla, $"Upazilla '{upazilla}' is not found in DB"));
                    continue;
                }
                civilUpazillaLongId = civil_upazilla.Id;

                var civil_union = await _writeOnlyCtx.Set<Union>()
                    .FromSqlRaw($"select * from \"GS\".\"Union\" e where e.\"Name\" ilike '%{union}%' and e.\"UpazillaId\" = {civil_upazilla.Id}")
                    .FirstOrDefaultAsync();

                if (civil_union is null)
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

                cm.DivisionId = civil_div.Id;
                cm.DistrictId = civil_dis.Id;
                cm.UpazillaId = civil_upazilla.Id;
                cm.UnionId = civil_union.Id;
                civilUnionLongId = civil_union.Id;
            }

            cm.NgoId = 3;
            long committeeDesignationId = 0;

            var committeeTypeId = DataRowHelper.GetStringValue(row, "Committee Type");
            if (committeeTypeId.EndsWith("-EC") || committeeTypeId.Equals("CFMC"))
            {
                cm.CommitteeTypeConfigurationId = 1;

                var executive_committee_designation_string = DataRowHelper.GetStringValue(row, "Executive Committee Designation")?.Trim();
                var executive_committee_designation = await _writeOnlyCtx.Set<CommitteeDesignationsConfiguration>()
                    .Where(x => x.CommitteesConfiguration.CommitteeName == committeeTypeId)
                    .Where(x => x.DesignationName == executive_committee_designation_string)
                    .FirstOrDefaultAsync();

                if (executive_committee_designation is null)
                {
                    if (executive_committee_designation is null)
                    {
                        skippedList.Add((sl, executive_committee_designation_string, "Executive Committee not found in DB"));
                        continue;
                    }
                }

                cm.CommitteeDesignationsConfigurationId = executive_committee_designation.Id;
                committeeDesignationId = executive_committee_designation.Id;
            }
            else
            {
                cm.CommitteeTypeConfigurationId = 2;

                var sub_committee_designation_string = DataRowHelper.GetStringValue(row, "Sub Committee Designation")?.Trim();
                var sub_committee_designation = await _writeOnlyCtx.Set<CommitteeDesignationsConfiguration>()
                    .Where(x => x.CommitteesConfiguration.CommitteeName == committeeTypeId)
                    .Where(x => x.DesignationName == sub_committee_designation_string)
                    .FirstOrDefaultAsync();

                if (sub_committee_designation is null)
                {
                    if (sub_committee_designation is null)
                    {
                        skippedList.Add((sl, sub_committee_designation_string, "Sub Committee not found in DB"));
                        continue;
                    }
                }

                cm.CommitteeDesignationsConfigurationId = sub_committee_designation.Id;
                committeeDesignationId = sub_committee_designation.Id;
            }

            var nid = DataRowHelper.GetStringValue(row, "NID")?.Trim();
            var mobileNo = DataRowHelper.GetStringValue(row, "Mobile No")?.Trim();
            var fatherSpouseName = DataRowHelper.GetStringValue(row, "Father / Spouse Name")?.Trim();
            var gender = DataRowHelper.GetStringValue(row, "Gender")?.Trim() == "Male" ? Gender.Male : Gender.Female;
            var address = DataRowHelper.GetStringValue(row, "Address")?.Trim();
            var name = DataRowHelper.GetStringValue(row, "Name")?.Trim();

            if (cm.CommitteeManagementMembers is null)
            {
                cm.CommitteeManagementMembers = new List<CommitteeManagementMember>();
            }

            var beneficiaryHouseholdId = DataRowHelper.GetLongValue(row, "Beneficiary ID");
            if (beneficiaryHouseholdId == default)
            {
                cm.CommitteeManagementMembers.Add(new CommitteeManagementMember
                {
                    CommitteeDesignationsConfigurationId = committeeDesignationId,
                    OtherCommitteeMember = new OtherCommitteeMember
                    {
                        Address = address,
                        NID = nid,
                        FatherOrSpouse = fatherSpouseName,
                        FullName = name,
                        Gender = gender,
                        ForestCircleId = forestCircleLongId,
                        ForestDivisionId = forestDivisionLongId,
                        ForestBeatId = forestBeatLongId,
                        ForestRangeId = forestRangeLongId,
                        ForestFcvVcfId = forestFcvVcfLongId,
                        DistrictId = civilDistrictLongId,
                        DivisionId = civilDivisionLongId,
                        UpazillaId = civilUpazillaLongId,
                        UnionId = civilUnionLongId,
                        PhoneNumber = mobileNo ?? string.Empty
                    }
                });
            }
            else
            {
                var survey = await _writeOnlyCtx.Set<Survey>()
                    .FromSqlRaw($"SELECT * FROM \"BEN\".\"Surveys\" s WHERE s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiaryHouseholdId}' AND s.\"BeneficiaryNid\" LIKE '%{nid}%' OR s.\"BeneficiaryPhone\" LIKE '%{mobileNo}%' OR s.\"BeneficiaryPhoneBn\" LIKE '%{mobileNo}%' ORDER BY CASE WHEN s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiaryHouseholdId}' THEN 1 WHEN s.\"BeneficiaryNid\" LIKE '%{nid}%' THEN 2 ELSE 3 END")
                    .FirstOrDefaultAsync();
                if (survey is null)
                {
                    skippedList.Add((sl, nid, $"Beneficiary NID \'{nid}\' and FCV/VCF \'{fcv_vcf}\' is not found in DB"));
                }
                else
                {
                    cm.CommitteeManagementMembers.Add(new CommitteeManagementMember
                    {
                        CommitteeDesignationsConfigurationId = committeeDesignationId,
                        SurveyId = survey.Id,
                    });
                }
            }

            committeeManagementList.Add(cm);
        }

        await _writeOnlyCtx.Set<CommitteeManagement>().AddRangeAsync(committeeManagementList);
        await _writeOnlyCtx.SaveChangesAsync();
        await transaction.CommitAsync();

        var skippedListJsonFormat = skippedList
            .Select(x => new
            {
                SerialNo = x.Item1,
                Value = x.Item2,
                Message = x.Item3
            })
            .DistinctBy(x => x.Value)
            .ToList();

        await System.IO.File.WriteAllTextAsync("D:\\sufl_assets\\_Data_\\Mymensingh\\Committee\\problem-committee.txt", System.Text.Json.JsonSerializer.Serialize(skippedListJsonFormat, new JsonSerializerOptions
        {
            WriteIndented = true
        }));

        return Ok($"Completed. Skipped: {string.Join(',', skippedList.Select(x => x.ToString()))}");
    }
}
