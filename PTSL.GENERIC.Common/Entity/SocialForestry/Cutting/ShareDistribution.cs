using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;

public class ShareDistribution : BaseEntity
{
    public long CuttingPlantationId { get; set; }
    public CuttingPlantation? CuttingPlantation { get; set; }

    public long DistributionFundTypeId { get; set; }
    public DistributionFundType? DistributionFundType { get; set; }

    public double SharePercentage { get; set; }

    public double DepositedRevenueAmount { get; set; }
    public DateTime DepositDate { get; set; }
    public string? Remarks { get; set; }
    public string? DepositFile { get; set; }

    public List<DistributedToBeneficiary>? DistributedToBeneficiary { get; set; }
}
