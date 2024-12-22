using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

public class DistributionPercentageVM : BaseModel
{
    public long DistributionFundTypeId { get; set; }
    public DistributionFundTypeVM? DistributionFundType { get; set; }

    public long PlantationTypeId { get; set; }
    public PlantationTypeVM? PlantationType { get; set; }

    public double Percentage { get; set; }
}

public class DistributionPercentageCustomVM
{
    public List<DistributionPercentageVM> DistributionPercentageListVM { get; set; }
}