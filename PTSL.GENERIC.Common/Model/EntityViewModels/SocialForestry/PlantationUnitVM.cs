using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class PlantationUnitVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public UnitType UnitType { get; set; }

    [SwaggerExclude]
    public List<NewRaisedPlantationVM>? NewRaisedPlantations { get; set; }
}
