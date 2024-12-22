using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryMeeting;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryMeeting
{
    public class MeetingTypeForSocialForestryMeetingRepository : BaseRepository<MeetingTypeForSocialForestryMeeting>, IMeetingTypeForSocialForestryMeetingRepository
    {
        public MeetingTypeForSocialForestryMeetingRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}