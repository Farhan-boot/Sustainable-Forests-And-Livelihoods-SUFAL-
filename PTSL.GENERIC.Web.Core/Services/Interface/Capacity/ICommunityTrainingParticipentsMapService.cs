using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface ICommunityTrainingParticipentsMapService
{
    (ExecutionState executionState, List<CommunityTrainingParticipentsMapVM> entity, string message) List();
    (ExecutionState executionState, CommunityTrainingParticipentsMapVM entity, string message) Create(CommunityTrainingParticipentsMapVM model);
    (ExecutionState executionState, CommunityTrainingParticipentsMapVM entity, string message) GetById(long? id);
    (ExecutionState executionState, CommunityTrainingParticipentsMapVM entity, string message) Update(CommunityTrainingParticipentsMapVM model);
    (ExecutionState executionState, CommunityTrainingParticipentsMapVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
