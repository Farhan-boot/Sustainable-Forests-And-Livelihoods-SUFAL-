using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;

public interface IEnergyTypeService
{
    (ExecutionState executionState, List<EnergyTypeVM> entity, string message) List();
    (ExecutionState executionState, EnergyTypeVM entity, string message) Create(EnergyTypeVM model);
    (ExecutionState executionState, EnergyTypeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, EnergyTypeVM entity, string message) Update(EnergyTypeVM model);
    (ExecutionState executionState, EnergyTypeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
