using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public interface IAccountService : IBaseService<AccountVM, Account>
    {
        Task<(ExecutionState executionState, PaginationResutl<AccountVM> entity, string message)> GetByFilter(AccountFilterVM filterData);
        Task<(ExecutionState executionState, List<AccountVM> entity, string message)> GetByFilterBasic(AccountFilterVM filterData);
        Task<(ExecutionState executionState, AccountCurrentBalanceVM data, string message)> GetCurrentBalance(long id);
    }
}