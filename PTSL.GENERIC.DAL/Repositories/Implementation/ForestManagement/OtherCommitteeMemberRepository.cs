using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.ForestManagement;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class OtherCommitteeMemberRepository : BaseRepository<OtherCommitteeMember>, IOtherCommitteeMemberRepository
    {
        public OtherCommitteeMemberRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
