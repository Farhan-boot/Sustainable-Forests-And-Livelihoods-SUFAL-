using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IForestRangeService
    {
        (ExecutionState executionState, List<ForestRangeVM> entity, string message) List();
        (ExecutionState executionState, List<ForestRangeVM> entity, string message) ListByForestDivision(long forestDivisionId);
        (ExecutionState executionState, ForestRangeVM entity, string message) Create(ForestRangeVM model);
        (ExecutionState executionState, ForestRangeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ForestRangeVM entity, string message) Update(ForestRangeVM model);
        (ExecutionState executionState, ForestRangeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}
