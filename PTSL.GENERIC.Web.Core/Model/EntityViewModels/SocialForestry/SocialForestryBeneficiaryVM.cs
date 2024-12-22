using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class SocialForestryBeneficiaryVM : BaseModel
{
    public string BeneficiaryName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string? NID { get; set; } = string.Empty;
    public string? MobileNumber { get; set; } = string.Empty;
    public long? EthnicityId { get; set; }
    public EthnicityVM? Ethnicity { get; set; }
    public string? Address { get; set; } = string.Empty;

    public List<PlantationSocialForestryBeneficiaryMapVM>? PlantationSocialForestryBeneficiaryMaps { get; set; }
    public List<DistributedToBeneficiaryVM>? DistributedToBeneficiary { get; set; }
}
