using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;

public interface IMeetingTypeService
{
    (ExecutionState executionState, List<MeetingTypeVM> entity, string message) List();
    (ExecutionState executionState, MeetingTypeVM entity, string message) Create(MeetingTypeVM model);
    (ExecutionState executionState, MeetingTypeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, MeetingTypeVM entity, string message) Update(MeetingTypeVM model);
    (ExecutionState executionState, MeetingTypeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
