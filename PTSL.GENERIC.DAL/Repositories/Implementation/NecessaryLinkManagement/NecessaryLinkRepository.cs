using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.NecessaryLinkManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.NecessaryLinkManagement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.NecessaryLinkManagement
{
    public class NecessaryLinkRepository : BaseRepository<NecessaryLink>, INecessaryLinkRepository
    {
        public NecessaryLinkRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}