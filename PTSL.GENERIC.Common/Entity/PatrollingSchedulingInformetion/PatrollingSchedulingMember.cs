using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingMember : BaseEntity
    {
        public string MemberName { get; set; } = string.Empty;
        public int MemberAge { get; set; }
        public Gender MemberGender { get; set; }
        public string? MemberPhoneNumber { get; set; }
        public string? MemberAddress { get; set; }

        public List<PatrollingSchedulingParticipentsMap>? PatrollingSchedulingParticipentsMaps { get; set; }
    }
}
