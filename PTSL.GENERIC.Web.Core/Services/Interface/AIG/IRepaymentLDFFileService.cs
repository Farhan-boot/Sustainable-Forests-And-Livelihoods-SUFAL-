using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface IRepaymentLDFFileService
    {
        (ExecutionState executionState, List<RepaymentLDFFileVM> entity, string message) List();
        (ExecutionState executionState, RepaymentLDFFileVM entity, string message) Create(RepaymentLDFFileVM model);
        (ExecutionState executionState, RepaymentLDFFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, RepaymentLDFFileVM entity, string message) Update(RepaymentLDFFileVM model);
        (ExecutionState executionState, RepaymentLDFFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);

        (ExecutionState executionState, List<RepaymentLDFFileVM> entity, string message) GetRepaymentLDFFileByRepaymentId(long? repaymentId);
    }
}