namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

public class DistributedToBeneficiaryVM : BaseModel
{
    public long ShareDistributionId { get; set; }
    public ShareDistributionVM? ShareDistribution { get; set; }

    public long SocialForestryBeneficiaryId { get; set; }
    public SocialForestryBeneficiaryVM? SocialForestryBeneficiary { get; set; }

    public double DepositedRevenueAmount { get; set; }
}
