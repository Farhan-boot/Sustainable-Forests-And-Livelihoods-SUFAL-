using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.AccountManagement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.AccountManagement
{
    public class AccountsUserTagLogRepository : BaseRepository<AccountsUserTagLog>, IAccountsUserTagLogRepository
    {
        public AccountsUserTagLogRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}