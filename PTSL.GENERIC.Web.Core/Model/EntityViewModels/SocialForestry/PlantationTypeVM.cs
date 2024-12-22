using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class PlantationTypeVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<NewRaisedPlantationVM>? NewRaisedPlantations { get; set; }
    public List<DistributionPercentageVM>? DistributionPercentages { get; set; }
}
