namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting
{
    public class SocialForestryMeetingParticipentsMapVM : BaseModel
    {
        public long SocialForestryMeetingMemberId { get; set; }
        public SocialForestryMeetingMemberVM? SocialForestryMeetingMember { get; set; }
        public long SocialForestryMeetingId { get; set; }
        public SocialForestryMeetingVM? SocialForestryMeeting { get; set; }
    }
}
