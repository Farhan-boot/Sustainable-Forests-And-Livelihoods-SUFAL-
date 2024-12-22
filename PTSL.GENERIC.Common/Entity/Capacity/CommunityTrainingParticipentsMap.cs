using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.Capacity;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class CommunityTrainingParticipentsMap : BaseEntity
    {
        public long? SurveyId { get; set; }
        public Survey? Survey { get; set; }
        public long? CommunityTrainingMemberId { get; set; }
        public CommunityTrainingMember? CommunityTrainingMember { get; set; }
        public ParticipentType ParticipentType { get; set; }

        public long CommunityTrainingId { get; set; }
        public CommunityTraining? CommunityTraining { get; set; }
    }
}
