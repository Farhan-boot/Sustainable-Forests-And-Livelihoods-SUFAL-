using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum.AccountManagement;

namespace PTSL.GENERIC.DAL.Repositories.Interface.AccountManagement
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<bool> IsAccountHasPermissions(long accountId, AccountAllowedFundExpense[] fundExpenses);
    }
}