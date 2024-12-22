using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;

namespace PTSL.GENERIC.Web.Core.Services.Interface.InternalLoan
{
    public interface IInternalLoanInformationFileService
    {
        (ExecutionState executionState, List<InternalLoanInformationFileVM> entity, string message) List();
        (ExecutionState executionState, InternalLoanInformationFileVM entity, string message) Create(InternalLoanInformationFileVM model);
        (ExecutionState executionState, InternalLoanInformationFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, InternalLoanInformationFileVM entity, string message) Update(InternalLoanInformationFileVM model);
        (ExecutionState executionState, InternalLoanInformationFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}