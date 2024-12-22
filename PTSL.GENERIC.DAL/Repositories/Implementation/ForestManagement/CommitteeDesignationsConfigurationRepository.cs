using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.ForestManagement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.ForestManagement
{
    public class CommitteeDesignationsConfigurationRepository : BaseRepository<CommitteeDesignationsConfiguration>, ICommitteeDesignationsConfigurationRepository
    {
        public CommitteeDesignationsConfigurationRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}