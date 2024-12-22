using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class PlantationSocialForestryBeneficiaryMapVM : BaseModel
{
    public long SocialForestryBeneficiaryId { get; set; }
    public SocialForestryBeneficiaryVM? SocialForestryBeneficiary { get; set; }

    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public string? PBSAGroupId { get; set; }
    public bool CheckIfPBSAIsSigned { get; set; }
    public string? AgreementUploadFileUrl { get; set; } = string.Empty;
}
