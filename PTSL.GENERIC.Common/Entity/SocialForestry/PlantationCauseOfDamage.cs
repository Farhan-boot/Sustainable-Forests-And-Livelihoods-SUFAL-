using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class PlantationCauseOfDamage : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public List<PlantationDamageInformation>? PlantationDamageInformation { get; set; }
}
