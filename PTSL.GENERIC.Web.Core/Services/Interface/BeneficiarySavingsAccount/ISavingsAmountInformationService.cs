using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;

namespace PTSL.GENERIC.Web.Core.Services.Interface.BeneficiarySavingsAccount
{
    public interface ISavingsAmountInformationService
    {
        (ExecutionState executionState, List<SavingsAmountInformationVM> entity, string message) List();
        (ExecutionState executionState, List<SavingsAmountInformationVM> entity, string message) ListBySavingsAmountInformation(long savingsAmountInformationId);
        (ExecutionState executionState, SavingsAmountInformationVM entity, string message) Create(SavingsAmountInformationVM model);
        (ExecutionState executionState, SavingsAmountInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SavingsAmountInformationVM entity, string message) Update(SavingsAmountInformationVM model);
        (ExecutionState executionState, SavingsAmountInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
