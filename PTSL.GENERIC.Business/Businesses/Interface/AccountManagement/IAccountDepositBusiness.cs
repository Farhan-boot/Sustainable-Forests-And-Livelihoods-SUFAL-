using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Business.Businesses.Interface.AccountManagement
{
    public interface IAccountDepositBusiness : IBaseBusiness<AccountDeposit>
    {
        Task<(ExecutionState executionState, string message)> AcceptDeposit(long accountTransferId, long userId);
        Task<(ExecutionState executionState, string message)> CancelDeposit(long accountTransferId, long userId);
        Task<(ExecutionState executionState, AccountDeposit entity, string message)> CreateAsync(AccountDeposit entity, long userId, long permissionHeaderSettingsId);
        Task<(ExecutionState executionState, string message)> ForwardApproval(long currentUserId, AccountDepositForwardRequestVM request);
        Task<(ExecutionState executionState, AccountDeposit entity, string message)> GetDetailsAsync(long id);
        Task<(ExecutionState executionState, string message)> LastStageApproval(long currentUserId, long accountTransferId, long permissionHeaderSettingsId);
        Task<(ExecutionState executionState, List<AccountDeposit> entity, string message)> ListForCashIn(long currentUserId);
        Task<(ExecutionState executionState, List<AccountDeposit> entity, string message)> ListForRequestList(long permissionHeaderSettingsId, long currentUserId);

        //New add filter
        Task<(ExecutionState executionState, PaginationResutl<AccountDeposit> entity, string message)> ListByFilter(ForestCivilLocationFilter filter);

    }
}
