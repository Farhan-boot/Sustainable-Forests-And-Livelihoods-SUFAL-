using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.DAL.Repositories.Interface.AIG;
using PTSL.GENERIC.DAL.Repositories.Interface.InternalLoan;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.InternalLoan
{
    public class RepaymentInternalLoanRepository : BaseRepository<RepaymentInternalLoan>, IRepaymentInternalLoanRepository
    {
        public RepaymentInternalLoanRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}