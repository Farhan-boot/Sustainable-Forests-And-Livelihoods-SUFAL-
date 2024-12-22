using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class AnnualHouseholdExpenditureRepository : BaseRepository<AnnualHouseholdExpenditure>, IAnnualHouseholdExpenditureRepository
    {
        public AnnualHouseholdExpenditureRepository(
            GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
            GENERICReadOnlyCtx ecommarceReadOnlyCtx)
            : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
    }
}
