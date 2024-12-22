using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class CostType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;
    public string LabelName { get; set; } = string.Empty;
    public string LabelNameBn { get; set; } = string.Empty;

    public List<CostInformation>? CostInformation { get; set; }
    public List<ReplantationCostInfo>? ReplantationCostInfos { get; set; }
}
