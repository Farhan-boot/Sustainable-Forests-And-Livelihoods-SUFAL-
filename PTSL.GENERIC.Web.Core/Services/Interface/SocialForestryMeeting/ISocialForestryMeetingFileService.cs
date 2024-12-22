using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryMeeting
{
    public interface ISocialForestryMeetingFileService
    {
        (ExecutionState executionState, List<SocialForestryMeetingFileVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryMeetingFileVM entity, string message) Create(SocialForestryMeetingFileVM model);
        (ExecutionState executionState, SocialForestryMeetingFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryMeetingFileVM entity, string message) Update(SocialForestryMeetingFileVM model);
        (ExecutionState executionState, SocialForestryMeetingFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);

        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);


    }
}