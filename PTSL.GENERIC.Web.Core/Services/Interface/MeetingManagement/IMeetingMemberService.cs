using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;

public interface IMeetingMemberService
{
    (ExecutionState executionState, List<MeetingMemberVM> entity, string message) List();
    (ExecutionState executionState, MeetingMemberVM entity, string message) Create(MeetingMemberVM model);
    (ExecutionState executionState, MeetingMemberVM entity, string message) GetById(long? id);
    (ExecutionState executionState, MeetingMemberVM entity, string message) Update(MeetingMemberVM model);
    (ExecutionState executionState, MeetingMemberVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
