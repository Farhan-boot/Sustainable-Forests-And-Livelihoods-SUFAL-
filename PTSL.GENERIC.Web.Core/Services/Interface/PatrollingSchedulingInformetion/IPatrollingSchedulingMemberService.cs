using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;

public interface IPatrollingSchedulingMemberService
{
    (ExecutionState executionState, List<PatrollingSchedulingMemberVM> entity, string message) List();
    (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) Create(PatrollingSchedulingMemberVM model);
    (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) GetById(long? id);
    (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) Update(PatrollingSchedulingMemberVM model);
    (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
