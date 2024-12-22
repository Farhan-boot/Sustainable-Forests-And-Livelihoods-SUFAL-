namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class EthnicityVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<SurveyVM>? Surveys { get; set; }
}