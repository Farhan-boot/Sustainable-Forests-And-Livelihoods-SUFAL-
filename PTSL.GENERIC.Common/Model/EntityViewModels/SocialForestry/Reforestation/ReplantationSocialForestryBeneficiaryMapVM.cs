using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

public class ReplantationSocialForestryBeneficiaryMapVM : BaseModel
{
    public long SocialForestryBeneficiaryId { get; set; }
    public SocialForestryBeneficiaryVM? SocialForestryBeneficiary { get; set; }

    public long ReplantationId { get; set; }
    public ReplantationVM? Replantation { get; set; }

    public string PBSAGroupId { get; set; } = string.Empty;
    public bool CheckIfPBSAIsSigned { get; set; }
    public string AgreementUploadFileUrl { get; set; } = string.Empty;
}
