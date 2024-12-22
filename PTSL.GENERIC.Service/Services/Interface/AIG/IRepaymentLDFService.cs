using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public interface IRepaymentLDFService : IBaseService<RepaymentLDFVM, RepaymentLDF>
    {
        Task<(ExecutionState executionState, RepaymentLDFVM entity, string message)> CompletePayment(CompleteRepaymentVM completeRepayment, long userId);
        Task<(ExecutionState executionState, IList<RepaymentLDFVM> entity, string message)> GetListByAIGId(long ldfId);
        Task<(ExecutionState executionState, IList<RepaymentLDFVM> entity, string message)> GetListByFirstLDFId(long ldfId);
        Task<(ExecutionState executionState, IList<RepaymentLDFVM> entity, string message)> GetListBySecondLDFId(long ldfId);
        Task<(ExecutionState executionState, IList<RepaymentLDFVM> entity, string message)> GetListWithProgress(long aigId);
        Task<(ExecutionState executionState, IList<RepaymentLDFHistoryVM> entity, string message)> ListHistory(long repaymentId);
        Task<(ExecutionState executionState, RepaymentLDFVM entity, string message)> LockUnlockPayment(long repaymentId, long userId, bool shouldLock);
        Task<(ExecutionState executionState, RepaymentLDFVM entity, string message)> RemovePayment(long repaymentId, long userId);
    }
}