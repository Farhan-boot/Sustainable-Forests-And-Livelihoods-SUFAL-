using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestryTraining;

public class SocialForestryTrainingMember : BaseEntity
{
    public string MemberName { get; set; } = string.Empty;
    public Gender MemberGender { get; set; }
    public string? MemberPhoneNumber { get; set; }
    public string? MemberNID { get; set; }
    public string? MemberDesignation { get; set; }
    public string? MemberOrganization { get; set; }

    public long? EthnicityId { get; set; }
    public Ethnicity? Ethnicity { get; set; }

    public string? MemberAddress { get; set; }

    public long? PlantationId { get; set; }
    public string? PlantationName { get; set; }

    public List<SocialForestryTrainingParticipentsMap>? SocialForestryTrainingParticipentsMaps { get; set; }
}

