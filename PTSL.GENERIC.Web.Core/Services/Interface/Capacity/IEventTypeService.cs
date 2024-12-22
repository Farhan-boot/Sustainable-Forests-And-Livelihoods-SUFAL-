using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface IEventTypeService
{
    (ExecutionState executionState, List<EventTypeVM> entity, string message) List();
    (ExecutionState executionState, EventTypeVM entity, string message) Create(EventTypeVM model);
    (ExecutionState executionState, EventTypeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, EventTypeVM entity, string message) Update(EventTypeVM model);
    (ExecutionState executionState, EventTypeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
