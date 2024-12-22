using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining
{
    public interface IEventTypeForTrainingService
    {
        (ExecutionState executionState, List<EventTypeForTrainingVM> entity, string message) List();
        (ExecutionState executionState, EventTypeForTrainingVM entity, string message) Create(EventTypeForTrainingVM model);
        (ExecutionState executionState, EventTypeForTrainingVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EventTypeForTrainingVM entity, string message) Update(EventTypeForTrainingVM model);
        (ExecutionState executionState, EventTypeForTrainingVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}