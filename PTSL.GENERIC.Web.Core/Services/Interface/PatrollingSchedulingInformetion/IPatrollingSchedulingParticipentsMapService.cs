using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;

public interface IPatrollingSchedulingParticipentsMapService
{
    (ExecutionState executionState, List<PatrollingSchedulingParticipentsMapVM> entity, string message) List();
    (ExecutionState executionState, PatrollingSchedulingParticipentsMapVM entity, string message) Create(PatrollingSchedulingParticipentsMapVM model);
    (ExecutionState executionState, PatrollingSchedulingParticipentsMapVM entity, string message) GetById(long? id);
    (ExecutionState executionState, PatrollingSchedulingParticipentsMapVM entity, string message) Update(PatrollingSchedulingParticipentsMapVM model);
    (ExecutionState executionState, PatrollingSchedulingParticipentsMapVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
