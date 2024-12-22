using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface IDepartmentalTrainingService
{
    (ExecutionState executionState, List<DepartmentalTrainingVM> entity, string message) List();
    (ExecutionState executionState, DepartmentalTrainingVM entity, string message) Create(DepartmentalTrainingVM model);
    (ExecutionState executionState, DepartmentalTrainingVM entity, string message) GetById(long? id);
    (ExecutionState executionState, DepartmentalTrainingVM entity, string message) Update(DepartmentalTrainingVM model);
    (ExecutionState executionState, DepartmentalTrainingVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, bool isDeleted, string message) DeleteParticipant(long DepartmentalTrainingParticipentsMapId);
    (ExecutionState executionState, List<DepartmentalTrainingVM> entity, string message) GetByFilter(long? financialYearId);
    (ExecutionState executionState, PaginationResutlVM<DepartmentalTrainingVM> entity, string message) GetByFilterVM(DepartmentalTrainingFilterVM filter);
    (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
}