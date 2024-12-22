using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining
{
    public interface ISocialForestryTrainingService
    {
        (ExecutionState executionState, List<SocialForestryTrainingVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryTrainingVM entity, string message) Create(SocialForestryTrainingVM model);
        (ExecutionState executionState, SocialForestryTrainingVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryTrainingVM entity, string message) Update(SocialForestryTrainingVM model);
        (ExecutionState executionState, SocialForestryTrainingVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) DeleteParticipant(long SocialForestryTrainingParticipentsMapId);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, List<SocialForestryTrainingVM> entity, string message) GetByFilterVM(SocialForestryTrainingFilterVM filter);
    }
}