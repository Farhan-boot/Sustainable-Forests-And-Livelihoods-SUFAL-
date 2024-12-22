using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling;

namespace PTSL.GENERIC.Web.Core.Services.Interface.BeneficiarySavingsAccount
{
    public interface ISavingsAccountService
    {
        (ExecutionState executionState, List<SavingsAccountVM> entity, string message) List();
        (ExecutionState executionState, List<SavingsAccountVM> entity, string message) ListBySavingsAccount(long savingsAccountId);
        (ExecutionState executionState, SavingsAccountVM entity, string message) Create(SavingsAccountVM model);
        (ExecutionState executionState, SavingsAccountVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SavingsAccountVM entity, string message) Update(SavingsAccountVM model);
        (ExecutionState executionState, SavingsAccountVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, PaginationResutlVM<SavingsAccountVM> entity, string message) GetByFilter(SavingsAccountFilterVM filter);
    }
}
