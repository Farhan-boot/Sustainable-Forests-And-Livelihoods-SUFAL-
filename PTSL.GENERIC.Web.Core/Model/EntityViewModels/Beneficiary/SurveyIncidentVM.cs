using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class SurveyIncidentVM : BaseModel
{
    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }

    public string? Year { get; set; }
    public Months MonthNo { get; set; }
    public string? Month { get; set; }

    public string? Incident { get; set; }
    public string? Decision { get; set; }
    public string? Action { get; set; }

    public SurveyIncidentStatus SurveyIncidentStatus { get; set; }
    public string? SurveyIncidentStatusString { get; set; }
}

