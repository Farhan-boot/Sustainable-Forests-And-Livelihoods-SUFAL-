namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class NgoVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<long>? ForestCircleIdList { get; set; }
    public List<long>? ForestDivisionIdList { get; set; }
    public List<ForestCircleVM>? ForestCircles { get; set; }
    public List<ForestDivisionVM>? ForestDivisions { get; set; }
}