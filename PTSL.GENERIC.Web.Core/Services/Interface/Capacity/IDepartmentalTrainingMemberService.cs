using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Capacity;

public interface IDepartmentalTrainingMemberService
{
    (ExecutionState executionState, List<DepartmentalTrainingMemberVM> entity, string message) List();
    (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) Create(DepartmentalTrainingMemberVM model);
    (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) GetById(long? id);
    (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) Update(DepartmentalTrainingMemberVM model);
    (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
