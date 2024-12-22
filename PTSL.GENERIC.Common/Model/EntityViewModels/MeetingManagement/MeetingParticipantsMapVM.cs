using PTSL.GENERIC.Common.Enum.Capacity;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
	public class MeetingParticipantsMapVM : BaseModel
	{
        public long? SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
		public long? MeetingMemberId { get; set; }
		public MeetingMemberVM? MeetingMember { get; set; }

        public ParticipentType? ParticipentType { get; set; }

		public long MeetingId { get; set; }
		public MeetingVM? Meeting { get; set; }
	}
}
