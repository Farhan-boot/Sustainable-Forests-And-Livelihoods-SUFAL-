using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.Capacity;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
    public class MeetingParticipantsMap : BaseEntity
	{
        public long? SurveyId { get; set; }
        public Survey? Survey { get; set; }
		public long? MeetingMemberId { get; set; }
		public MeetingMember? MeetingMember { get; set; }

        public ParticipentType ParticipentType { get; set; }

		public long MeetingId { get; set; }
		public Meeting? Meeting { get; set; }
	}
}
