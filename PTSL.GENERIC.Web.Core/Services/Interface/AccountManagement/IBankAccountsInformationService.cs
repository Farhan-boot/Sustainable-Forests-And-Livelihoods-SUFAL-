using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement
{
    public interface IBankAccountsInformationService
    {
        (ExecutionState executionState, List<BankAccountsInformationVM> entity, string message) List();
        (ExecutionState executionState, BankAccountsInformationVM entity, string message) Create(BankAccountsInformationVM model);
        (ExecutionState executionState, BankAccountsInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, BankAccountsInformationVM entity, string message) Update(BankAccountsInformationVM model);
        (ExecutionState executionState, BankAccountsInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<BankAccountsInformationVM> entity, string message) GetBankAccountsInformationByUserId(long? userId, AccountAllowedFundExpense? accountAllowedFundExpense);
    }
}