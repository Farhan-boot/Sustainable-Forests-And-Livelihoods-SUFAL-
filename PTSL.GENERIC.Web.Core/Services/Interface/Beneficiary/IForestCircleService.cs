using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IForestCircleService
    {
        (ExecutionState executionState, List<ForestCircleVM> entity, string message) List();
        (ExecutionState executionState, ForestCircleVM entity, string message) Create(ForestCircleVM model);
        (ExecutionState executionState, ForestCircleVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ForestCircleVM entity, string message) Update(ForestCircleVM model);
        (ExecutionState executionState, ForestCircleVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
