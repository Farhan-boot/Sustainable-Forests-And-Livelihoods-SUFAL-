using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface INaturalIncomeSourceTypeService
    {
        (ExecutionState executionState, List<NaturalIncomeSourceTypeVM> entity, string message) List();
        (ExecutionState executionState, NaturalIncomeSourceTypeVM entity, string message) Create(NaturalIncomeSourceTypeVM model);
        (ExecutionState executionState, NaturalIncomeSourceTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NaturalIncomeSourceTypeVM entity, string message) Update(NaturalIncomeSourceTypeVM model);
        (ExecutionState executionState, NaturalIncomeSourceTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
