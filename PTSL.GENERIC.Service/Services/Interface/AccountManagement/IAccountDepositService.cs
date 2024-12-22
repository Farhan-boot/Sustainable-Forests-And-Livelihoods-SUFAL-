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
    public interface IAccountDepositService : IBaseService<AccountDepositVM, AccountDeposit>
    {
        Task<(ExecutionState executionState, string message)> AcceptDeposit(long accountTransferId, long userId);
        Task<(ExecutionState executionState, string message)> CancelDeposit(long accountTransferId, long userId);
        Task<(ExecutionState executionState, AccountDepositVM entity, string message)> CreateAsync(AccountDepositVM model, long userId, long permissionHeaderSettingsId);
        Task<(ExecutionState executionState, string message)> ForwardApproval(long currentUserId, AccountDepositForwardRequestVM request);
        Task<(ExecutionState executionState, AccountDepositVM entity, string message)> GetDetailsAsync(long id);
        Task<(ExecutionState executionState, string message)> LastStageApproval(long currentUserId, long accountTransferId, long permissionHeaderSettingsId);
        Task<(ExecutionState executionState, List<AccountDepositVM> entity, string message)> ListForCashIn(long currentUserId);
        Task<(ExecutionState executionState, List<AccountDepositVM> entity, string message)> ListForRequestList(long permissionHeaderSettingsId, long currentUserId);
        Task<(ExecutionState executionState, PaginationResutl<AccountDepositVM> data, string message)> ListByFilter(ForestCivilLocationFilter filter);
    }
}
