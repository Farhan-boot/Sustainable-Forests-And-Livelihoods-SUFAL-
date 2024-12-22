using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.CipManagement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.CipManagement
{
    public class CipTeamRepository : BaseRepository<CipTeam>, ICipTeamRepository
    {
        public CipTeamRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}