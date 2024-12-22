using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;

public interface IPatrollingSchedulingFileService
{
    (ExecutionState executionState, List<PatrollingSchedulingFileVM> entity, string message) List();
    (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) Create(PatrollingSchedulingFileVM model);
    (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) GetById(long? id);
    (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) Update(PatrollingSchedulingFileVM model);
    (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
