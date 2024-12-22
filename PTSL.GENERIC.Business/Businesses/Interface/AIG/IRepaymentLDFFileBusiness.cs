using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Business.Businesses.Interface.AIG
{
    public interface IRepaymentLDFFileBusiness : IBaseBusiness<RepaymentLDFFile>
    {
        Task<(ExecutionState executionState, List<RepaymentLDFFile> entity, string message)> GetRepaymentLDFFileByRepaymentId(long repaymentId);
    }
}