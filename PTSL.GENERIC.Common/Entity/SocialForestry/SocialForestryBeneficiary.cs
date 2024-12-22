using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class SocialForestryBeneficiary : BaseEntity
{
    public string BeneficiaryName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string? NID { get; set; } = string.Empty;
    public string? MobileNumber { get; set; } = string.Empty;
    public long? EthnicityId { get; set; }
    public Ethnicity? Ethnicity { get; set; }
    public string? Address { get; set; } = string.Empty;

    public List<PlantationSocialForestryBeneficiaryMap>? PlantationSocialForestryBeneficiaryMaps { get; set; }
    public List<ReplantationSocialForestryBeneficiaryMap>? ReplantationSocialForestryBeneficiaryMaps { get; set; }
    public List<DistributedToBeneficiary>? DistributedToBeneficiary { get; set; }
}
