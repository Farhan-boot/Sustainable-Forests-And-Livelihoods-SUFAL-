using System.Data;
using System.Data.OleDb;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

/*
public class CommunityTrainingMigrationWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CommunityTrainingMigrationWeb(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("community-training-migrate-web/{shouldMigrate}")]
    public async Task<IActionResult> CipList([FromRoute] bool shouldMigrate, IFormFile excelFile)
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

            var command = $"SELECT * From [Training$]";

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
            using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
            var ctList = new List<CommunityTraining>();
            var skippedList = new List<ValueTuple<double, string, string>>();
            foreach (var row in dt.Rows.Cast<DataRow>().Skip(0))
            {
                var ct = new CommunityTraining();
                ct.CreatedAt = DateTime.Now;
                ct.CreatedBy = 3;
                ct.IsActive = true;

                var sl = DataRowHelper.GetLongValue(row, "Training Serial No");
                var forest_circle = DataRowHelper.GetStringValue(row, "ForestCircle")?.Trim();
                var forest_division = DataRowHelper.GetStringValue(row, "ForestDivision")?.Trim();
                var forest_range = DataRowHelper.GetStringValue(row, "ForestRange")?.Trim();
                var forest_beat = DataRowHelper.GetStringValue(row, "ForestBeat")?.Trim();
                var fcv_vcf = DataRowHelper.GetStringValue(row, "ForestFcvVcf")?.Trim();

                ct.Id = sl;

                if (string.IsNullOrEmpty(fcv_vcf) == false)
                {
                    var circle = await _writeOnlyCtx.Set<ForestCircle>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestCircles\" e where e.\"Name\" like '%{forest_circle}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(forest_circle) || circle is null)
                    {
                        skippedList.Add((sl, forest_circle, $"Forest Circle '{forest_circle}' is not found in DB"));
                        continue;
                    }

                    var division = await _writeOnlyCtx.Set<ForestDivision>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestDivisions\" e where e.\"Name\" like '%{forest_division}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(forest_division) || division is null)
                    {
                        skippedList.Add((sl, forest_division, $"Forest Division '{forest_division}' is not found in DB"));
                        continue;
                    }

                    var range = await _writeOnlyCtx.Set<ForestRange>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestRanges\" e where e.\"Name\" like '%{forest_range}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(forest_range) || range is null)
                    {
                        skippedList.Add((sl, forest_range, $"Forest Range '{forest_range}' is not found in DB"));
                        continue;
                    }

                    var beat = await _writeOnlyCtx.Set<ForestBeat>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestBeats\" e where e.\"Name\" like '%{forest_beat}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(forest_beat) || beat is null)
                    {
                        skippedList.Add((sl, forest_beat, $"Forest Beat '{forest_beat}' is not found in DB"));
                        continue;
                    }

                    var fcvVcf = await _writeOnlyCtx.Set<ForestFcvVcf>()
                        .FromSqlRaw($"select * from \"BEN\".\"ForestFcvVcfs\" e where e.\"Name\" like '%{fcv_vcf}%'")
                        .FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(fcv_vcf) || fcvVcf is null)
                    {
                        skippedList.Add((sl, fcv_vcf, $"Forest FCV/VCF '{fcv_vcf}' is not found in DB"));
                        continue;
                    }

                    ct.ForestCircleId = circle.Id;
                    ct.ForestDivisionId = division.Id;
                    ct.ForestRangeId = range.Id;
                    ct.ForestBeatId = beat.Id;
                    ct.ForestFcvVcfId = fcvVcf.Id;
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
                    skippedList.Add((sl, civil_division, $"Division '{civil_division}' is not found in DB"));
                    continue;
                }

                var civil_dis = await _writeOnlyCtx.Set<District>()
                    .FromSqlRaw($"select * from \"GS\".\"District\" e where e.\"Name\" ilike '%{civil_district}%' and e.\"DivisionId\" = {civil_div.Id}")
                    .FirstOrDefaultAsync();
                if (string.IsNullOrEmpty(civil_district) || civil_dis is null)
                {
                    skippedList.Add((sl, civil_district, $"District '{civil_district}' is not found in DB"));
                    continue;
                }

                var civil_upazilla = await _writeOnlyCtx.Set<Upazilla>()
                    .FromSqlRaw($"select * from \"GS\".\"Upazilla\" e where e.\"Name\" ilike '%{upazilla}%' and e.\"DistrictId\" = {civil_dis.Id}")
                    .FirstOrDefaultAsync();
                if (string.IsNullOrEmpty(upazilla) || civil_upazilla is null)
                {
                    skippedList.Add((sl, upazilla, $"Upazilla '{upazilla}' is not found in DB"));
                    continue;
                }

                var civil_union = await _writeOnlyCtx.Set<Union>()
                    .FromSqlRaw($"select * from \"GS\".\"Union\" e where e.\"Name\" ilike '%{union}%' and e.\"UpazillaId\" = {civil_upazilla.Id}")
                    .FirstOrDefaultAsync();

                ct.DivisionId = civil_div.Id;
                ct.DistrictId = civil_dis.Id;
                ct.UpazillaId = civil_upazilla.Id;

                if (civil_union == null)
                {
                    ct.UnionId = null;
                }
                else
                {
                    ct.UnionId = civil_union.Id;
                }


                ct.TrainingTitle = DataRowHelper.GetStringValue(row, "TrainingTitle");
                ct.StartDate = DataRowHelper.GetDateTimeValue(row, "StartDate") ?? DateTime.MinValue;
                ct.EndDate = DataRowHelper.GetDateTimeValue(row, "EndDate") ?? DateTime.MinValue;
                ct.TrainingDuration = $"{DataRowHelper.GetIntValue(row, "TrainingDuration")} days";
                ct.Location = DataRowHelper.GetStringValue(row, "Location");
                ct.TrainerName = DataRowHelper.GetStringValue(row, "TrainerName");

                var eventType = DataRowHelper.GetStringValue(row, "EventType");
                //if (eventType.ToString() != "Training" || eventType.ToString() != "Workshop")
                //{
                //    skippedList.Add((sl, eventType, "Valid values are Training, Workshop"));
                //    continue;
                //}
              
                
                ct.EventTypeId = eventType == "Training" ? 1 : 2;

                //ct.TrainingOrganizerId = null;

                var communityTrainingTypeString = DataRowHelper.GetStringValue(row, "CommunityTrainingType");
                if (ct.EventTypeId == 1)
                {
                    var communityTrainingType = await _writeOnlyCtx.Set<CommunityTrainingType>()
                        .FromSqlRaw($"select * from \"Capacity\".\"CommunityTrainingTypes\" e where e.\"Name\" ilike '%{communityTrainingTypeString}%'")
                        .FirstOrDefaultAsync();
                    if (communityTrainingType is null)
                    {
                        skippedList.Add((sl, communityTrainingTypeString, $"Community Training Type is not found in DB"));
                        continue;
                    }
                    ct.CommunityTrainingTypeId = communityTrainingType.Id;
                }
                else
                {
                    var communityTrainingType = await _writeOnlyCtx.Set<CommunityTrainingType>()
                        .FromSqlRaw($"select * from \"Capacity\".\"CommunityTrainingTypes\" e where e.\"Name\" ilike '%{communityTrainingTypeString}%'")
                        .FirstOrDefaultAsync();
                    if (communityTrainingType is null)
                    {
                        skippedList.Add((sl, communityTrainingTypeString, $"Community Training Type is not found in DB"));
                        continue;
                    }
                    ct.CommunityTrainingTypeId = communityTrainingType.Id;
                }
                ct.Id = 0;
                ctList.Add(ct);
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
                var p = new CommunityTrainingParticipentsMap();
                p.CreatedAt = DateTime.Now;
                p.CreatedBy = 3;
                p.IsActive = true;

                var serialNo = DataRowHelper.GetLongValue(row, "Training Serial No");
                var training = ctList.Where(x => x.Id == serialNo).FirstOrDefault();
                if (training is null)
                {
                    skippedList.Add((serialNo, "", $"Training id not found with {serialNo}"));
                    continue;
                }

                // Search Beneficiary
                var beneficiaryPhone = string.Empty;
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

                if (training.CommunityTrainingParticipentsMaps is null)
                {
                    training.CommunityTrainingParticipentsMaps = new List<CommunityTrainingParticipentsMap>();
                }
                training.CommunityTrainingParticipentsMaps.Add(p);
            }
            #endregion

            #region Other Member
            DataTable dtb2 = new DataTable();

            var commandb2 = $"SELECT * From [Other Members$]";

            // Read from Excel
            using (var connection = new OleDbConnection(conString))
            {
                using var sqlCommand = new OleDbCommand(commandb2, connection);

                await connection.OpenAsync();
                using var adapter = new OleDbDataAdapter(sqlCommand);
                adapter.Fill(dtb2);
                await connection.CloseAsync();
            }

            foreach (var row in dtb2.Rows.Cast<DataRow>().Skip(0))
            {
                var p = new CommunityTrainingParticipentsMap();
                p.CreatedAt = DateTime.Now;
                p.CreatedBy = 3;
                p.IsActive = true;

                var serialNo = DataRowHelper.GetLongValue(row, "Training Serial No");
                var training = ctList.Where(x => x.Id == serialNo).FirstOrDefault();
                if (training is null)
                {
                    skippedList.Add((serialNo, "", "Training id not found"));
                    continue;
                }

                var member = new CommunityTrainingMember();

                member.MemberName = DataRowHelper.GetStringValue(row, "Member Name");
                member.MemberAge = DataRowHelper.GetIntValue(row, "Member Age");
                member.MemberPhoneNumber = DataRowHelper.GetStringValue(row, "Member Phone Number");
                member.MemberAddress = DataRowHelper.GetStringValue(row, "Member Address");
                member.MemberGender = DataRowHelper.GetStringValue(row, "Member Gender") == "Male" ? Common.Enum.Gender.Male : Common.Enum.Gender.Female;
                member.MemberNid = DataRowHelper.GetStringValue(row, "NID");

                p.ParticipentType = Common.Enum.Capacity.ParticipentType.Member;
                p.CommunityTrainingMember = member;

                if (training.CommunityTrainingParticipentsMaps is null)
                {
                    training.CommunityTrainingParticipentsMaps = new List<CommunityTrainingParticipentsMap>();
                }
                training.CommunityTrainingParticipentsMaps.Add(p);
            }
            #endregion

            var skippedListJsonFormat = skippedList
                .Select(x => new
                {
                    SerialNo = x.Item1,
                    Value = x.Item2,
                    Message = x.Item3
                })
                .DistinctBy(x => x.Value)
                .ToList();


            var checkId = ctList.Where(x => x.Id > 0);

            //&& skippedListJsonFormat.Count == 0
            if (shouldMigrate)
            {
                await _writeOnlyCtx.Set<CommunityTraining>().AddRangeAsync(ctList);
                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();
            }

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
*/
