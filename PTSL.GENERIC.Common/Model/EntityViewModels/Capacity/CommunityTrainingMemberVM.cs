using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity
{
    public class CommunityTrainingMemberVM : BaseModel
    {
        public string MemberName { get; set; } = string.Empty;
        public int MemberAge { get; set; }
        public Gender MemberGender { get; set; }
        public string? MemberPhoneNumber { get; set; }
        public string? MemberAddress { get; set; }
        public string? MemberNid { get; set; }

        public List<CommunityTrainingParticipentsMapVM>? CommunityTrainingParticipentsMaps { get; set; }
    }
}
