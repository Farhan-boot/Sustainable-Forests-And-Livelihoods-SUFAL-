using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingMemberVM : BaseModel
    {
        public string MemberName { get; set; } = string.Empty;
        public int MemberAge { get; set; }
        public Gender MemberGender { get; set; }
        public string? MemberPhoneNumber { get; set; }
        public string? MemberAddress { get; set; }
        public List<PatrollingSchedulingParticipentsMapVM>? PatrollingSchedulingParticipentsMaps { get; set; }
    }
}
