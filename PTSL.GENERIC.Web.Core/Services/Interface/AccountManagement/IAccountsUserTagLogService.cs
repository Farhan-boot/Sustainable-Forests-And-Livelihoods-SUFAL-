using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement
{
    public interface IAccountsUserTagLogService
    {
        (ExecutionState executionState, List<AccountsUserTagLogVM> entity, string message) List();
        (ExecutionState executionState, AccountsUserTagLogVM entity, string message) Create(AccountsUserTagLogVM model);
        (ExecutionState executionState, AccountsUserTagLogVM entity, string message) GetById(long? id);
        (ExecutionState executionState, AccountsUserTagLogVM entity, string message) Update(AccountsUserTagLogVM model);
        (ExecutionState executionState, AccountsUserTagLogVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<AccountsUserTagLogVM> entity, string message) GetAccountsUserTagLogsByAccountId(long accountId);
    }
}