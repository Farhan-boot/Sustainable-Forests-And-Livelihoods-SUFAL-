using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class SocialForestryBeneficiaryVM : BaseModel
{
    public string BeneficiaryName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string? NID { get; set; } = string.Empty;
    public string? MobileNumber { get; set; } = string.Empty;
    public long? EthnicityId { get; set; }
    public EthnicityVM? Ethnicity { get; set; }
    public string? Address { get; set; } = string.Empty;

    [SwaggerExclude]
    public List<PlantationSocialForestryBeneficiaryMapVM>? PlantationSocialForestryBeneficiaryMaps { get; set; }
    [SwaggerExclude]
    public List<DistributedToBeneficiaryVM>? DistributedToBeneficiary { get; set; }
}
