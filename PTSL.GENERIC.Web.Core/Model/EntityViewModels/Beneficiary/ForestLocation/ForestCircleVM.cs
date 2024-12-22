namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class ForestCircleVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<ForestDivisionVM>? ForestDivisions { get; set; }
    public List<SurveyVM>? Surveys { get; set; }
}