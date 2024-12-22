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
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class PatrollingDataMigrationWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public PatrollingDataMigrationWeb(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("patrolling-migration-web/{shouldMigrate}")]
    public async Task<IActionResult> Migrate([FromRoute] bool shouldMigrate, IFormFile excelFile)
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

        var command = $"SELECT * From [PatrollingInformation$]";

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
        var patrollingList = new List<PatrollingScheduling>();
        var skippedList = new List<ValueTuple<double, string, string>>();
        foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
        {
            var checkId = DataRowHelper.GetDoubleValue(row, "Serial No");
            if (checkId > 0)
            {
                var p = new PatrollingScheduling();
                p.CreatedAt = DateTime.Now;
                p.CreatedBy = 3;
                p.IsActive = true;

                var sl = DataRowHelper.GetLongValue(row, "Serial No");
                var forest_circle = DataRowHelper.GetStringValue(row, "ForestCircle");
                var forest_division = DataRowHelper.GetStringValue(row, "ForestDivision");
                var forest_range = DataRowHelper.GetStringValue(row, "ForestRange");
                var forest_beat = DataRowHelper.GetStringValue(row, "ForestBeat");
                var fcv_vcf = DataRowHelper.GetStringValue(row, "ForestFcvVcf");

                p.Id = sl;
                p.Id = 0;
                var patrollingDate = DataRowHelper.GetDateTimeValue(row, "PatrollingDate");

                if (patrollingDate is null)
                {
                    continue;
                }

                p.Date = patrollingDate;
                p.AllocatedAmountMonth = string.Empty;
                p.Remark = string.Empty;

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

                    var division = await _writeOnlyCtx.Set<ForestDivision>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%'")
                        .FirstOrDefaultAsync();
                    if (division is null)
                    {
                        skippedList.Add((sl, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                        continue;
                    }

                    var range = await _writeOnlyCtx.Set<ForestRange>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%'")
                        .FirstOrDefaultAsync();
                    if (range is null)
                    {
                        skippedList.Add((sl, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                        continue;
                    }

                    var beat = await _writeOnlyCtx.Set<ForestBeat>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%'")
                        .FirstOrDefaultAsync();
                    if (beat is null)
                    {
                        skippedList.Add((sl, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                        continue;
                    }

                    var fcvVcf = await _writeOnlyCtx.Set<ForestFcvVcf>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{fcv_vcf}%'")
                        .FirstOrDefaultAsync();
                    if (fcvVcf is null)
                    {
                        skippedList.Add((sl, fcv_vcf, $"Forest FCV/VCF '{fcv_vcf}' is not found in DB"));
                        continue;
                    }

                    p.ForestCircleId = circle.Id;
                    p.ForestDivisionId = division.Id;
                    p.ForestRangeId = range.Id;
                    p.ForestBeatId = beat.Id;
                    p.ForestFcvVcfId = fcvVcf.Id;
                    p.FcvId = fcvVcf.IsFcv ? 0 : 1;
                }

                var civil_division = DataRowHelper.GetStringValue(row, "Division");
                var civil_district = DataRowHelper.GetStringValue(row, "District");
                var upazilla = DataRowHelper.GetStringValue(row, "Upazilla");
                var union = DataRowHelper.GetStringValue(row, "Union");

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
                        .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{civil_district.Replace("'", "''")}%' and e.\"DivisionId\" = {civil_div.Id}")
                        .FirstOrDefaultAsync();
                    if (civil_dis is null)
                    {
                        skippedList.Add((sl, civil_district, $"District '{civil_district}' is not found in DB"));
                        continue;
                    }

                    var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                        .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{upazilla}%' and e.\"DistrictId\" = {civil_dis.Id}")
                        .FirstOrDefaultAsync();
                    if (civil_upazilla is null)
                    {
                        skippedList.Add((sl, upazilla, $"Upazilla '{upazilla}' is not found in DB"));
                        continue;
                    }

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

                    p.DivisionId = civil_div.Id;
                    p.DistrictId = civil_dis.Id;
                    p.UpazillaId = civil_upazilla.Id;
                    p.UnionId = civil_union.Id;
                }

                var ngo = DataRowHelper.GetStringValue(row, "Ngo");
                var ngo_db = await _writeOnlyCtx.Set<Ngo>()
                    .FromSqlRaw($"select * from \"BEN\".\"Ngos\" e where e.\"Name\" like '%{ngo}%'")
                    .FirstOrDefaultAsync();
                if (ngo_db is null)
                {
                    skippedList.Add((sl, ngo, "NGO is not found in DB"));
                    continue;
                }
                if (ngo_db is not null)
                {
                    p.NgoId = ngo_db.Id;
                }


                p.PatrollingDescription = DataRowHelper.GetStringValue(row, "Description");
                p.PatrollingArea = DataRowHelper.GetStringValue(row, "PatrollingArea");

                var startTime = DataRowHelper.GetDateTimeValue(row, "StartTime");
                var endTime = DataRowHelper.GetDateTimeValue(row, "EndTime");

                p.StartTime = patrollingDate?.AddHours(startTime?.Hour ?? 0);
                p.EndTime = patrollingDate?.AddHours(endTime?.Hour ?? 0);

                patrollingList.Add(p);
            }

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
            var p = new PatrollingSchedulingParticipentsMap();
            p.CreatedAt = DateTime.Now;
            p.CreatedBy = 3;
            p.IsActive = true;

            var serialNo = DataRowHelper.GetDoubleValue(row, "Serial No");
            var patrollingDate = DataRowHelper.GetDateTimeValue(row, "PatrollingDate");
            var patrolling = patrollingList.Where(x => x.Date == patrollingDate).FirstOrDefault();
            if (patrolling is null)
            {
                skippedList.Add((serialNo, "", "Patrolling id not found"));
                continue;
            }

            // Search Beneficiary
            var beneficiaryPhone = DataRowHelper.GetStringValue(row, "BeneficiaryPhone");
            var beneficiaryNid = DataRowHelper.GetStringValue(row, "BeneficiaryNID");
            var beneficiarySerialNo = DataRowHelper.GetStringValue(row, "BeneficiaryId");
            var beneficiaryName = DataRowHelper.GetStringValue(row, "BeneficiaryName");

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

            if (patrolling.PatrollingSchedulingParticipentsMaps is null)
            {
                patrolling.PatrollingSchedulingParticipentsMaps = new List<PatrollingSchedulingParticipentsMap>();
            }
            patrolling.PatrollingSchedulingParticipentsMaps.Add(p);
        }
        #endregion

        foreach (var item in patrollingList)
        {
            item.FcvId = 1;
        }

        if (shouldMigrate)
        {
            await _writeOnlyCtx.Set<PatrollingScheduling>().AddRangeAsync(patrollingList);
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

        //if (skippedListJsonFormat.Count > 0)
        //{
        //    return Ok(skippedListJsonFormat);
        //}


     return Ok(new List<object>()
        {
      new
         {
          SerialNo = 0,
          Value = "",
          Message = "All ok"
        },
       });



        // await System.IO.File.WriteAllTextAsync("D:\\sufl_assets\\_Data_\\Mymensingh\\Patrolling\\problem-patrolling.txt", System.Text.Json.JsonSerializer.Serialize(skippedListJsonFormat, new System.Text.Json.JsonSerializerOptions
        //{
        //     WriteIndented = true,
        //}));

        // return Ok($"Completed. Skipped: {skippedList.Count}");
    }
}
