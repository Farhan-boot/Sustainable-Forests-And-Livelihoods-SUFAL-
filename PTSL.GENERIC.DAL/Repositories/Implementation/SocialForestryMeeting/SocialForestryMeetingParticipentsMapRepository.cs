using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryMeeting;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryMeeting
{
    public class  SocialForestryMeetingParticipentsMapRepository : BaseRepository< SocialForestryMeetingParticipentsMap>, ISocialForestryMeetingParticipentsMapRepository
    {
        public  SocialForestryMeetingParticipentsMapRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}