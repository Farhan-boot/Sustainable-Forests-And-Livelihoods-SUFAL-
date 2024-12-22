using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.DAL.Repositories.Interface.TransactionMangement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.TransactionMangement
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
