using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class ManualIncomeSourceTypeRepository : BaseRepository<ManualIncomeSourceType>, IManualIncomeSourceTypeRepository
    {
        public ManualIncomeSourceTypeRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
