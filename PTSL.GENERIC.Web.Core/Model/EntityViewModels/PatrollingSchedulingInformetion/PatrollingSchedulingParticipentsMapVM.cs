using PTSL.GENERIC.Web.Core.Helper.Enum.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingParticipentsMapVM : BaseModel
    {
        public long? SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
        public long? PatrollingSchedulingMemberId { get; set; }
        public PatrollingSchedulingMemberVM? PatrollingSchedulingMember { get; set; }
        public ParticipentType ParticipentType { get; set; }
        public long PatrollingSchedulingId { get; set; }
       
        public PatrollingSchedulingVM? PatrollingScheduling { get; set; }

        //Others
        public string? ParticipentName { get; set; }
        public Helper.Enum.Gender? GenderEnumId { get; set; }
        public string? PhoneNo { get; set; }
        public double? AmountOfHonoraryAllowance { get; set; }
        public string? Remark { get; set; }
    }
}
