using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public interface IBankAccountsInformationService : IBaseService<BankAccountsInformationVM, BankAccountsInformation>
    {
        Task<(ExecutionState executionState, List<BankAccountsInformationVM> entity, string message)> GetBankAccountsInformationByUserId(long? userId, AccountAllowedFundExpense? accountAllowedFundExpense);
    }
}