using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MiniExcelLibs;
using MiniExcelLibs.Attributes;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Api.Controllers.DataMigrations;

public class MeetingMigrationWeb : ControllerBase
{
    private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

    public MeetingMigrationWeb(GENERICWriteOnlyCtx writeOnlyCtx)
    {
        _writeOnlyCtx = writeOnlyCtx;
    }

    [HttpPost("Meeting-Migration-Web/{shouldMigrate}")]
    public async Task<IActionResult> Migrate([FromRoute] bool shouldMigrate, IFormFile excelFile)
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
            var meetingRows = MiniExcel.Query<MeetingTrainingSheetExcelFormat>(filePath, sheetName: "Training");
            var beneficiaryRows = MiniExcel.Query<MeetingBeneficiarySheetExcelFormat>(filePath, sheetName: "Beneficiary");
            var otherMemberRows = MiniExcel.Query<MeetingBeneficiaryOtherBeneficiaryExcelFormat>(filePath, sheetName: "Other Members");
            var meetingList = new List<Meeting>();
            var skippedList = new List<ValueTuple<double, string?, string>>();

            var meetingRowsList = meetingRows.ToList();
            foreach (var row in meetingRowsList)
            {
                row.MeetingBeneficiarySheetExcelFormats = beneficiaryRows.Where(x => x.SerialNo == row.SerialNo);
                row.MeetingBeneficiaryOtherBeneficiaryExcelFormats = otherMemberRows.Where(x => x.SerialNo == row.SerialNo);
            }

            foreach (var row in meetingRowsList)
            {
                var meeting = new Meeting
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = 3,
                    IsActive = true
                };

                row.MeetingTitle = row.MeetingTitle?.Trim()?.Replace('\u00A0', ' ');
                row.MeetingType = row.MeetingType?.Trim()?.Replace('\u00A0', ' ');
                row.FinancialYear = row.FinancialYear?.Trim()?.Replace('\u00A0', ' ');
                row.Ngo = row.Ngo?.Trim()?.Replace('\u00A0', ' ');

                meeting.MeetingTitle = row.MeetingTitle;
                if (row.MeetingDate is DateTime meetingDate)
                {
                    meeting.MeetingDate = meetingDate;
                }
                if (row.StartTime is DateTime meetingStartTime)
                {
                    meeting.StartTime = meetingStartTime;
                }
                if (row.EndTime is DateTime meetingEndTime)
                {
                    meeting.EndTime = meetingEndTime;
                }

                // Training Organizer
                if (string.IsNullOrEmpty(row.Ngo))
                {
                    skippedList.Add((row.SerialNo, row.Ngo, $"Ngo ->{row.Ngo}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var ngo = await _writeOnlyCtx.Set<Ngo>()
                    .Where(x => x.Name == row.Ngo)
                    .FirstOrDefaultAsync();
                if (ngo is null)
                {
                    skippedList.Add((row.SerialNo, row.Ngo, $"Ngo ->{row.Ngo}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                meeting.NgoId = ngo.Id;

                // Meeting Type
                if (string.IsNullOrEmpty(row.MeetingType))
                {
                    skippedList.Add((row.SerialNo, row.MeetingType, $"MeetingType ->{row.MeetingType}<- can not be empty. Skipping entire row"));
                    continue;
                }
                var meetingType = await _writeOnlyCtx.Set<MeetingType>()
                    .Where(x => x.Name == row.MeetingType)
                    .FirstOrDefaultAsync();
                if (meetingType is null)
                {
                    skippedList.Add((row.SerialNo, row.MeetingType, $"MeetingType ->{row.MeetingType}<- is not found in DB. Skipping entire row"));
                    continue;
                }
                meeting.MeetingTypeId = meetingType.Id;

                var beneficiaryList = row.MeetingBeneficiarySheetExcelFormats.ToList();
                if (beneficiaryList.Count == 0)
                {
                    skippedList.Add((row.SerialNo, "", $"No beneficiary information found for this serial no. Skipping entire row."));
                    continue;
                }

                var totalMale = 0;
                var totalFemale = 0;
                // Beneficiary
                foreach (var beneficiary in beneficiaryList)
                {
                    if (meeting.MeetingParticipantsMaps is null)
                    {
                        meeting.MeetingParticipantsMaps = new List<MeetingParticipantsMap>();
                    }

                    beneficiary.BeneficiaryId = beneficiary.BeneficiaryId?.Trim()?.Replace('\u00A0', ' ');
                    beneficiary.BeneficiaryNID = beneficiary.BeneficiaryNID?.Trim()?.Replace('\u00A0', ' ');

                    var survey = await _writeOnlyCtx.Set<Survey>()
                        .Where(x => x.BeneficiaryNid == beneficiary.BeneficiaryId || x.BeneficiaryNid == beneficiary.BeneficiaryNID)
                        .FirstOrDefaultAsync();
                    if (survey is null)
                    {
                        skippedList.Add((beneficiary.SerialNo, beneficiary.BeneficiaryNID, $"No beneficiary with NID ->{beneficiary.BeneficiaryNID}<- or ID ->{beneficiary.BeneficiaryId}<- found for this serial no. Skipping entire row"));
                        continue;
                    }
                    meeting.MeetingParticipantsMaps.Add(new MeetingParticipantsMap
                    {
                        SurveyId = survey.Id,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = 3,
                        ParticipentType = Common.Enum.Capacity.ParticipentType.Beneficiary,
                    });
                    meeting.ForestCircleId = survey.ForestCircleId;
                    meeting.ForestDivisionId = survey.ForestDivisionId;
                    meeting.ForestRangeId = survey.ForestRangeId;
                    meeting.ForestBeatId = survey.ForestBeatId;
                    meeting.ForestFcvVcfId = survey.ForestFcvVcfId;
                    meeting.DivisionId = survey.PresentDivisionId;
                    meeting.DistrictId = survey.PresentDistrictId;
                    meeting.UpazillaId = survey.PresentUpazillaId;
                    meeting.UnionId = survey.PresentUnionNewId is null ? null : survey.PresentUnionNewId;

                    if (survey.BeneficiaryGender == Gender.Male) totalMale++;
                    if (survey.BeneficiaryGender == Gender.Female) totalFemale++;
                }

                // Other member
                foreach (var otherMember in row.MeetingBeneficiaryOtherBeneficiaryExcelFormats)
                {
                    if (meeting.MeetingParticipantsMaps is null)
                    {
                        meeting.MeetingParticipantsMaps = new List<MeetingParticipantsMap>();
                    }

                    meeting.MeetingParticipantsMaps.Add(new MeetingParticipantsMap
                    {
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = 3,
                        ParticipentType = Common.Enum.Capacity.ParticipentType.Member,
                        MeetingMember = new MeetingMember
                        {
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                            CreatedBy = 3,
                            MemberGender = otherMember.MemberGender,
                            MemberPhone = otherMember.MemberPhoneNumber?.Trim()?.Replace('\u00A0', ' '),
                            MemberAddress = otherMember.MemberAddress?.Trim()?.Replace('\u00A0', ' '),
                            MemberAge = otherMember.MemberAge ?? 0,
                            MemberName = otherMember.MemberName?.Trim()?.Replace('\u00A0', ' ') ?? string.Empty,
                        }
                    });

                    if (otherMember.MemberGender == Gender.Male) totalMale++;
                    if (otherMember.MemberGender == Gender.Female) totalFemale++;
                }

                meeting.TotalMembers = meeting.MeetingParticipantsMaps?.Count ?? 0;
                meeting.TotalMale = totalMale;
                meeting.TotalFemale = totalFemale;

                meetingList.Add(meeting);
            }

            if (shouldMigrate)
            {
                using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();
                await _writeOnlyCtx.Set<Meeting>().AddRangeAsync(meetingList);
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

public class MeetingTrainingSheetExcelFormat
{
    [ExcelColumnName(excelColumnName: "SerialNo", aliases: new[] { "Serial No" })]
    public double SerialNo { get; set; }

    public string? MeetingTitle { get; set; }
    public DateTime? MeetingDate { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? FinancialYear { get; set; }
    public string? MeetingType { get; set; }
    public string? Ngo { get; set; }

    [ExcelIgnore]
    public IEnumerable<MeetingBeneficiarySheetExcelFormat> MeetingBeneficiarySheetExcelFormats { get; set; } = Enumerable.Empty<MeetingBeneficiarySheetExcelFormat>();
    [ExcelIgnore]
    public IEnumerable<MeetingBeneficiaryOtherBeneficiaryExcelFormat> MeetingBeneficiaryOtherBeneficiaryExcelFormats { get; set; } = Enumerable.Empty<MeetingBeneficiaryOtherBeneficiaryExcelFormat>();
}

public class MeetingBeneficiarySheetExcelFormat
{
    [ExcelColumnName(excelColumnName: "SerialNo", aliases: new[] { "Serial No" })]
    public double SerialNo { get; set; }

    [ExcelColumnName(excelColumnName: "BeneficiaryId", aliases: new[] { "BeneficiaryID" })]
    public string? BeneficiaryId { get; set; }

    [ExcelColumnName(excelColumnName: "BeneficiaryNID", aliases: new[] { "BeneficiaryNid" })]
    public string? BeneficiaryNID { get; set; }
}

public class MeetingBeneficiaryOtherBeneficiaryExcelFormat
{
    [ExcelColumnName(excelColumnName: "SerialNo", aliases: new[] { "Serial No" })]
    public double SerialNo { get; set; }
    public string? MemberName { get; set; }
    public int? MemberAge { get; set; }
    public string? MemberPhoneNumber { get; set; }
    public string? MemberNid { get; set; }
    public string? MemberAddress { get; set; }
    public Gender MemberGender { get; set; }
}
