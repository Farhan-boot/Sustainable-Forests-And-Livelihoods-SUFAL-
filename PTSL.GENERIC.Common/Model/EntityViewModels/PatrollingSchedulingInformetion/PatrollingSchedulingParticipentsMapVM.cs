using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Enum.Capacity;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingParticipentsMapVM : BaseModel
    {
        public long? SurveyId { get; set; }
        [SwaggerExclude]
        public Survey? Survey { get; set; }
        public long? PatrollingSchedulingMemberId { get; set; }
        [SwaggerExclude]
        public PatrollingSchedulingMember? PatrollingSchedulingMember { get; set; }
        [SwaggerExclude]
        public ParticipentType ParticipentType { get; set; }
        public long PatrollingSchedulingId { get; set; }
        [SwaggerExclude]
        public PatrollingScheduling? PatrollingScheduling { get; set; }

        //Others
        public string? ParticipentName { get; set; }
        public Enum.Gender? GenderEnumId { get; set; }
        public string? PhoneNo { get; set; }
        public double? AmountOfHonoraryAllowance { get; set; }
        public string? Remark { get; set; }
    }
}
