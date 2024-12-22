using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public interface IAccountsUserTagLogService : IBaseService<AccountsUserTagLogVM, AccountsUserTagLog>
    {
        Task<(ExecutionState executionState, List<AccountsUserTagLogVM> entity, string message)> GetAccountsUserTagLogsByAccountId(long accountId);
    }
}