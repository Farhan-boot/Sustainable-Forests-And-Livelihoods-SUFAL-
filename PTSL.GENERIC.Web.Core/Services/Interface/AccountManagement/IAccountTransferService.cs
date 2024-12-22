using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement
{
    public interface IAccountTransferService
    {
        (ExecutionState executionState, List<AccountTransferVM> entity, string message) List();
        (ExecutionState executionState, AccountTransferVM entity, string message) Create(AccountTransferVM model);
        (ExecutionState executionState, AccountTransferVM entity, string message) Transfer(AccountTransferVM model, long permissionHeaderSettingsId);
        (ExecutionState executionState, AccountTransferVM entity, string message) GetById(long? id);
        (ExecutionState executionState, AccountTransferVM entity, string message) Update(AccountTransferVM model);
        (ExecutionState executionState, AccountTransferVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, AccountTransferVM entity, string message) ModifyTransfer(AccountTransferVM model);
        (ExecutionState executionState, string message) RollbackTransfer(long accountTransferId);
        (ExecutionState executionState, string message) CancelTransfer(long accountTransferId);
        (ExecutionState executionState, string message) AcceptTransfer(long accountTransferId);
        (ExecutionState executionState, List<AccountTransferVM> entity, string message) ListForCashIn();
        (ExecutionState executionState, List<AccountTransferVM> entity, string message) ListForRequestList(long permissionHeaderSettingsId);
        (ExecutionState executionState, string message) ForwardApproval(AccountForwardRequestVM request);
        (ExecutionState executionState, string message) LastStageApproval(long accountTransferId, long permissionHeaderSettingsId);
        (ExecutionState executionState, List<AccountTransferVM> entity, string message) ListByFilter(ForestCivilLocationFilter filter);

    }
}