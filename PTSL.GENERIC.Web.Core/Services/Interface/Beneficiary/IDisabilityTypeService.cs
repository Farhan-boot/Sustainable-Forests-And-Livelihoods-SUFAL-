using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IDisabilityTypeService
    {
        (ExecutionState executionState, List<DisabilityTypeVM> entity, string message) List();
        (ExecutionState executionState, DisabilityTypeVM entity, string message) Create(DisabilityTypeVM model);
        (ExecutionState executionState, DisabilityTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DisabilityTypeVM entity, string message) Update(DisabilityTypeVM model);
        (ExecutionState executionState, DisabilityTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
