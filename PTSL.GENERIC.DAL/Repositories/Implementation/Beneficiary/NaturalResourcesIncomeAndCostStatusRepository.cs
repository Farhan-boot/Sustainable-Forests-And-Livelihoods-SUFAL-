using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class NaturalResourcesIncomeAndCostStatusRepository : BaseRepository<NaturalResourcesIncomeAndCostStatus>, INaturalResourcesIncomeAndCostStatusRepository
    {
        public NaturalResourcesIncomeAndCostStatusRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
