using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryMeeting
{
    public interface ISocialForestryMeetingService
    {
        (ExecutionState executionState, List<SocialForestryMeetingVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryMeetingVM entity, string message) Create(SocialForestryMeetingVM model);
        (ExecutionState executionState, SocialForestryMeetingVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryMeetingVM entity, string message) Update(SocialForestryMeetingVM model);
        (ExecutionState executionState, SocialForestryMeetingVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, bool isDeleted, string message) DeleteParticipant(long SocialForestryMeetingParticipentsMapId);

    }
}