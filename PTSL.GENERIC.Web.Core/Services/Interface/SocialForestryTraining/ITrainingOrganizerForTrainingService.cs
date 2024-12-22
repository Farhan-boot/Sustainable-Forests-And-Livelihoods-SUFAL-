using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining
{
    public interface ITrainingOrganizerForTrainingService
    {
        (ExecutionState executionState, List<TrainingOrganizerForTrainingVM> entity, string message) List();
        (ExecutionState executionState, TrainingOrganizerForTrainingVM entity, string message) Create(TrainingOrganizerForTrainingVM model);
        (ExecutionState executionState, TrainingOrganizerForTrainingVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TrainingOrganizerForTrainingVM entity, string message) Update(TrainingOrganizerForTrainingVM model);
        (ExecutionState executionState, TrainingOrganizerForTrainingVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}