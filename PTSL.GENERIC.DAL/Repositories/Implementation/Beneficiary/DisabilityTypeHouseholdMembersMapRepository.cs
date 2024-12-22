using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class DisabilityTypeHouseholdMembersMapRepository : BaseRepository<DisabilityTypeHouseholdMembersMap>, IDisabilityTypeHouseholdMembersMapRepository
    {
        public DisabilityTypeHouseholdMembersMapRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
