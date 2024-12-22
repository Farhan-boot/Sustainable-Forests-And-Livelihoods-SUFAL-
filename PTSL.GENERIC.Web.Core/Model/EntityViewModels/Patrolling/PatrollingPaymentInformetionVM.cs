using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling
{
    public class PatrollingPaymentInformetionVM : BaseModel
    {
        public long? PatrollingScheduleInformetionId { get; set; }
        public PatrollingScheduleInformetionVM? PatrollingScheduleInformetions { get; set; }
        public long? SurveyId { get; set; }
        public SurveyVM? Surveys { get; set; }
        public long? OtherPatrollingMemberId { get; set; }
        public OtherPatrollingMemberVM? OtherPatrollingMembers { get; set; }
        public string? ParticipentName { get; set; }
        public long? GenderId { get; set; }
        public string? PhoneNo { get; set; }
        public double? AmountOfHonoraryAllowance { get; set; }
        public string? Remark { get; set; }
    }
}
