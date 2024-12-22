using PTSL.GENERIC.Web.Core.Helper.Enum.Capacity;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Entity.MeetingManagement
{
	public class MeetingParticipantsMapVM : BaseModel
	{
		public long? SurveyId { get; set; } = null;
        public SurveyVM? Survey { get; set; }
		public long? MeetingMemberId { get; set; } = null;
		public MeetingMemberVM? MeetingMember { get; set; }

        public ParticipentType? ParticipentType { get; set; }

		public long MeetingId { get; set; }
		public MeetingVM? Meeting { get; set; }
	}
}
