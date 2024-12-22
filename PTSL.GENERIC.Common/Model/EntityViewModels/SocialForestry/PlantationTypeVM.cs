using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class PlantationTypeVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    [SwaggerExclude]
    public List<NewRaisedPlantationVM>? NewRaisedPlantations { get; set; }
    [SwaggerExclude]
    public List<DistributionPercentageVM>? DistributionPercentages { get; set; }
}
