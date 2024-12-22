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

public class CommitteeMigrationV2 : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CommitteeMigrationV2(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("committee-data-migration-v2")]
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
        var defaultDesignationId = 0;

        foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
        {
            var cm = new CommitteeManagement();
            cm.CreatedAt = DateTime.Now;
            cm.CreatedBy = 3;
            cm.IsActive = true;

            var sl = DataRowHelper.GetDoubleValue(row, "Sl");
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
                    .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%' and e.\"ForestCircleId\" = {circle?.Id ?? -1}")
                    .FirstOrDefaultAsync();
                if (division is null)
                {
                    skippedList.Add((sl, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                    continue;
                }
                forestDivisionLongId = division.Id;

                var range = await _writeOnlyCtx.Set<ForestRange>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%' and e.\"ForestDivisionId\" = {division?.Id ?? -1}")
                    .FirstOrDefaultAsync();
                if (range is null)
                {
                    skippedList.Add((sl, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                    continue;
                }
                forestRangeLongId = range.Id;

                var beat = await _writeOnlyCtx.Set<ForestBeat>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%' and e.\"ForestRangeId\" = {range?.Id ?? -1}")
                    .FirstOrDefaultAsync();
                if (beat is null)
                {
                    skippedList.Add((sl, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                    continue;
                }
                forestBeatLongId = beat.Id;

                var fcvVcf = await _writeOnlyCtx.Set<ForestFcvVcf>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{fcv_vcf}%' and e.\"ForestBeatId\" = {beat?.Id ?? -1}")
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

                if (cm.ForestCircleId == default && cm.ForestDivisionId == default && cm.ForestRangeId == default && cm.ForestBeatId == default && cm.ForestFcvVcfId == default)
                {
                    continue;
                }
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
            /*
            var committeeTypeId = DataRowHelper.GetStringValue(row, "Committee Type")?.Trim();

            if (string.IsNullOrEmpty(committeeTypeId) == false)
            {
                var committeeType = await _writeOnlyCtx.Set<CommitteeTypeConfiguration>()
                    .Where(x => x.CommitteeTypeName.Equals(committeeTypeId))
                    .FirstOrDefaultAsync();

                if (committeeType is null)
                {
                    skippedList.Add((sl, committeeTypeId, $"Committee Type '{committeeTypeId}' is not found in DB"));
                    continue;
                }
            }
            else
            {

            }
            */

            long _designationId = 0;
            long _committeeTypeId = 0;


            var committeeTypeString = DataRowHelper.GetStringValue(row, "Committee Type")?.Trim();
            if (string.IsNullOrEmpty(committeeTypeString))
            {
                skippedList.Add((sl, committeeTypeString, $"Committee Type '{committeeTypeString}' can not be empty"));
                continue;
            }
            else
            {
                var committeeType = await _writeOnlyCtx.Set<CommitteeTypeConfiguration>().Where(x => x.CommitteeTypeName.Equals(committeeTypeString)).FirstOrDefaultAsync();
                if (committeeType is null)
                {
                    skippedList.Add((sl, committeeTypeString, $"Committee Type '{committeeTypeString}' is not found in DB"));
                    continue;
                }

                cm.CommitteeTypeConfigurationId = committeeType.Id;
                _committeeTypeId = committeeType.Id;
            }

            var committeeName = DataRowHelper.GetStringValue(row, "Committee Name")?.Trim();
            if (string.IsNullOrEmpty(committeeName))
            {
                skippedList.Add((sl, committeeName, $"Committee Name '{committeeName}' can not be empty"));
                continue;
            }
            else
            {
                var committeeNameEntity = await _writeOnlyCtx.Set<CommitteesConfiguration>()
                    .Where(x => x.CommitteeName.Equals(committeeName))
                    .Where(x => x.CommitteeTypeConfigurationId == _committeeTypeId)
                    .FirstOrDefaultAsync();
                if (committeeNameEntity is null)
                {
                    skippedList.Add((sl, committeeName, $"Committee Name '{committeeName}' is not found in DB"));
                    continue;
                }

                cm.CommitteesConfigurationId = committeeNameEntity.Id;
            }

            var designation = DataRowHelper.GetStringValue(row, "Designation")?.Trim();
            if (string.IsNullOrEmpty(designation))
            {
                skippedList.Add((sl, designation, $"Designation '{designation}' can not be null"));
                continue;
            }
            else
            {
                var committeeDesignation = await _writeOnlyCtx.Set<CommitteeDesignationsConfiguration>()
                    .Where(x => x.DesignationName.Equals(designation))
                    .Where(x => x.CommitteesConfigurationId == cm.CommitteesConfigurationId)
                    .FirstOrDefaultAsync();
                if (committeeDesignation is null)
                {
                    skippedList.Add((sl, designation, $"Designation '{designation}' is not found in DB"));
                    continue;
                }

                cm.CommitteeDesignationsConfigurationId = committeeDesignation.Id;
                _designationId = committeeDesignation.Id;
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
                    CommitteeDesignationsConfigurationId = _designationId,
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
                    //.FromSqlRaw($"SELECT * FROM \"BEN\".\"Surveys\" s WHERE s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiaryHouseholdId}' AND s.\"BeneficiaryNid\" LIKE '%{nid}%' OR s.\"BeneficiaryPhone\" LIKE '%{mobileNo}%' OR s.\"BeneficiaryPhoneBn\" LIKE '%{mobileNo}%' ORDER BY CASE WHEN s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiaryHouseholdId}' THEN 1 WHEN s.\"BeneficiaryNid\" LIKE '%{nid}%' THEN 2 ELSE 3 END")
                    .FromSqlRaw($"SELECT * FROM \"BEN\".\"Surveys\" s WHERE s.\"BeneficiaryNid\" = '{nid}'")
                    .FirstOrDefaultAsync();
                if (survey is null)
                {
                    skippedList.Add((sl, nid, $"Beneficiary NID \'{nid}\' and FCV/VCF \'{fcv_vcf}\' is not found in DB"));
                    continue;
                }
                else
                {
                    cm.CommitteeManagementMembers.Add(new CommitteeManagementMember
                    {
                        CommitteeDesignationsConfigurationId = _designationId,
                        SurveyId = survey.Id,
                    });
                }
            }

            if (cm.CommitteeManagementMembers.Where(x => x.CommitteeDesignationsConfigurationId == 0).Count() > 0)
            {
                defaultDesignationId++;
            }

            committeeManagementList.Add(cm);
        }

        var abc = committeeManagementList.GroupBy(x => new { x.ForestFcvVcfId, x.CommitteesConfigurationId })
            .Select(group => new CommitteeManagement
            {
                Name = group.First().Name,
                NameBn = group.First().NameBn,
                ForestCircleId = group.First().ForestCircleId,
                ForestDivisionId = group.First().ForestDivisionId,
                ForestRangeId = group.First().ForestRangeId,
                ForestBeatId = group.First().ForestBeatId,
                ForestFcvVcfId = group.First().ForestFcvVcfId,
                DivisionId = group.First().DivisionId,
                DistrictId = group.First().DistrictId,
                UpazillaId = group.First().UpazillaId,
                UnionId = group.First().UnionId,
                NgoId = group.First().NgoId,
                CommitteeTypeId = group.First().CommitteeTypeId,
                SubCommitteeTypeId = group.First().SubCommitteeTypeId,
                CommitteeFormDate = group.First().CommitteeFormDate,
                CommitteeEndDate = group.First().CommitteeEndDate,
                NameOfBankAC = group.First().NameOfBankAC,
                AccountNumber = group.First().AccountNumber,
                AccountType = group.First().AccountType,
                BankName = group.First().BankName,
                BranchName = group.First().BranchName,
                AccountOpeningDate = group.First().AccountOpeningDate,
                Remark = group.First().Remark,
                IsInActiveCommittee = group.First().IsInActiveCommittee,
                CommitteeApprovalStatus = group.First().CommitteeApprovalStatus,
                CommitteeApprovalBy = group.First().CommitteeApprovalBy,
                CommitteeApprovalDate = group.First().CommitteeApprovalDate,
                CommitteeTypeConfigurationId = group.First().CommitteeTypeConfigurationId,
                CommitteesConfigurationId = group.First().CommitteesConfigurationId,
                CommitteeDesignationsConfigurationId = group.First().CommitteeDesignationsConfigurationId,
                ApprovalStatus = group.First().ApprovalStatus,
                CommitteeManagementMembers = group.SelectMany(x => x.CommitteeManagementMembers).ToList()
            });

        await _writeOnlyCtx.Set<CommitteeManagement>().AddRangeAsync(abc);
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
