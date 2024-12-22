using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.TransactionMangement
{
    public interface ITransactionService : IBaseService<TransactionVM, Transaction>
    {
        Task<(ExecutionState executionState, List<TransactionVM> entity, string message)> GetByFilter(TransactionFilterVM filter);
        public Task<(ExecutionState executionState, TransactionVM entity, string message)> GetDetails(long key);
    }
}
