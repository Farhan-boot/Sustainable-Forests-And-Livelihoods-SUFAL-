using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.MeetingManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;

public interface IMeetingService
{
    (ExecutionState executionState, List<MeetingVM> entity, string message) List();
    (ExecutionState executionState, MeetingVM entity, string message) Create(MeetingVM model);
    (ExecutionState executionState, MeetingVM entity, string message) GetById(long? id);
    (ExecutionState executionState, MeetingVM entity, string message) Update(MeetingVM model);
    (ExecutionState executionState, MeetingVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, bool isDeleted, string message) DeleteParticipant(long mapId);
    (ExecutionState executionState, PaginationResutlVM<MeetingVM> entity, string message) GetMeetingByFilter(MeetingFilterVM filter);
    (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
}
