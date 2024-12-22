using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
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
