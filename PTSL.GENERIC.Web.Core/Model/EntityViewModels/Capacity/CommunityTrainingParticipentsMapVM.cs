using PTSL.GENERIC.Web.Core.Helper.Enum.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class CommunityTrainingParticipentsMapVM : BaseModel
    {
        public long? SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
        public long? CommunityTrainingMemberId { get; set; }
        public CommunityTrainingMemberVM? CommunityTrainingMember { get; set; }
        public ParticipentType ParticipentType { get; set; }
        public string ParticipentTypeString { get; set; } = string.Empty;

        public long CommunityTrainingId { get; set; }
        public CommunityTrainingVM? CommunityTraining { get; set; }
    }
}
