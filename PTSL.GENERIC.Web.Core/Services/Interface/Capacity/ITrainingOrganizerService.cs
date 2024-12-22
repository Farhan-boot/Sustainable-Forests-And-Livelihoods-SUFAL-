using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface ITrainingOrganizerService
{
    (ExecutionState executionState, List<TrainingOrganizerVM> entity, string message) List();
    (ExecutionState executionState, TrainingOrganizerVM entity, string message) Create(TrainingOrganizerVM model);
    (ExecutionState executionState, TrainingOrganizerVM entity, string message) GetById(long? id);
    (ExecutionState executionState, TrainingOrganizerVM entity, string message) Update(TrainingOrganizerVM model);
    (ExecutionState executionState, TrainingOrganizerVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
}
