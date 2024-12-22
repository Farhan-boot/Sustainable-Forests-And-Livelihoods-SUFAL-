using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.DAL.Repositories.Interface.ApprovalLog;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.ApprovalLog
{
    public class ApprovalLogForCfmRepository : BaseRepository<ApprovalLogForCfm>, IApprovalLogForCfmRepository
    {
        public ApprovalLogForCfmRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}