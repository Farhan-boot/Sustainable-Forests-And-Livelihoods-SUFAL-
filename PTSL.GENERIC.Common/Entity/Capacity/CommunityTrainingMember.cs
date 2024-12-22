using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class CommunityTrainingMember : BaseEntity
    {
        public string MemberName { get; set; } = string.Empty;
        public int MemberAge { get; set; }
        public Gender MemberGender { get; set; }
        public string? MemberPhoneNumber { get; set; }
        public string? MemberAddress { get; set; }
        public string? MemberNid { get; set; }

        public List<CommunityTrainingParticipentsMap>? CommunityTrainingParticipentsMaps { get; set; }
    }
}
