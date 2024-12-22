using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

public class DistributionFundTypeVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public DistributionFundTypeEnum DistributionFundTypeEnum { get; set; }

    [SwaggerExclude]
    public List<DistributionPercentageVM>? DistributionPercentages { get; set; }
}
