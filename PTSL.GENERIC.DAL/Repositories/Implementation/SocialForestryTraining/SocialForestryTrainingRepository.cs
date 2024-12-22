using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryTraining;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryTraining
{
    public class SocialForestryTrainingRepository : BaseRepository<Common.Entity.SocialForestryTraining.SocialForestryTraining>, ISocialForestryTrainingRepository
    {
        public SocialForestryTrainingRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}