using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining
{
    public interface ITrainerDesignationForTrainingService
    {
        (ExecutionState executionState, List<TrainerDesignationForTrainingVM> entity, string message) List();
        (ExecutionState executionState, TrainerDesignationForTrainingVM entity, string message) Create(TrainerDesignationForTrainingVM model);
        (ExecutionState executionState, TrainerDesignationForTrainingVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TrainerDesignationForTrainingVM entity, string message) Update(TrainerDesignationForTrainingVM model);
        (ExecutionState executionState, TrainerDesignationForTrainingVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}