using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;

public interface IMeetingParticipantsMapService
{
    (ExecutionState executionState, List<MeetingParticipantsMapVM> entity, string message) List();
    (ExecutionState executionState, MeetingParticipantsMapVM entity, string message) Create(MeetingParticipantsMapVM model);
    (ExecutionState executionState, MeetingParticipantsMapVM entity, string message) GetById(long? id);
    (ExecutionState executionState, MeetingParticipantsMapVM entity, string message) Update(MeetingParticipantsMapVM model);
    (ExecutionState executionState, MeetingParticipantsMapVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
