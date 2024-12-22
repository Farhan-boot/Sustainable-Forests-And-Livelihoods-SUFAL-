using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.TransactionMangement
{
    public interface ITransactionFilesService
    {
        (ExecutionState executionState, List<TransactionFilesVM> entity, string message) List();
        (ExecutionState executionState, TransactionFilesVM entity, string message) Create(TransactionFilesVM model);
        (ExecutionState executionState, TransactionFilesVM entity, string message) GetById(long? id);
        (ExecutionState executionState, TransactionFilesVM entity, string message) Update(TransactionFilesVM model);
        (ExecutionState executionState, TransactionFilesVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}