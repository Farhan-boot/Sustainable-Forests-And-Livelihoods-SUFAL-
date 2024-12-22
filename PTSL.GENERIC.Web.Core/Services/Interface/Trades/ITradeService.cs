using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Trades;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Trades;

public interface ITradeService
{
    (ExecutionState executionState, List<TradeVM> entity, string message) List();
    (ExecutionState executionState, TradeVM entity, string message) Create(TradeVM model);
    (ExecutionState executionState, TradeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, TradeVM entity, string message) Update(TradeVM model);
    (ExecutionState executionState, TradeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
