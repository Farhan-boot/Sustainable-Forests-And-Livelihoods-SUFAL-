using PTSL.GENERIC.Common.Enum.Capacity;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity
{
    public class CommunityTrainingParticipentsMapVM : BaseModel
    {
        public long? SurveyId { get; set; }
        [SwaggerExclude] public SurveyVM? Survey { get; set; }
        public long? CommunityTrainingMemberId { get; set; }
        [SwaggerExclude] public CommunityTrainingMemberVM? CommunityTrainingMember { get; set; }
        public ParticipentType? ParticipentType { get; set; }
        public string ParticipentTypeString { get; set; } = string.Empty;

        public long CommunityTrainingId { get; set; }
        [SwaggerExclude] public CommunityTrainingVM? CommunityTraining { get; set; }
    }
}
