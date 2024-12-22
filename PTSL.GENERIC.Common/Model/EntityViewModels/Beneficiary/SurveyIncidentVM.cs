using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class SurveyIncidentVM : BaseModel
{
    public long SurveyId { get; set; }
    [SwaggerExclude]
    public SurveyVM? Survey { get; set; }

    public string? Year { get; set; }
    public Months MonthNo { get; set; }
    public string Month => MonthNo.ToString();

    public string? Incident { get; set; }
    public string? Decision { get; set; }
    public string? Action { get; set; }

    public SurveyIncidentStatus SurveyIncidentStatus { get; set; }
    public string SurveyIncidentStatusString => this.SurveyIncidentStatus.ToString();
}

