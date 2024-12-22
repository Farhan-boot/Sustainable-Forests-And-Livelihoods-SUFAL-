namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class LaborCostTypeVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

  
    public List<LaborInformationVM>? LaborInformation { get; set; }
}
