using System;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

public class ShareDistributionVM : BaseModel
{
    public long CuttingPlantationId { get; set; }
    public CuttingPlantationVM? CuttingPlantation { get; set; }

    public long DistributionFundTypeId { get; set; }
    public DistributionFundTypeVM? DistributionFundType { get; set; }

    public double SharePercentage { get; set; }

    public double DepositedRevenueAmount { get; set; }
    public DateTime DepositDate { get; set; }
    public string? Remarks { get; set; }
    public string? DepositFile { get; set; }

    public List<DistributedToBeneficiaryVM>? DistributedToBeneficiary { get; set; }
}
