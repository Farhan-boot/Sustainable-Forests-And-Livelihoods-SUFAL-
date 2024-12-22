using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.SocialForestry;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

public class DistributionFundType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public DistributionFundTypeEnum DistributionFundTypeEnum { get; set; }

    public List<DistributionPercentage>? DistributionPercentages { get; set; }
}
