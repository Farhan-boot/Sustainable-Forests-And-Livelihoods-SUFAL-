using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryTraining;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryTraining
{
    public class EventTypeForTrainingRepository : BaseRepository<EventTypeForTraining>, IEventTypeForTrainingRepository
    {
        public EventTypeForTrainingRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}