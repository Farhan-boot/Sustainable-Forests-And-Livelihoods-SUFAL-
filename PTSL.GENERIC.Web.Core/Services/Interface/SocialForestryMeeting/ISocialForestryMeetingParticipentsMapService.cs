using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryMeeting
{
    public interface ISocialForestryMeetingParticipentsMapService
    {
        (ExecutionState executionState, List<SocialForestryMeetingParticipentsMapVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryMeetingParticipentsMapVM entity, string message) Create(SocialForestryMeetingParticipentsMapVM model);
        (ExecutionState executionState, SocialForestryMeetingParticipentsMapVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryMeetingParticipentsMapVM entity, string message) Update(SocialForestryMeetingParticipentsMapVM model);
        (ExecutionState executionState, SocialForestryMeetingParticipentsMapVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}