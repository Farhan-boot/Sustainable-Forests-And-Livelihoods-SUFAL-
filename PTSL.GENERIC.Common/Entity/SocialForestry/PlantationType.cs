using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class PlantationType : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<NewRaisedPlantation>? NewRaisedPlantations { get; set; }
    public List<DistributionPercentage>? DistributionPercentages { get; set; }
}
