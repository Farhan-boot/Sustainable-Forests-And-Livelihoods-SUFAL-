using PTSL.GENERIC.Web.Core.Helper.Enum.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class PlantationUnitVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public UnitType UnitType { get; set; }

    public List<NewRaisedPlantationVM>? NewRaisedPlantations { get; set; }
}
