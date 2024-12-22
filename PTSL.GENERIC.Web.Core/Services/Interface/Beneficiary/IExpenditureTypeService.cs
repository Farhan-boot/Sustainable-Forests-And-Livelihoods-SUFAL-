using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IExpenditureTypeService
    {
        (ExecutionState executionState, List<ExpenditureTypeVM> entity, string message) List();
        (ExecutionState executionState, ExpenditureTypeVM entity, string message) Create(ExpenditureTypeVM model);
        (ExecutionState executionState, ExpenditureTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ExpenditureTypeVM entity, string message) Update(ExpenditureTypeVM model);
        (ExecutionState executionState, ExpenditureTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
