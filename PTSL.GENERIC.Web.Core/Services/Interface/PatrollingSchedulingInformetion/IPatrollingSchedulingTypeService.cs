using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;

public interface IPatrollingSchedulingTypeService
{
    (ExecutionState executionState, List<PatrollingSchedulingTypeVM> entity, string message) List();
    (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) Create(PatrollingSchedulingTypeVM model);
    (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) Update(PatrollingSchedulingTypeVM model);
    (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
