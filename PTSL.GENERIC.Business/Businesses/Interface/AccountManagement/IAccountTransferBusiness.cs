using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Business.Businesses.Interface.AccountManagement
{
    public interface IAccountTransferBusiness : IBaseBusiness<AccountTransfer>
    {
        Task<(ExecutionState executionState, string message)> AcceptTransfer(long accountTransferId, long userId);
        Task<(ExecutionState executionState, string message)> CancelTransfer(long accountTransferId, long userId);
        Task<(ExecutionState executionState, string message)> ForwardApproval(long currentUserId, AccountForwardRequestVM request);
        Task<(ExecutionState executionState, string message)> LastStageApproval(long currentUserId, long accountTransferId, long permissionHeaderSettingsId);
        Task<(ExecutionState executionState, List<AccountTransfer> entity, string message)> ListForCashIn(long currentUserId);
        Task<(ExecutionState executionState, List<AccountTransfer> entity, string message)> ListForRequestList(long permissionHeaderSettingsId, long currentUserId);
        Task<(ExecutionState executionState, string message)> ModifyTransfer(AccountTransfer entity, long userId);
        Task<(ExecutionState executionState, string message)> RollbackTransfer(long accountTransferId, long userId);
        Task<(ExecutionState executionState, AccountTransfer entity, string message)> Transfer(AccountTransfer entity, long userId, long permissionHeaderSettingsId);
        Task<(ExecutionState executionState, List<AccountTransfer> entity, string message)> ListByFilter(ForestCivilLocationFilter filter);

    }
}