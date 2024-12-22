using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;

namespace PTSL.GENERIC.Web.Core.Services.Interface.BeneficiarySavingsAccount
{
    public interface IWithdrawAmountInformationService
    {
        (ExecutionState executionState, List<WithdrawAmountInformationVM> entity, string message) List();
        (ExecutionState executionState, List<WithdrawAmountInformationVM> entity, string message) ListByWithdrawAmountInformation(long withdrawAmountInformationId);
        (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) Create(WithdrawAmountInformationVM model);
        (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) Update(WithdrawAmountInformationVM model);
        (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
