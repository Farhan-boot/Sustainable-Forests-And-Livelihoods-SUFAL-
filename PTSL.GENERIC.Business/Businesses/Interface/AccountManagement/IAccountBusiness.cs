using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Business.Businesses.Interface.AccountManagement
{
    public interface IAccountBusiness : IBaseBusiness<Account>
    {
        Task<(ExecutionState executionState, PaginationResutl<Account> entity, string message)> GetByFilter(AccountFilterVM filter);
        Task<(ExecutionState executionState, List<Account> entity, string message)> GetByFilterBasic(AccountFilterVM filter);
        Task<(ExecutionState executionState, AccountCurrentBalanceVM data, string message)> GetCurrentBalance(long id);
    }
}