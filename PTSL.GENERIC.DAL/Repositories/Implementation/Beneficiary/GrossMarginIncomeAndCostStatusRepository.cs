using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class GrossMarginIncomeAndCostStatusRepository : BaseRepository<GrossMarginIncomeAndCostStatus>, IGrossMarginIncomeAndCostStatusRepository
    {
        public GrossMarginIncomeAndCostStatusRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
