using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;

public interface IPatrollingSchedulingService
{
    (ExecutionState executionState, List<PatrollingSchedulingVM> entity, string message) List();
    (ExecutionState executionState, PatrollingSchedulingVM entity, string message) Create(PatrollingSchedulingVM model);
    (ExecutionState executionState, PatrollingSchedulingVM entity, string message) GetById(long? id);
    (ExecutionState executionState, PatrollingSchedulingVM entity, string message) Update(PatrollingSchedulingVM model);
    (ExecutionState executionState, PatrollingSchedulingVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, bool isDeleted, string message) DeleteParticipant(long patrollingSchedulingParticipentsMapId);
    (ExecutionState executionState, PaginationResutlVM<PatrollingSchedulingVM> entity, string message) GetTrainingByFilter(PatrollingSchedulingFilterVM filter);
}
