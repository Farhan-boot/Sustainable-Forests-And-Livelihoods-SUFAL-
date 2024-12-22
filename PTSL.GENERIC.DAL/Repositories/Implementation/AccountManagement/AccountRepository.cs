using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.AccountManagement;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.AccountManagement
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public AccountRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<bool> IsAccountHasPermissions(long accountId, AccountAllowedFundExpense[] fundExpenses)
        {
            var count = await _readOnlyCtx.Set<Account>()
                .Where(x => x.Id == accountId)
                .Where(x => x.AccountAllowedFundExpenses.All(x => fundExpenses.Contains(x)))
                .CountAsync();

            return count == 1;
        }
    }
}