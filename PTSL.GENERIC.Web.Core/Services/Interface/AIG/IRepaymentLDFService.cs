using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface IRepaymentLDFService
    {
        (ExecutionState executionState, List<RepaymentLDFVM> entity, string message) List();
        (ExecutionState executionState, RepaymentLDFVM entity, string message) Create(RepaymentLDFVM model);
        (ExecutionState executionState, RepaymentLDFVM entity, string message) GetById(long? id);
        (ExecutionState executionState, RepaymentLDFVM entity, string message) Update(RepaymentLDFVM model);
        (ExecutionState executionState, RepaymentLDFVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<RepaymentLDFVM> entity, string message) GetListBySecondLDFId(long ldfId);
        (ExecutionState executionState, List<RepaymentLDFVM> entity, string message) GetListByFirstLDFId(long ldfId);
        (ExecutionState executionState, List<RepaymentLDFVM> entity, string message) GetListByAIGId(long ldfId);
        (ExecutionState executionState, RepaymentLDFVM entity, string message) CompletePayment(CompleteRepaymentVM completeRepayment);
        (ExecutionState executionState, RepaymentLDFVM entity, string message) LockUnlockPayment(long repaymentId, bool shouldLock);
        (ExecutionState executionState, List<RepaymentLDFVM> entity, string message) GetListWithProgress(long aigId);
        (ExecutionState executionState, RepaymentLDFVM entity, string message) RemovePayment(long repaymentId);
        (ExecutionState executionState, List<RepaymentLDFHistoryVM> entity, string message) ListHistory(long ldfId);
        (ExecutionState executionState, List<RepaymentLDFOutstandingLoanPerBorrowerVM> entity, string message) OutstandingLoanPerBorrowerList(RepaymentLDFOutstandingLoanPerBorrowerFilterVM filter);
        (ExecutionState executionState, List<DateWiseRepaymentReportVM> entity, string message) DateWiseRepaymentReport(DateWiseRepaymentReportFilterVM filter);
    }
}