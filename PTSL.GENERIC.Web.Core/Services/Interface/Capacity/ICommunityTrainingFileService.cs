using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity
{
    public interface ICommunityTrainingFileService
    {
        (ExecutionState executionState, List<CommunityTrainingFileVM> entity, string message) List();
        (ExecutionState executionState, CommunityTrainingFileVM entity, string message) Create(CommunityTrainingFileVM model);
        (ExecutionState executionState, CommunityTrainingFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CommunityTrainingFileVM entity, string message) Update(CommunityTrainingFileVM model);
        (ExecutionState executionState, CommunityTrainingFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}