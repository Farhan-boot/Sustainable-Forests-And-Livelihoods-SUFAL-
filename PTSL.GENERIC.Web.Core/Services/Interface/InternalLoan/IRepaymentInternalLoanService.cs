using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;

namespace PTSL.GENERIC.Web.Core.Services.Interface.InternalLoan
{
    public interface IRepaymentInternalLoanService
    {
        (ExecutionState executionState, List<RepaymentInternalLoanVM> entity, string message) List();
        (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) Create(RepaymentInternalLoanVM model);
        (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) GetById(long? id);
        (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) Update(RepaymentInternalLoanVM model);
        (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);

        (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) CompletePayment(long repaymentId);

        //(ExecutionState executionState, RepaymentInternalLoanVM entity, string message) GetInternalLoanAvailableAmount(long? fcvVcfId);
        //(ExecutionState executionState, List<RepaymentInternalLoanVM> entity, string message) GetInternalLoanInformationByFilter(RepaymentInternalLoanVM filter);


    }
}