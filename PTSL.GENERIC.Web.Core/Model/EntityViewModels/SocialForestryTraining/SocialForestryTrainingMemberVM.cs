using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

public class SocialForestryTrainingMemberVM : BaseModel
{
    public string MemberName { get; set; } = string.Empty;
    public Gender MemberGender { get; set; }
    public string? MemberPhoneNumber { get; set; }
    public string? MemberNID { get; set; }
    public string? MemberDesignation { get; set; }
    public string? MemberOrganization { get; set; }

    public long? EthnicityId { get; set; }
    public EthnicityVM? Ethnicity { get; set; }

    public string? MemberAddress { get; set; }

    public long? PlantationId { get; set; }
    public string? PlantationName { get; set; }

    public List<SocialForestryTrainingParticipentsMapVM>? SocialForestryTrainingParticipentsMaps { get; set; }
}

