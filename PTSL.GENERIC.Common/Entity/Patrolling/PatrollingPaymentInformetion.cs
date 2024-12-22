using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Patrolling
{
    public class PatrollingPaymentInformetion : BaseEntity
    {
        public long? PatrollingScheduleInformetionId { get; set; }
        public PatrollingScheduleInformetion? PatrollingScheduleInformetions { get; set; }
        public long? SurveyId { get; set; }
        public Survey? Surveys { get; set; }

        public long? OtherPatrollingMemberId { get; set; }
        public OtherPatrollingMember? OtherPatrollingMembers { get; set; }

        public string? ParticipentName { get; set; }
        public long? GenderId { get; set; }
        public string? PhoneNo { get; set; }
        public double? AmountOfHonoraryAllowance { get; set; }
        public string? Remark { get; set; }
    }
}

