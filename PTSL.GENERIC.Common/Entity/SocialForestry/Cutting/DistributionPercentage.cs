using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

public class DistributionPercentage : BaseEntity
{
    public long DistributionFundTypeId { get; set; }
    public DistributionFundType? DistributionFundType { get; set; }

    public long PlantationTypeId { get; set; }
    public PlantationType? PlantationType { get; set; }

    public double Percentage { get; set; }
}
