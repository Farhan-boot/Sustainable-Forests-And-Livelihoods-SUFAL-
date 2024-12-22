using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface ITypeOfHouseService
    {
        (ExecutionState executionState, List<TypeOfHouseVM> entity, string message) List();
        (ExecutionState executionState, TypeOfHouseVM entity, string message) Create(TypeOfHouseVM model);
        (ExecutionState executionState, TypeOfHouseVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TypeOfHouseVM entity, string message) Update(TypeOfHouseVM model);
        (ExecutionState executionState, TypeOfHouseVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}