using System.ComponentModel.DataAnnotations;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Helper;

namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class SurveyIncident : BaseEntity, IHasSurvey
{
    public long SurveyId { get; set; }
    public Survey? Survey { get; set; }

    [StringLength(maximumLength: 4, MinimumLength = 4)]
    public string? Year { get; set; }

    [Range(1, 12)]
    public Months MonthNo { get; set; }

    public string? Incident { get; set; }
    public string? Decision { get; set; }
    public string? Action { get; set; }

    public SurveyIncidentStatus SurveyIncidentStatus { get; set; }
}

