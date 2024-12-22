using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface ICommunityTrainingMemberService
{
    (ExecutionState executionState, List<CommunityTrainingMemberVM> entity, string message) List();
    (ExecutionState executionState, CommunityTrainingMemberVM entity, string message) Create(CommunityTrainingMemberVM model);
    (ExecutionState executionState, CommunityTrainingMemberVM entity, string message) GetById(long? id);
    (ExecutionState executionState, CommunityTrainingMemberVM entity, string message) Update(CommunityTrainingMemberVM model);
    (ExecutionState executionState, CommunityTrainingMemberVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
