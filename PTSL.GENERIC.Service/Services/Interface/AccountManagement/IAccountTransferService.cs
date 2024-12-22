using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public interface IAccountTransferService : IBaseService<AccountTransferVM, AccountTransfer>
    {
        Task<(ExecutionState executionState, string message)> AcceptTransfer(long accountTransferId, long userId);
        Task<(ExecutionState executionState, string message)> CancelTransfer(long accountTransferId, long userId);
        Task<(ExecutionState executionState, string message)> ForwardApproval(long currentUserId, AccountForwardRequestVM request);
        Task<(ExecutionState executionState, string message)> LastStageApproval(long currentUserId, long accountTransferId, long permissionHeaderSettingsId);
        Task<(ExecutionState executionState, List<AccountTransferVM> entity, string message)> ListForCashIn(long currentUserId);
        Task<(ExecutionState executionState, List<AccountTransferVM> entity, string message)> ListForRequestList(long permissionHeaderSettingsId, long currentUserId);
        Task<(ExecutionState executionState, string message)> ModifyTransfer(AccountTransferVM entity, long userId);
        Task<(ExecutionState executionState, string message)> RollbackTransfer(long accountTransferId, long userId);
        Task<(ExecutionState executionState, AccountTransferVM entity, string message)> Transfer(AccountTransferVM model, long userId, long permissionHeaderSettingsId);
        Task<(ExecutionState executionState, List<AccountTransferVM> data, string message)> ListByFilter(ForestCivilLocationFilter filter);

    }
}