using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IManualIncomeSourceTypeService
    {
        (ExecutionState executionState, List<ManualIncomeSourceTypeVM> entity, string message) List();
        (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) Create(ManualIncomeSourceTypeVM model);
        (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) Update(ManualIncomeSourceTypeVM model);
        (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
