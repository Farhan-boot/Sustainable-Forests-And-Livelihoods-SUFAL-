using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface ICommunityTrainingService
{
    (ExecutionState executionState, List<CommunityTrainingVM> entity, string message) List();
    (ExecutionState executionState, CommunityTrainingVM entity, string message) Create(CommunityTrainingVM model);
    (ExecutionState executionState, CommunityTrainingVM entity, string message) GetById(long? id);
    (ExecutionState executionState, CommunityTrainingVM entity, string message) Update(CommunityTrainingVM model);
    (ExecutionState executionState, CommunityTrainingVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, bool isDeleted, string message) DeleteParticipant(long communityTrainingParticipentsMapId);
    (ExecutionState executionState, PaginationResutlVM<CommunityTrainingVM> entity, string message) GetTrainingByFilter(CommunityTrainingFilterVM filter);
    (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);

    (ExecutionState executionState, List<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message) GetCommunityTrainingParticipentsMapByFilter(CommunityTrainingFilterByBeneficiaryVM filter);
}
