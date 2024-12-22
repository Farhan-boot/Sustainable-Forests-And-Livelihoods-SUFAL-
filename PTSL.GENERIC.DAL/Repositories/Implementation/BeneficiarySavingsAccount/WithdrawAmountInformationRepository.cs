using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class WithdrawAmountInformationRepository : BaseRepository<WithdrawAmountInformation>, IWithdrawAmountInformationRepository
    {
        public WithdrawAmountInformationRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
