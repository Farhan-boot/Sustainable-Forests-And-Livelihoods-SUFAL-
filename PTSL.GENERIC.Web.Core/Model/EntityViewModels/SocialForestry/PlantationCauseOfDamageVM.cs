namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class PlantationCauseOfDamageVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public List<PlantationDamageInformationVM>? PlantationDamageInformation { get; set; }
}
