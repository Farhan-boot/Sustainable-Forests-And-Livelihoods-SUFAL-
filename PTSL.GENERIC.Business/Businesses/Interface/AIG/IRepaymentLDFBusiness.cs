using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Business.Businesses.Interface.AIG
{
    public interface IRepaymentLDFBusiness : IBaseBusiness<RepaymentLDF>
    {
        Task<(ExecutionState executionState, RepaymentLDF entity, string message)> CompletePayment(CompleteRepaymentVM completeRepayment, long userId);
        Task<(ExecutionState executionState, List<DateWiseRepaymentReportVM> entity, string message)> DateWiseRepaymentReport(DateWiseRepaymentReportFilterVM filter);
        Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> GetListByAIGId(long aigId);
        Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> GetListByFirstLDFId(long ldfId);
        Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> GetListBySecondLDFId(long ldfId);
        Task<(ExecutionState executionState, IQueryable<RepaymentLDF> entity, string message)> GetListWithProgress(long aigId);
        Task<(ExecutionState executionState, IList<RepaymentLDFHistory> entity, string message)> ListHistory(long repaymentId);
        Task<(ExecutionState executionState, RepaymentLDF entity, string message)> LockUnlockPayment(long repaymentId, long userId, bool shouldLock);
        Task<(ExecutionState executionState, List<RepaymentLDFOutstandingLoanPerBorrowerVM> entity, string message)> OutstandingLoanPerBorrowerFilter(RepaymentLDFOutstandingLoanPerBorrowerFilterVM filter);
        Task<(ExecutionState executionState, RepaymentLDF entity, string message)> RemovePayment(long repaymentId, long userId);
    }
}