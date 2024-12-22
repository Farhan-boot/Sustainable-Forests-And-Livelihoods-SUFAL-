using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IForestDivisionService
    {
        (ExecutionState executionState, List<ForestDivisionVM> entity, string message) List();
        (ExecutionState executionState, List<ForestDivisionVM> entity, string message) ListByForestCircle(long forestCircleId);
        (ExecutionState executionState, ForestDivisionVM entity, string message) Create(ForestDivisionVM model);
        (ExecutionState executionState, ForestDivisionVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ForestDivisionVM entity, string message) Update(ForestDivisionVM model);
        (ExecutionState executionState, ForestDivisionVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<ForestDivisionVM> entity, string message) ListByMultipleForestCircle(List<long> forestCircleIds);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}
