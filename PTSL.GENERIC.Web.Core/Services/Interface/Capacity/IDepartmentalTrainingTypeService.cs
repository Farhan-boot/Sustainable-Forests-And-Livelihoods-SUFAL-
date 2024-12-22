using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface IDepartmentalTrainingTypeService
{
    (ExecutionState executionState, List<DepartmentalTrainingTypeVM> entity, string message) List();
    (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) Create(DepartmentalTrainingTypeVM model);
    (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) Update(DepartmentalTrainingTypeVM model);
    (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
