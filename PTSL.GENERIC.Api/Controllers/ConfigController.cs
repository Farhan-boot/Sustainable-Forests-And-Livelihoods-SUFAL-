using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Api.Controllers;

[ApiController]
public class ConfigController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly GENERICWriteOnlyCtx _readOnlyCtx;

    public ConfigController(IConfiguration configuration, GENERICWriteOnlyCtx readOnlyCtx)
    {
        _configuration = configuration;
        _readOnlyCtx = readOnlyCtx;
    }

    [HttpGet("GetConfigs")]
    public IActionResult GetConfigs()
    {
        return Ok(new Config
        {
            ResourceUrl = _configuration.GetValue<string>("ResourceUrl") ?? string.Empty,
        });
    }

    [HttpGet("TempSetData")]
    public async Task<IActionResult> TempSetData()
    {
        var meetings = await _readOnlyCtx.Set<Meeting>()
            .AsTracking()
            .Include(x => x.MeetingParticipantsMaps).ThenInclude(x => x.MeetingMember)
            .ToListAsync();

        foreach (var entity in meetings)
        {
            var surveyIds = entity.MeetingParticipantsMaps?.Select(x => x.SurveyId).ToList() ?? new List<long?>();
            var surveyGenders = await _readOnlyCtx.Set<Survey>().Where(x => surveyIds.Contains(x.Id)).Select(x => x.BeneficiaryGender).ToListAsync();

            var surveyTotalMale = surveyGenders.Count(x => x == Gender.Male);
            var surveyTotalFemale = surveyGenders.Count(x => x == Gender.Female);
            var otherTotalMale = entity.MeetingParticipantsMaps?.Where(x => x.MeetingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var otherTotalFemale = entity.MeetingParticipantsMaps?.Where(x => x.MeetingMember?.MemberGender == Gender.Female).Count() ?? 0;

            var total = entity.MeetingParticipantsMaps?.Count ?? 0;

            entity.TotalMembers = total;
            entity.TotalMale = otherTotalMale + surveyTotalMale;
            entity.TotalFemale = otherTotalFemale + surveyTotalFemale;
        }

        var patrollings = await _readOnlyCtx.Set<PatrollingScheduling>()
            .AsTracking()
            .Include(x => x.PatrollingSchedulingParticipentsMaps).ThenInclude(x => x.PatrollingSchedulingMember)
            .ToListAsync();

        foreach (var entity in patrollings)
        {
            var surveyIds = entity.PatrollingSchedulingParticipentsMaps?.Select(x => x.SurveyId).ToList() ?? new List<long?>();
            var surveyGenders = await _readOnlyCtx.Set<Survey>().Where(x => surveyIds.Contains(x.Id)).Select(x => x.BeneficiaryGender).ToListAsync();

            var surveyTotalMale = surveyGenders.Count(x => x == Gender.Male);
            var surveyTotalFemale = surveyGenders.Count(x => x == Gender.Female);
            var otherTotalMale = entity.PatrollingSchedulingParticipentsMaps?.Where(x => x.PatrollingSchedulingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var otherTotalFemale = entity.PatrollingSchedulingParticipentsMaps?.Where(x => x.PatrollingSchedulingMember?.MemberGender == Gender.Female).Count() ?? 0;

            var total = entity.PatrollingSchedulingParticipentsMaps?.Count ?? 0;

            entity.TotalParticipants = total;
            entity.TotalMale = otherTotalMale + surveyTotalMale;
            entity.TotalFemale = otherTotalFemale + surveyTotalFemale;
        }

        var community = await _readOnlyCtx.Set<CommunityTraining>()
            .AsTracking()
            .Include(x => x.CommunityTrainingParticipentsMaps).ThenInclude(x => x.CommunityTrainingMember)
            .ToListAsync();

        foreach (var entity in community)
        {
            var surveyIds = entity.CommunityTrainingParticipentsMaps?.Select(x => x.SurveyId).ToList() ?? new List<long?>();
            var surveyGenders = await _readOnlyCtx.Set<Survey>().Where(x => surveyIds.Contains(x.Id)).Select(x => x.BeneficiaryGender).ToListAsync();

            var surveyTotalMale = surveyGenders.Count(x => x == Gender.Male);
            var surveyTotalFemale = surveyGenders.Count(x => x == Gender.Female);
            var otherTotalMale = entity.CommunityTrainingParticipentsMaps?.Where(x => x.CommunityTrainingMember?.MemberGender == Gender.Male).Count() ?? 0;
            var otherTotalFemale = entity.CommunityTrainingParticipentsMaps?.Where(x => x.CommunityTrainingMember?.MemberGender == Gender.Female).Count() ?? 0;

            var total = entity.CommunityTrainingParticipentsMaps?.Count ?? 0;

            entity.TotalParticipants = total;
            entity.TotalMale = otherTotalMale + surveyTotalMale;
            entity.TotalFemale = otherTotalFemale + surveyTotalFemale;
        }

        await _readOnlyCtx.SaveChangesAsync();

        return Ok("Ok");
    }
}

public class Config
{
    public string ResourceUrl { get; set; }
}

