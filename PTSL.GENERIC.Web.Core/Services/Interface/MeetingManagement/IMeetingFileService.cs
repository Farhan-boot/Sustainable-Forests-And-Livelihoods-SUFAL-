using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;

public interface IMeetingFileService
{
    (ExecutionState executionState, List<MeetingFileVM> entity, string message) List();
    (ExecutionState executionState, MeetingFileVM entity, string message) Create(MeetingFileVM model);
    (ExecutionState executionState, MeetingFileVM entity, string message) GetById(long? id);
    (ExecutionState executionState, MeetingFileVM entity, string message) Update(MeetingFileVM model);
    (ExecutionState executionState, MeetingFileVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
}
