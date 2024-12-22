using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Patrolling;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class OtherPatrollingMemberRepository : BaseRepository<OtherPatrollingMember>, IOtherPatrollingMemberRepository
    {
        public OtherPatrollingMemberRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
