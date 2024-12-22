using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;

public interface IBusinessIncomeSourceTypeService
{
    (ExecutionState executionState, List<BusinessIncomeSourceTypeVM> entity, string message) List();
    (ExecutionState executionState, BusinessIncomeSourceTypeVM entity, string message) Create(BusinessIncomeSourceTypeVM model);
    (ExecutionState executionState, BusinessIncomeSourceTypeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, BusinessIncomeSourceTypeVM entity, string message) Update(BusinessIncomeSourceTypeVM model);
    (ExecutionState executionState, BusinessIncomeSourceTypeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
