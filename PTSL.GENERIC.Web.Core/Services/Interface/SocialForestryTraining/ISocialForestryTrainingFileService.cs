using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining
{
    public interface ISocialForestryTrainingFileService
    {
        (ExecutionState executionState, List<SocialForestryTrainingFileVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryTrainingFileVM entity, string message) Create(SocialForestryTrainingFileVM model);
        (ExecutionState executionState, SocialForestryTrainingFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryTrainingFileVM entity, string message) Update(SocialForestryTrainingFileVM model);
        (ExecutionState executionState, SocialForestryTrainingFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}