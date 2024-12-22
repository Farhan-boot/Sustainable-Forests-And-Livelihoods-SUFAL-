using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.ForestManagement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.ForestManagement
{
    public class CommitteeManagementRepository : BaseRepository<CommitteeManagement>, ICommitteeManagementRepository
    {
        public CommitteeManagementRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}