using PTSL.GENERIC.Web.Core.Helper.Enum.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

public class DistributionFundTypeVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public DistributionFundTypeEnum DistributionFundTypeEnum { get; set; }

    public List<DistributionPercentageVM>? DistributionPercentages { get; set; }
}
