using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;

namespace PTSL.GENERIC.Business.Businesses.Interface.TransactionMangement
{
    public interface ITransactionBusiness : IBaseBusiness<Transaction>
    {
        Task<(ExecutionState executionState, TransactionDashboardVM entity, string message)> DashboardData();
        Task<(ExecutionState executionState, Transaction entity, string message)> GetDetails(long key);
        Task<(ExecutionState executionState, List<long> entity, string message)> DivisionListByFinancialYear(long financialYearId);
        Task<(ExecutionState executionState, IList<TransactionDateVM> entity, string message)> ListDate(long financialYearId);
        Task<(ExecutionState executionState, IList<Transaction> entity, string message)> GetByFilter(TransactionFilterVM filter);
    }
}
