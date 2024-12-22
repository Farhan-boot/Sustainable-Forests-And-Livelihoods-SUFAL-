using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.DAL.Repositories.Interface.AIG;
using PTSL.GENERIC.DAL.Repositories.Interface.InternalLoan;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.InternalLoan
{
    public class InternalLoanInformationRepository : BaseRepository<InternalLoanInformation>, IInternalLoanInformationRepository
    {
        public InternalLoanInformationRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}