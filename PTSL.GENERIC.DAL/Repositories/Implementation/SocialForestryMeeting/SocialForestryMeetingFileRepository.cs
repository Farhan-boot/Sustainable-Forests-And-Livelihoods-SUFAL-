using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryMeeting;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryMeeting
{
    public class  SocialForestryMeetingFileRepository : BaseRepository< SocialForestryMeetingFile>, ISocialForestryMeetingFileRepository
    {
        public  SocialForestryMeetingFileRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}