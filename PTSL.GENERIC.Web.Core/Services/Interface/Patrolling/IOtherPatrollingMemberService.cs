using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Patrolling;

public interface IOtherPatrollingMemberService
{
    (ExecutionState executionState, List<OtherPatrollingMemberVM> entity, string message) List();
    (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) Create(OtherPatrollingMemberVM model);
    (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) GetById(long? id);
    (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) Update(OtherPatrollingMemberVM model);
    (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, List<OtherPatrollingMemberVM> entity, string message) ListByForestFcvVcf(long id);
}
