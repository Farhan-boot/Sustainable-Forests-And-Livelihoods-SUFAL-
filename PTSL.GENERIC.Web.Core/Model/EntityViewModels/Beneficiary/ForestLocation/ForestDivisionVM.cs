namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class ForestDivisionVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public long ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public List<ForestRangeVM>? ForestRanges { get; set; }
    public List<SurveyVM>? Surveys { get; set; }

    public NgoVM? Ngo { get; set; }
}