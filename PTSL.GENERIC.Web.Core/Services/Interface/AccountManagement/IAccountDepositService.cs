using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement
{
    public interface IAccountDepositService
    {
        (ExecutionState executionState, List<AccountDepositVM> entity, string message) List();
        (ExecutionState executionState, AccountDepositVM entity, string message) Create(AccountDepositVM model, long permissionHeaderSettingsId);
        (ExecutionState executionState, AccountDepositVM entity, string message) GetById(long? id);
        (ExecutionState executionState, AccountDepositVM entity, string message) GetDetails(long? id);
        (ExecutionState executionState, AccountDepositVM entity, string message) Update(AccountDepositVM model);
        (ExecutionState executionState, AccountDepositVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, string message) AcceptDeposit(long accountTransferId);
        (ExecutionState executionState, string message) CancelDeposit(long accountTransferId);
        (ExecutionState executionState, string message) LastStageApproval(long accountTransferId, long permissionHeaderSettingsId);
        (ExecutionState executionState, string message) ForwardApproval(AccountDepositForwardRequestVM request);
        (ExecutionState executionState, List<AccountDepositVM> entity, string message) ListForRequestList(long permissionHeaderSettingsId);
        (ExecutionState executionState, List<AccountDepositVM> entity, string message) ListForCashIn();
        (ExecutionState executionState, PaginationResutlVM<AccountDepositVM> entity, string message) ListByFilter(ForestCivilLocationFilter filter);
    }
}
