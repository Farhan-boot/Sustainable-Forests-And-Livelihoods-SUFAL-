using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

public class DistributedToBeneficiaryVM : BaseModel
{
    public long ShareDistributionId { get; set; }
    [SwaggerExclude]
    public ShareDistributionVM? ShareDistribution { get; set; }

    public long SocialForestryBeneficiaryId { get; set; }
    [SwaggerExclude]
    public SocialForestryBeneficiaryVM? SocialForestryBeneficiary { get; set; }

    public double DepositedRevenueAmount { get; set; }
}
