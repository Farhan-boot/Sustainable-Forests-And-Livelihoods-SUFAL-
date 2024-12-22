using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

public class ReplantationSocialForestryBeneficiaryMap : BaseEntity
{
    public long SocialForestryBeneficiaryId { get; set; }
    public SocialForestryBeneficiary? SocialForestryBeneficiary { get; set; }

    public long ReplantationId { get; set; }
    public Replantation? Replantation { get; set; }

    public string PBSAGroupId { get; set; } = string.Empty;
    public bool CheckIfPBSAIsSigned { get; set; }
    public string AgreementUploadFileUrl { get; set; } = string.Empty;
}
