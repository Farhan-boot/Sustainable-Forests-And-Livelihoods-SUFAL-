using PTSL.GENERIC.Common.Enum.SocialForestry;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

public class DefaultDistributionDataVM
{
    public long CuttingPlantationId { get; set; }
    public long NewRaisedPlantationId { get; set; }
    public string PlantationId { get; set; } = string.Empty;

    public double TotalAmountOfShareToBeDistributed { get; set; }
    public double TotalUndistributedAmount { get; set; }
    public double TotalCurrentDistributedAmount { get; set; }

    public List<DefaultDistributionFund> DefaultDistributionFunds { get; set; } = new List<DefaultDistributionFund>();
}

public class DefaultDistributionFund
{
    public long DistributionFundTypeId { get; set; }
    public string FundTypeName { get; set; } = string.Empty;
    public DistributionFundTypeEnum DistributionFundTypeEnum { get; set; }
    public double Percentage { get; set; }

    public double TotalAmountOfShareToBeDistributed { get; set; }
    public double TotalUndistributedAmount { get; set; }
    public double TotalCurrentDistributedAmount { get; set; }
}
