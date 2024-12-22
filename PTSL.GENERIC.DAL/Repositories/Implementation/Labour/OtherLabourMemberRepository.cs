using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Labour;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class OtherLabourMemberRepository : BaseRepository<OtherLabourMember>, IOtherLabourMemberRepository
    {
        public OtherLabourMemberRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
