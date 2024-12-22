using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;

namespace PTSL.GENERIC.Web.Core.Services.Interface.InternalLoan
{
    public interface IInternalLoanInformationService
    {
        (ExecutionState executionState, List<InternalLoanInformationVM> entity, string message) List();
        (ExecutionState executionState, InternalLoanInformationVM entity, string message) Create(InternalLoanInformationVM model);
        (ExecutionState executionState, InternalLoanInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, InternalLoanInformationVM entity, string message) Update(InternalLoanInformationVM model);
        (ExecutionState executionState, InternalLoanInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, InternalLoanAvailableAmountVM entity, string message) GetInternalLoanAvailableAmount(long? fcvVcfId);

        (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) GetInternalLoanInformationByFilter(AIGBasicInformationFilterVM filter);
    }
}