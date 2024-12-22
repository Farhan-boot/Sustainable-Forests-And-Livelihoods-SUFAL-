using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AccountManagement;

namespace PTSL.GENERIC.Business.Businesses.Interface.AccountManagement
{
    public interface IBankAccountsInformationBusiness : IBaseBusiness<BankAccountsInformation>
    {
        Task<(ExecutionState executionState, List<BankAccountsInformation> entity, string message)> GetBankAccountsInformationByUserId(long? userId, AccountAllowedFundExpense? accountAllowedFundExpense);
        Task<bool> IsUserAssignedToBankAccounts(long userId, long?[] accountIds);
    }
}