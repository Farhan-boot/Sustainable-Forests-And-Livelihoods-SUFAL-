using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IForestBeatService
    {
        (ExecutionState executionState, List<ForestBeatVM> entity, string message) List();
        (ExecutionState executionState, ForestBeatVM entity, string message) Create(ForestBeatVM model);
        (ExecutionState executionState, ForestBeatVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ForestBeatVM entity, string message) Update(ForestBeatVM model);
        (ExecutionState executionState, ForestBeatVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<ForestBeatVM> entity, string message) ListByForestRange(long forestRangeId);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}
