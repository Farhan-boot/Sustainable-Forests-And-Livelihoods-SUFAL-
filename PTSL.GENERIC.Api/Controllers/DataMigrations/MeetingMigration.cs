using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.MeetingManagement;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class MeetingMigration : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public MeetingMigration(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("Meeting-Migration")]
    public async Task<IActionResult> Migrate(string filePath, bool save = false)
    {
        var conString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 8.0;HDR=YES'";

        var meetingDataTable = new DataTable();
        var beneficiaryDataTable = new DataTable();

        {
            var command = $"SELECT * From [Meeting$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using var sqlCommand = new OleDbCommand(command, connection);
                await connection.OpenAsync();

                using var adapter = new OleDbDataAdapter(sqlCommand);
                adapter.Fill(meetingDataTable);

                await connection.CloseAsync();
            }
        }

        // Meetings
        var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

        var meetingList = new List<Meeting>();
        var skippedList = new List<ValueTuple<double, string, string>>();

        foreach (var row in meetingDataTable.Rows.Cast<DataRow>().Skip(0))
        {
            var meeting = new Meeting();
            meeting.CreatedAt = DateTime.Now;
            meeting.CreatedBy = 3;
            meeting.IsActive = true;

            meeting.Id = DataRowHelper.GetLongValue(row, "Serial No");

            var forest_circle = row.Field<string>("Forest Circle").Trim();
            var forest_division = row.Field<string>("Forest Division").Trim();
            var forest_range = row.Field<string>("Forest Range").Trim();
            var forest_beat = row.Field<string>("Forest Beat").Trim();
            var fcv_vcf = row.Field<string>("Forest Fcv/Vcf").Trim();

            if (string.IsNullOrEmpty(fcv_vcf) == false)
            {
                var circle = await _writeOnlyCtx.Set<ForestCircle>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestCircles\" e where e.\"Name\" like '%{forest_circle}%'")
                    .FirstOrDefaultAsync();
                if (string.IsNullOrEmpty(forest_circle) || circle is null)
                {
                    skippedList.Add((meeting.Id, forest_circle, $"Forest Circle '{forest_circle}' is not found in DB"));
                    continue;
                }

                var division = await _writeOnlyCtx.Set<ForestDivision>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%'")
                    .FirstOrDefaultAsync();
                if (string.IsNullOrEmpty(forest_division) || division is null)
                {
                    skippedList.Add((meeting.Id, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                    continue;
                }

                var range = await _writeOnlyCtx.Set<ForestRange>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%'")
                    .FirstOrDefaultAsync();
                if (string.IsNullOrEmpty(forest_range) || range is null)
                {
                    skippedList.Add((meeting.Id, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                    continue;
                }

                var beat = await _writeOnlyCtx.Set<ForestBeat>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%'")
                    .FirstOrDefaultAsync();
                if (string.IsNullOrEmpty(forest_beat) || beat is null)
                {
                    skippedList.Add((meeting.Id, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                    continue;
                }

                var fcvVcf = await _writeOnlyCtx.Set<ForestFcvVcf>()
                    .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{fcv_vcf}%'")
                    .FirstOrDefaultAsync();
                if (string.IsNullOrEmpty(fcv_vcf) || fcvVcf is null)
                {
                    skippedList.Add((meeting.Id, fcv_vcf, $"Forest FCV/VCF '{fcv_vcf}' is not found in DB"));
                    continue;
                }

                meeting.ForestCircleId = circle.Id;
                meeting.ForestDivisionId = division.Id;
                meeting.ForestRangeId = range.Id;
                meeting.ForestBeatId = beat.Id;
                meeting.ForestFcvVcfId = fcvVcf.Id;
            }

            var civil_division = DataRowHelper.GetStringValue(row, "Division")?.Trim();
            var civil_district = DataRowHelper.GetStringValue(row, "District")?.Trim();
            var upazilla = DataRowHelper.GetStringValue(row, "Upazilla")?.Trim();
            var union = DataRowHelper.GetStringValue(row, "Union")?.Trim();

            var civil_div = await _writeOnlyCtx.Set<Division>()
                .FromSqlRaw($"select * from \"GS\".\"Division\" e where e.\"DivisionName\" ilike '%{civil_division}%'")
                .FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(civil_division) || civil_div is null)
            {
                skippedList.Add((meeting.Id, civil_division, $"Division '{civil_division}' is not found in DB"));
                continue;
            }

            var civil_dis = await _writeOnlyCtx.Set<District>()
                .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{civil_district}%' and e.\"DivisionId\" = {civil_div.Id}")
                .FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(civil_district) || civil_dis is null)
            {
                skippedList.Add((meeting.Id, civil_district, $"District '{civil_district}' is not found in DB"));
                continue;
            }

            var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{upazilla}%' and e.\"DistrictId\" = {civil_dis.Id}")
                .FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(upazilla) || civil_upazilla is null)
            {
                skippedList.Add((meeting.Id, upazilla, $"Upazilla '{upazilla}' is not found in DB"));
                continue;
            }

            var civil_union = await _writeOnlyCtx.Set<Union>()
                .FromSqlRaw($"select * from \"GS\".\"Union\" e where e.\"Name\" ilike '%{union}%' and e.\"UpazillaId\" = {civil_upazilla.Id}")
                .FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(union) || civil_union is null)
            {
                skippedList.Add((meeting.Id, union, $"Union '{union}' is not found in DB"));
                continue;
            }

            meeting.DivisionId = civil_div.Id;
            meeting.DistrictId = civil_dis.Id;
            meeting.UpazillaId = civil_upazilla.Id;
            meeting.UnionId = civil_union.Id;

            var ngo = DataRowHelper.GetStringValue(row, "Ngo");
            var ngo_db = await _writeOnlyCtx.Set<Ngo>()
                .FromSqlRaw($"select * from \"BEN\".\"Ngos\" e where e.\"Name\" like '%{ngo}%'")
                .FirstOrDefaultAsync();
            if (ngo_db is null)
            {
                if (ngo_db is null)
                {
                    skippedList.Add((meeting.Id, ngo, $"NGO {ngo} is not found in DB"));
                    continue;
                }

                meeting.NgoId = ngo_db.Id;
            }

            var financial_year = DataRowHelper.GetStringValue(row, "Financial Year");
            if (string.IsNullOrEmpty(union) == false)
            {
                var financial_year_db = await _writeOnlyCtx.Set<FinancialYear>()
                    .FromSqlRaw($"select * from \"GS\".\"FinancialYears\" e where e.\"Name\" like '%{financial_year}%'")
                    .FirstOrDefaultAsync();

                if (financial_year_db is null)
                {
                    skippedList.Add((meeting.Id, financial_year, $"Financial year '${financial_year}' not found"));
                    continue;
                }

                meeting.FinancialYearId = financial_year_db.Id;
            }

            meeting.MeetingDate = DataRowHelper.GetDateTimeValue(row, "Meeting Date") ?? DateTime.MinValue;

            var startTime = DataRowHelper.GetIntValue(row, "Start Time");
            var endTime = DataRowHelper.GetIntValue(row, "End Time");
            meeting.StartTime = meeting.MeetingDate.AddHours(startTime);
            meeting.EndTime = meeting.MeetingDate.AddHours(startTime).AddHours(3);
            meeting.MeetingTitle = DataRowHelper.GetStringValue(row, "Meeting Title");

            var meetingType = DataRowHelper.GetStringValue(row, "Meeting Type");
            if (string.IsNullOrEmpty(meetingType) == false)
            {
                var meeting_type_db = await _writeOnlyCtx.Set<MeetingType>()
                    .FromSqlRaw($"select * from \"Meeting\".\"MeetingTypes\" e where e.\"Name\" like '%{meetingType}%'")
                    .FirstOrDefaultAsync();
                if (meeting_type_db is null)
                {
                    skippedList.Add((meeting_type_db.Id, meetingType, $"Meeting type '${meetingType}' not found"));
                    continue;
                }

                meeting.MeetingTypeId = meeting_type_db.Id;
            }

            meetingList.Add(meeting);
        }

        #region Beneficiary
        DataTable dtb = new DataTable();

        var commandb = $"SELECT * From [Beneficiary$]";

        // Read from Excel
        using (var connection = new OleDbConnection(conString))
        {
            using var sqlCommand = new OleDbCommand(commandb, connection);

            await connection.OpenAsync();
            using var adapter = new OleDbDataAdapter(sqlCommand);
            adapter.Fill(dtb);
            await connection.CloseAsync();
        }

        foreach (var row in dtb.Rows.Cast<DataRow>().Skip(0))
        {
            var p = new MeetingParticipantsMap();
            p.CreatedAt = DateTime.Now;
            p.CreatedBy = 3;
            p.IsActive = true;

            var serialNo = DataRowHelper.GetLongValue(row, "Training Serial No");
            var training = meetingList.Where(x => x.Id == serialNo).FirstOrDefault();
            if (training is null)
            {
                skippedList.Add((serialNo, "", $"Meeting id with {serialNo} not found"));
                continue;
            }

            // Search Beneficiary
            var beneficiaryPhone = DataRowHelper.GetStringValue(row, "Beneficiary Phone");
            var beneficiaryNid = DataRowHelper.GetStringValue(row, "Beneficiary NID");
            var beneficiarySerialNo = DataRowHelper.GetStringValue(row, "Beneficiary Id");
            var beneficiaryName = DataRowHelper.GetStringValue(row, "Beneficiary Name");

            var survey = await _writeOnlyCtx.Set<Survey>()
                .FromSqlRaw($"SELECT * FROM \"BEN\".\"Surveys\" s WHERE s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiarySerialNo}' AND s.\"BeneficiaryNid\" LIKE '%{beneficiaryNid}%' OR s.\"BeneficiaryPhone\" LIKE '%{beneficiaryPhone}%' OR s.\"BeneficiaryPhoneBn\" LIKE '%{beneficiaryPhone}%' OR s.\"BeneficiaryName\" LIKE '%{beneficiaryName}%' ORDER BY CASE WHEN s.\"BeneficiaryHouseholdSerialNo\" = '{beneficiarySerialNo}' THEN 1 WHEN s.\"BeneficiaryNid\" LIKE '%{beneficiaryNid}%' THEN 2 ELSE 3 END")
                .FirstOrDefaultAsync();
            if (survey is null)
            {
                skippedList.Add((serialNo, beneficiaryNid, "Beneficiary nid is not found in DB"));
                continue;
            }
            p.SurveyId = survey?.Id;
            p.ParticipentType = Common.Enum.Capacity.ParticipentType.Beneficiary;

            if (training.MeetingParticipantsMaps is null)
            {
                training.MeetingParticipantsMaps = new List<MeetingParticipantsMap>();
            }
            training.MeetingParticipantsMaps.Add(p);
        }
        #endregion

        foreach (var item in meetingList)
        {
            item.Id = 0;
        }

        if (save)
        {
            _writeOnlyCtx.Set<Meeting>().AddRange(meetingList);
            await _writeOnlyCtx.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        var skippedMeetingListJsonFormat = skippedList
            .Select(x => new
            {
                SerialNo = x.Item1,
                Value = x.Item2,
                Message = x.Item3
            })
            .DistinctBy(x => x.Value)
            .ToList();

        await System.IO.File.WriteAllTextAsync("D:\\sufl_assets\\_Data_\\Mymensingh\\Meeting\\problem-meeting.txt", System.Text.Json.JsonSerializer.Serialize(skippedMeetingListJsonFormat, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true,
        }));

        return Ok($"Completed. Skipped: {skippedList.Count}");
    }
}

