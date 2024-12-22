using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryMeeting
{
    public interface ISocialForestryMeetingMemberService
    {
        (ExecutionState executionState, List<SocialForestryMeetingMemberVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryMeetingMemberVM entity, string message) Create(SocialForestryMeetingMemberVM model);
        (ExecutionState executionState, SocialForestryMeetingMemberVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryMeetingMemberVM entity, string message) Update(SocialForestryMeetingMemberVM model);
        (ExecutionState executionState, SocialForestryMeetingMemberVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}