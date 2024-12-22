using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryMeeting;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryMeeting
{
    public class SocialForestryMeetingMemberRepository : BaseRepository<SocialForestryMeetingMember>, ISocialForestryMeetingMemberRepository
    {
        public SocialForestryMeetingMemberRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}