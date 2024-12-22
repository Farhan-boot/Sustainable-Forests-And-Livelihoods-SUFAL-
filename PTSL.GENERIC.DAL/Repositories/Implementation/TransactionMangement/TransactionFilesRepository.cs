using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.DAL.Repositories.Interface.TransactionMangement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.TransactionMangement
{
    public class TransactionFilesRepository : BaseRepository<TransactionFiles>, ITransactionFilesRepository
    {
        public TransactionFilesRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}