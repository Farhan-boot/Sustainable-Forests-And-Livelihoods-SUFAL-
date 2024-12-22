using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining
{
    public interface ISocialForestryTrainingParticipentsMapService
    {
        (ExecutionState executionState, List<SocialForestryTrainingParticipentsMapVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) Create(SocialForestryTrainingParticipentsMapVM model);
        (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) Update(SocialForestryTrainingParticipentsMapVM model);
        (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}