using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class PlantationSocialForestryBeneficiaryMap : BaseEntity
{
    public long SocialForestryBeneficiaryId { get; set; }
    public SocialForestryBeneficiary? SocialForestryBeneficiary { get; set; }

    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }

    public string? PBSAGroupId { get; set; }
    public bool CheckIfPBSAIsSigned { get; set; }
    public string? AgreementUploadFileUrl { get; set; } = string.Empty;
}
