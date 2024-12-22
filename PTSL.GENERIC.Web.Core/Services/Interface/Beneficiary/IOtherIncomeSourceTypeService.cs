using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IOtherIncomeSourceTypeService
    {
        (ExecutionState executionState, List<OtherIncomeSourceTypeVM> entity, string message) List();
        (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) Create(OtherIncomeSourceTypeVM model);
        (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) Update(OtherIncomeSourceTypeVM model);
        (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
