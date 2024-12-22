using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface IIndividualLDFInfoFormService
    {
        (ExecutionState executionState, List<IndividualLDFInfoFormVM> entity, string message) List();
        (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) Create(IndividualLDFInfoFormVM model);
        (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) GetById(long? id);
        (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) Update(IndividualLDFInfoFormVM model);
        (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool entity, string message) ApproveLDF(long ldfId, double approvedLoanAmount);
        (ExecutionState executionState, PaginationResutlVM<IndividualLDFInfoFormVM> entity, string message) ListByFilter(IndividualLDFFilterVM model);
        (ExecutionState executionState, List<IndividualLDFInfoFormVM> entity, string message) ListByFilterBasic(IndividualLDFFilterVM model);
        (ExecutionState executionState, List<SurveyDropdownVM> entity, string message) ListByFilterBeneficiary(IndividualLDFFilterVM model);
    }
}