using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement
{
    public interface IAccountService
    {
        (ExecutionState executionState, List<AccountVM> entity, string message) List();
        (ExecutionState executionState, AccountVM entity, string message) Create(AccountVM model);
        (ExecutionState executionState, AccountVM entity, string message) GetById(long? id);
        (ExecutionState executionState, AccountVM entity, string message) Update(AccountVM model);
        (ExecutionState executionState, AccountVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, PaginationResutlVM<AccountVM> entity, string message) GetByFilter(AccountFilterVM model);
        (ExecutionState executionState, List<AccountVM> entity, string message) GetByFilterBasic(AccountFilterVM model);
        (ExecutionState executionState, AccountCurrentBalanceVM entity, string message) GetCurrentBalance(long id);
        (ExecutionState executionState, List<UserVM> entity, string message) GetUserInfoByUserRoleId(long userRoleId);
    }
}