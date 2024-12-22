using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity
{
    public interface IDepartmentalTrainingFileService
    {
        (ExecutionState executionState, List<DepartmentalTrainingFileVM> entity, string message) List();
        (ExecutionState executionState, DepartmentalTrainingFileVM entity, string message) Create(DepartmentalTrainingFileVM model);
        (ExecutionState executionState, DepartmentalTrainingFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DepartmentalTrainingFileVM entity, string message) Update(DepartmentalTrainingFileVM model);
        (ExecutionState executionState, DepartmentalTrainingFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}