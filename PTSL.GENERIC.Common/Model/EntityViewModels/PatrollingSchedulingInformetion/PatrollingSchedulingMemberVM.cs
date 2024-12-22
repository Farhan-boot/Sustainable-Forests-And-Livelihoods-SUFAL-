using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingMemberVM : BaseModel
    {
        public string MemberName { get; set; } = string.Empty;
        public int MemberAge { get; set; }
        public Gender MemberGender { get; set; }
        public string? MemberPhoneNumber { get; set; }
        public string? MemberAddress { get; set; }
        [SwaggerExclude]
        public List<PatrollingSchedulingParticipentsMapVM>? PatrollingSchedulingParticipentsMaps { get; set; }
    }
}
