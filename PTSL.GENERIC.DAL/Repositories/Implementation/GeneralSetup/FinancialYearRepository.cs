using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.DAL.Repositories.Interface.GeneralSetup;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.GeneralSetup
{
    public class FinancialYearRepository : BaseRepository<FinancialYear>, IFinancialYearRepository
    {
        public FinancialYearRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
