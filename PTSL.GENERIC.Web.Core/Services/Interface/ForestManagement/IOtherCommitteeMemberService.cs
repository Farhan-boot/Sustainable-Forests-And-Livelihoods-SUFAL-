using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;

public interface IOtherCommitteeMemberService
{
    (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) List();
    (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) Create(OtherCommitteeMemberVM model);
    (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) GetById(long? id);
    (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) Update(OtherCommitteeMemberVM model);
    (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) ListByForestFcvVcf(long id);
}
