using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Patrolling;

public interface IPatrollingScheduleInformetionService
{
    (ExecutionState executionState, List<PatrollingScheduleInformetionVM> entity, string message) List();
    (ExecutionState executionState, PatrollingScheduleInformetionVM entity, string message) Create(PatrollingScheduleInformetionVM model);
    (ExecutionState executionState, PatrollingScheduleInformetionVM entity, string message) GetById(long? id);
    (ExecutionState executionState, PatrollingScheduleInformetionVM entity, string message) Update(PatrollingScheduleInformetionVM model);
    (ExecutionState executionState, PatrollingScheduleInformetionVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, List<PatrollingScheduleInformetionVM> entity, string message) PatrollingScheduleInformetionListByForestFcvVcf(long id);
    (ExecutionState executionState, List<PatrollingScheduleInformetionVM> entity, string message) GetPatrollingScheduleInformetionByFilter(PatrollingScheduleFilterVM filter);
}
