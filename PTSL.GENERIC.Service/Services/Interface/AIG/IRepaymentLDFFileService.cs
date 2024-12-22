using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public interface IRepaymentLDFFileService : IBaseService<RepaymentLDFFileVM, RepaymentLDFFile>
    {
        Task<(ExecutionState executionState, List<RepaymentLDFFileVM> entity, string message)> GetRepaymentLDFFileByRepaymentId(long repaymentId);
    }
}