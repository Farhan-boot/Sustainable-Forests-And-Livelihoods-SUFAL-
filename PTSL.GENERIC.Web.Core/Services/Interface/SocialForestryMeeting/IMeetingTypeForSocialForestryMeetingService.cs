using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryMeeting
{
    public interface IMeetingTypeForSocialForestryMeetingService
    {
        (ExecutionState executionState, List<MeetingTypeForSocialForestryMeetingVM> entity, string message) List();
        (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) Create(MeetingTypeForSocialForestryMeetingVM model);
        (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) GetById(long? id);
        (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) Update(MeetingTypeForSocialForestryMeetingVM model);
        (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}