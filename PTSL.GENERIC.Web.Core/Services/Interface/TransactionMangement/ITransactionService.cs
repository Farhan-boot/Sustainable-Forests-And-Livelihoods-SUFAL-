using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.TransactionMangement
{
    public interface ITransactionService
    {
        (ExecutionState executionState, List<TransactionVM> entity, string message) List();
        (ExecutionState executionState, TransactionVM entity, string message) Create(TransactionVM model);
        (ExecutionState executionState, TransactionVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TransactionVM entity, string message) GetDetails(long? id);
        (ExecutionState executionState, TransactionVM entity, string message) Update(TransactionVM model);
        (ExecutionState executionState, TransactionVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, TransactionDashboardVM entity, string message) DashboardData();
        (ExecutionState executionState, List<TransactionDateVM> entity, string message) ListDate(long financialYearId);
        (ExecutionState executionState, List<TransactionVM> entity, string message) GetByFilter(TransactionFilterVM filter);
    }
}
