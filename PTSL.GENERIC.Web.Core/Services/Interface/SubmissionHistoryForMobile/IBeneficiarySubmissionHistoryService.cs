using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SubmissionHistoryForMobile;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SubmissionHistoryForMobile
{
    public interface IBeneficiarySubmissionHistoryService
    {
        (ExecutionState executionState, List<BeneficiarySubmissionHistoryVM> entity, string message) List();
        (ExecutionState executionState, BeneficiarySubmissionHistoryVM entity, string message) Create(BeneficiarySubmissionHistoryVM model);
        (ExecutionState executionState, BeneficiarySubmissionHistoryVM entity, string message) GetById(long? id);
        (ExecutionState executionState, BeneficiarySubmissionHistoryVM entity, string message) Update(BeneficiarySubmissionHistoryVM model);
        (ExecutionState executionState, BeneficiarySubmissionHistoryVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}