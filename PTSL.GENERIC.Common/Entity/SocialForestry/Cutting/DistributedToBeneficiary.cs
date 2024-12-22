using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

public class DistributedToBeneficiary : BaseEntity
{
    public long ShareDistributionId { get; set; }
    public ShareDistribution? ShareDistribution { get; set; }

    public long SocialForestryBeneficiaryId { get; set; }
    public SocialForestryBeneficiary? SocialForestryBeneficiary { get; set; }

    public double DepositedRevenueAmount { get; set; }
}
