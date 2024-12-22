using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining
{
    public interface ISocialForestryTrainingMemberService
    {
        (ExecutionState executionState, List<SocialForestryTrainingMemberVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryTrainingMemberVM entity, string message) Create(SocialForestryTrainingMemberVM model);
        (ExecutionState executionState, SocialForestryTrainingMemberVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryTrainingMemberVM entity, string message) Update(SocialForestryTrainingMemberVM model);
        (ExecutionState executionState, SocialForestryTrainingMemberVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}