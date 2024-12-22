using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.DAL.Repositories.Interface.Capacity;
using PTSL.GENERIC.DAL.Repositories.Interface.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingRepository : BaseRepository<PatrollingScheduling>, IPatrollingSchedulingRepository
    {
        public PatrollingSchedulingRepository(
            GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
            GENERICReadOnlyCtx ecommarceReadOnlyCtx)
            : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
    }
}

