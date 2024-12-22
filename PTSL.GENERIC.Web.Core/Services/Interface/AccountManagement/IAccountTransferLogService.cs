using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement
{
    public interface IAccountTransferLogService
    {
        (ExecutionState executionState, List<AccountTransferLogVM> entity, string message) List();
        (ExecutionState executionState, AccountTransferLogVM entity, string message) Create(AccountTransferLogVM model);
        (ExecutionState executionState, AccountTransferLogVM entity, string message) GetById(long? id);
        (ExecutionState executionState, AccountTransferLogVM entity, string message) Update(AccountTransferLogVM model);
        (ExecutionState executionState, AccountTransferLogVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}