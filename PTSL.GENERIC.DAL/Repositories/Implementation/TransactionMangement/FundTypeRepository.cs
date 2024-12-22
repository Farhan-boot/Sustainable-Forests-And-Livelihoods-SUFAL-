using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.DAL.Repositories.Interface.TransactionMangement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.TransactionMangement
{
    public class FundTypeRepository : BaseRepository<FundType>, IFundTypeRepository
    {
        public FundTypeRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
