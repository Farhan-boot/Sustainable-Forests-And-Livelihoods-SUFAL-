namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class CostTypeVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;
    public string LabelName { get; set; } = string.Empty;
    public string LabelNameBn { get; set; } = string.Empty;

    public List<CostInformationVM>? CostInformation { get; set; }
}
