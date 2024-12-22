using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;

namespace PTSL.GENERIC.Web.Core.Services.Interface.ApprovalLog
{
    public interface IApprovalLogForCfmService
    {
        (ExecutionState executionState, List<ApprovalLogForCfmVM> entity, string message) List();
        (ExecutionState executionState, ApprovalLogForCfmVM entity, string message) Create(ApprovalLogForCfmVM model);
        (ExecutionState executionState, ApprovalLogForCfmVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ApprovalLogForCfmVM entity, string message) Update(ApprovalLogForCfmVM model);
        (ExecutionState executionState, ApprovalLogForCfmVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}