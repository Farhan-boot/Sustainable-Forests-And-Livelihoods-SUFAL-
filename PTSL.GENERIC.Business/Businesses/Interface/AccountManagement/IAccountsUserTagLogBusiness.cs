using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.AccountManagement
{
    public interface IAccountsUserTagLogBusiness : IBaseBusiness<AccountsUserTagLog>
    {
        Task<(ExecutionState executionState, List<AccountsUserTagLog> entity, string message)> GetAccountsUserTagLogsByAccountId(long accountId);
    }
}