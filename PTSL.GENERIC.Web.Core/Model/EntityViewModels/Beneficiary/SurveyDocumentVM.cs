namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class SurveyDocumentVM : BaseModel
{
    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }

    public string? DocumentName { get; set; }
    public string? DocumentNameURL { get; set; }
}
