using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface ICommunityTrainingTypeService
{
    (ExecutionState executionState, List<CommunityTrainingTypeVM> entity, string message) List();
    (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) Create(CommunityTrainingTypeVM model);
    (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) Update(CommunityTrainingTypeVM model);
    (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
