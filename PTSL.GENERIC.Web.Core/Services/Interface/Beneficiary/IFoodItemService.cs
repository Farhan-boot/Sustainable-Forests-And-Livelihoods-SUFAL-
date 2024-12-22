using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IFoodItemService
    {
        (ExecutionState executionState, List<FoodItemVM> entity, string message) List();
        (ExecutionState executionState, FoodItemVM entity, string message) Create(FoodItemVM model);
        (ExecutionState executionState, FoodItemVM entity, string message) GetById(long? id);
        (ExecutionState executionState, FoodItemVM entity, string message) Update(FoodItemVM model);
        (ExecutionState executionState, FoodItemVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
