using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class SavingsAmountInformationRepository : BaseRepository<SavingsAmountInformation>, ISavingsAmountInformationRepository
    {
        public SavingsAmountInformationRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
