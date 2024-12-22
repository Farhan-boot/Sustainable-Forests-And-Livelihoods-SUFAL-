using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.SocialForestry;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class PlantationUnit : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public UnitType UnitType { get; set; }

    public List<NewRaisedPlantation>? NewRaisedPlantations { get; set; }
}
