using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.Capacity;

namespace PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingParticipentsMap : BaseEntity
    {
        public long? SurveyId { get; set; }
        public Survey? Survey { get; set; }
        public long? PatrollingSchedulingMemberId { get; set; }
        public PatrollingSchedulingMember? PatrollingSchedulingMember { get; set; }
        public ParticipentType ParticipentType { get; set; }
        public long PatrollingSchedulingId { get; set; }
        public PatrollingScheduling? PatrollingScheduling { get; set; }

        //Others
        public string? ParticipentName { get; set; }
        public Enum.Gender? GenderEnumId { get; set; }
        public string? PhoneNo { get; set; }
        public double? AmountOfHonoraryAllowance { get; set; }
        public string? Remark { get; set; }

    }
}
