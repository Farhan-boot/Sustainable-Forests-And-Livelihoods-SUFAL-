using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MiniExcelLibs;
using MiniExcelLibs.Attributes;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class CommunityTrainingMigrationWebV2 : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public CommunityTrainingMigrationWebV2(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("community-training-migrate-web/{shouldMigrate}")]
    public async Task<IActionResult> CommunityTraining([FromRoute] bool shouldMigrate, IFormFile excelFile)
    {
        try
        {
            if (excelFile == null || excelFile.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            // Save file
            var filePath = Path.Join(Path.GetTempPath(), excelFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await excelFile.CopyToAsync(stream);
            }

            // Read and save
            var trainingRows = MiniExcel.Query<CommunityTrainingTrainingSheetExcelFormat>(filePath, sheetName: "Training");
            var beneficiaryRows = MiniExcel.Query<CommunityTrainingBeneficiarySheetExcelFormat>(filePath, sheetName: "Beneficiary");
            var otherMemberRows = MiniExcel.Query<CommunityTrainingBeneficiaryOtherBeneficiaryExcelFormat>(filePath, sheetName: "Other Members");
            var communityTrainingList = new List<CommunityTraining>();
            var skippedList = new List<ValueTuple<double, string?, string>>();

            var trainingRowsList = trainingRows.ToList();
            foreach (var row in trainingRowsList)
            {
                row.CommunityTrainingBeneficiarySheetExcelFormats = beneficiaryRows.Where(x => x.TrainingSerialNo == row.TrainingSerialNo);
                row.CommunityTrainingBeneficiaryOtherBeneficiaryExcelFormats = otherMemberRows.Where(x => x.TrainingSerialNo == row.TrainingSerialNo);
            }

            foreach (var row in trainingRowsList)
            {
                var communityTraining = new CommunityTraining
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = 3,
                    IsActive = true
                };

                row.ForestCircle = row.ForestCircle?.Trim()?.Replace('\u00A0', ' ');
                row.ForestDivision = row.ForestDivision?.Trim()?.Replace('\u00A0', ' ');
                row.ForestRange = row.ForestRange?.Trim()?.Replace('\u00A0', ' ');
                row.ForestBeat = row.ForestBeat?.Trim()?.Replace('\u00A0', ' ');
                row.ForestFcvVcf = row.ForestFcvVcf?.Trim()?.Replace('\u00A0', ' ');
                row.Division = row.Division?.Trim()?.Replace('\u00A0', ' ');
                row.District = row.District?.Trim()?.Replace('\u00A0', ' ');
                row.Upazilla = row.Upazilla?.Trim()?.Replace('\u00A0', ' ');
                row.Union = row.Union?.Trim()?.Replace('\u00A0', ' ');

                row.TrainingTitle = row.TrainingTitle?.Trim()?.Replace('\u00A0', ' ');
                row.Location = row.Location?.Trim()?.Replace('\u00A0', ' ');
                row.TrainerName = row.TrainerName?.Trim()?.Replace('\u00A0', ' ');
                row.EventType = row.EventType?.Trim()?.Replace('\u00A0', ' ');
                row.CommunityTrainingType = row.CommunityTrainingType?.Trim()?.Replace('\u00A0', ' ');
                row.TrainingOrganizer = row.TrainingOrganizer?.Trim()?.Replace('\u00A0', ' ');
                row.Ngo = row.Ngo?.Trim()?.Replace('\u00A0', ' ');

                if (row.StartDate is null)
                {
                    skippedList.Add((row.TrainingSerialNo, row.StartDate?.ToString(), $"Start Date ->{row.StartDate?.ToString()}<- can not be empty. Skipping entire row"));
                    continue;
                }
                if (row.EndDate is null)
                {
                    skippedList.Add((row.TrainingSerialNo, row.EndDate?.ToString(), $"End Date ->{row.EndDate?.ToString()}<- can not be empty. Skipping entire row"));
                    continue;
                }

                communityTraining.TrainingTitle = row.TrainingTitle;
                communityTraining.TrainerName = row.TrainerName;
                communityTraining.StartDate = (DateTime)row.StartDate;
                communityTraining.EndDate = (DateTime)row.EndDate;
                communityTraining.Location = row.Location;

                // Training Organizer
                if (string.IsNullOrEmpty(row.TrainingOrganizer))
                {
                    skippedList.Add((row.TrainingSerialNo, row.TrainingOrganizer, $"TrainingOrganizer ->{row.TrainingOrganizer}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var trainingOrganizer = await _writeOnlyCtx.Set<TrainingOrganizer>()
                    .Where(x => x.Name == row.TrainingOrganizer)
                    .FirstOrDefaultAsync();
                if (trainingOrganizer is null)
                {
                    skippedList.Add((row.TrainingSerialNo, row.TrainingOrganizer, $"TrainingOrganizer ->{row.TrainingOrganizer}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                communityTraining.TrainingOrganizerId = trainingOrganizer.Id;

                // Community Training Type
                if (string.IsNullOrEmpty(row.CommunityTrainingType))
                {
                    skippedList.Add((row.TrainingSerialNo, row.CommunityTrainingType, $"CommunityTrainingType ->{row.CommunityTrainingType}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var communityTrainingType = await _writeOnlyCtx.Set<CommunityTrainingType>()
                    .Where(x => x.Name == row.CommunityTrainingType)
                    .FirstOrDefaultAsync();
                if (communityTrainingType is null)
                {
                    skippedList.Add((row.TrainingSerialNo, row.CommunityTrainingType, $"CommunityTrainingType ->{row.CommunityTrainingType}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                communityTraining.CommunityTrainingTypeId = communityTrainingType.Id;

                // Community Event Type
                if (string.IsNullOrEmpty(row.EventType))
                {
                    skippedList.Add((row.TrainingSerialNo, row.EventType, $"EventType ->{row.EventType}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var eventType = await _writeOnlyCtx.Set<EventType>()
                    .Where(x => x.Name == row.EventType)
                    .FirstOrDefaultAsync();
                if (eventType is null)
                {
                    skippedList.Add((row.TrainingSerialNo, row.EventType, $"EventType ->{row.EventType}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                communityTraining.EventTypeId = eventType.Id;

                var beneficiaryList = row.CommunityTrainingBeneficiarySheetExcelFormats.ToList();
                if (beneficiaryList.Count == 0)
                {
                    skippedList.Add((row.TrainingSerialNo, "", $"No beneficiary information found for this serial no. Skipping entire row."));
                    continue;
                }

                var totalMale = 0;
                var totalFemale = 0;
                // Beneficiary
                foreach (var beneficiary in beneficiaryList)
                {
                    if (communityTraining.CommunityTrainingParticipentsMaps is null)
                    {
                        communityTraining.CommunityTrainingParticipentsMaps = new List<CommunityTrainingParticipentsMap>();
                    }

                    beneficiary.BeneficiaryId = beneficiary.BeneficiaryId?.Trim()?.Replace('\u00A0', ' ');
                    beneficiary.BeneficiaryNID = beneficiary.BeneficiaryNID?.Trim()?.Replace('\u00A0', ' ');

                    var survey = await _writeOnlyCtx.Set<Survey>()
                        .Where(x => x.BeneficiaryId == beneficiary.BeneficiaryId || x.BeneficiaryNid == beneficiary.BeneficiaryNID)
                        .FirstOrDefaultAsync();
                    if (survey is null)
                    {
                        skippedList.Add((beneficiary.TrainingSerialNo, beneficiary.BeneficiaryNID, $"No beneficiary with NID ->{beneficiary.BeneficiaryNID}<- or ID ->{beneficiary.BeneficiaryId}<- found for this serial no. Skipping entire row"));
                        continue;
                    }
                    communityTraining.CommunityTrainingParticipentsMaps.Add(new CommunityTrainingParticipentsMap
                    {
                        SurveyId = survey.Id,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = 3,
                        ParticipentType = Common.Enum.Capacity.ParticipentType.Beneficiary,
                    });
                    communityTraining.ForestCircleId = survey.ForestCircleId;
                    communityTraining.ForestDivisionId = survey.ForestDivisionId;
                    communityTraining.ForestRangeId = survey.ForestRangeId;
                    communityTraining.ForestBeatId = survey.ForestBeatId;
                    communityTraining.ForestFcvVcfId = survey.ForestFcvVcfId;
                    communityTraining.DivisionId = survey.PresentDivisionId;
                    communityTraining.DistrictId = survey.PresentDistrictId;
                    communityTraining.UpazillaId = survey.PresentUpazillaId;
                    communityTraining.UnionId = survey.PresentUnionNewId is null ? null : survey.PresentUnionNewId;

                    if (survey.BeneficiaryGender == Gender.Male) totalMale++;
                    if (survey.BeneficiaryGender == Gender.Female) totalFemale++;
                }

                // Other member
                foreach (var otherMember in row.CommunityTrainingBeneficiaryOtherBeneficiaryExcelFormats)
                {
                    if (communityTraining.CommunityTrainingParticipentsMaps is null)
                    {
                        communityTraining.CommunityTrainingParticipentsMaps = new List<CommunityTrainingParticipentsMap>();
                    }

                    communityTraining.CommunityTrainingParticipentsMaps.Add(new CommunityTrainingParticipentsMap
                    {
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = 3,
                        ParticipentType = Common.Enum.Capacity.ParticipentType.Member,
                        CommunityTrainingMember = new CommunityTrainingMember
                        {
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            MemberGender = otherMember.MemberGender,
                            MemberPhoneNumber = otherMember.MemberPhoneNumber?.Trim()?.Replace('\u00A0', ' '),
                            MemberAddress = otherMember.MemberAddress?.Trim()?.Replace('\u00A0', ' '),
                            MemberAge = otherMember.MemberAge ?? 0,
                            MemberName = otherMember.MemberName?.Trim()?.Replace('\u00A0', ' ') ?? string.Empty,
                            MemberNid = otherMember.MemberNid,
                        }
                    });

                    if (otherMember.MemberGender == Gender.Male) totalMale++;
                    if (otherMember.MemberGender == Gender.Female) totalFemale++;
                }

                communityTraining.TotalParticipants = communityTraining.CommunityTrainingParticipentsMaps?.Count ?? 0;
                communityTraining.TotalMale = totalMale;
                communityTraining.TotalFemale = totalFemale;

                communityTrainingList.Add(communityTraining);
            }

            if (shouldMigrate)
            {
                using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
                await _writeOnlyCtx.Set<CommunityTraining>().AddRangeAsync(communityTrainingList);
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
                    Message = ex.Message,
                },
            });
        }
    }
}

public class CommunityTrainingTrainingSheetExcelFormat
{
    [ExcelColumnName(excelColumnName: "SerialNo", aliases: new[] { "TrainingSerialNo", "TrainingSerialNumber", "SerialNumber" })]
    public double TrainingSerialNo { get; set; }

    // Forest Administration
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }

    // Civil Administration
    public string? Division { get; set; }
    public string? District { get; set; }
    public string? Upazilla { get; set; }
    public string? Union { get; set; }

    public string? TrainingTitle { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Location { get; set; }
    public string? TrainerName { get; set; }
    public string? EventType { get; set; }
    public string? CommunityTrainingType { get; set; }
    public string? TrainingOrganizer { get; set; }
    public string? Ngo { get; set; }

    [ExcelIgnore]
    public IEnumerable<CommunityTrainingBeneficiarySheetExcelFormat> CommunityTrainingBeneficiarySheetExcelFormats { get; set; } = Enumerable.Empty<CommunityTrainingBeneficiarySheetExcelFormat>();
    [ExcelIgnore]
    public IEnumerable<CommunityTrainingBeneficiaryOtherBeneficiaryExcelFormat> CommunityTrainingBeneficiaryOtherBeneficiaryExcelFormats { get; set; } = Enumerable.Empty<CommunityTrainingBeneficiaryOtherBeneficiaryExcelFormat>();
}

public class CommunityTrainingBeneficiarySheetExcelFormat
{
    [ExcelColumnName(excelColumnName: "SerialNo", aliases: new[] { "TrainingSerialNo", "TrainingSerialNumber", "SerialNumber" })]
    public double TrainingSerialNo { get; set; }
    public string? BeneficiaryId { get; set; }
    public string? BeneficiaryNID { get; set; }
}

public class CommunityTrainingBeneficiaryOtherBeneficiaryExcelFormat
{
    [ExcelColumnName(excelColumnName: "SerialNo", aliases: new[] { "TrainingSerialNo", "TrainingSerialNumber", "SerialNumber" })]
    public double TrainingSerialNo { get; set; }
    public string? MemberName { get; set; }
    public int? MemberAge { get; set; }
    public string? MemberPhoneNumber { get; set; }
    public string? MemberNid { get; set; }
    public string? MemberAddress { get; set; }
    public Gender MemberGender { get; set; }
}

