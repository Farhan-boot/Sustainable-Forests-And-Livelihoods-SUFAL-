using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryTraining;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryTraining
{
    public class SocialForestryTrainingMemberRepository : BaseRepository<SocialForestryTrainingMember>, ISocialForestryTrainingMemberRepository
    {
        public SocialForestryTrainingMemberRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}