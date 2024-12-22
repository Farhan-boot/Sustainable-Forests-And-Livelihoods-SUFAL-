using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface ILiveStockTypeService
    {
        (ExecutionState executionState, List<LiveStockTypeVM> entity, string message) List();
        (ExecutionState executionState, LiveStockTypeVM entity, string message) Create(LiveStockTypeVM model);
        (ExecutionState executionState, LiveStockTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LiveStockTypeVM entity, string message) Update(LiveStockTypeVM model);
        (ExecutionState executionState, LiveStockTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
