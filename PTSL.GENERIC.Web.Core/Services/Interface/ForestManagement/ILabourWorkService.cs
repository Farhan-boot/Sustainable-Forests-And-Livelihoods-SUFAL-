using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Labour
{
    public interface ILabourWorkService
    {
        (ExecutionState executionState, List<LabourWorkVM> entity, string message) List();
        (ExecutionState executionState, LabourWorkVM entity, string message) Create(LabourWorkVM model);
        (ExecutionState executionState, LabourWorkVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LabourWorkVM entity, string message) Update(LabourWorkVM model);
        (ExecutionState executionState, LabourWorkVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<LabourWorkVM> entity, string message) ListByFilter(LabourWorkFilterVM filter);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}