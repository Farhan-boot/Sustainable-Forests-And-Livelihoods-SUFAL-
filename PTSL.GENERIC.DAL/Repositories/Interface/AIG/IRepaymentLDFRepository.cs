using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.DAL.Repositories.Interface.AIG
{
    public interface IRepaymentLDFRepository : IBaseRepository<RepaymentLDF>
    {
        Task<int> GetMaxRepaymentSerial(long aigBasicInformationId);
        Task<List<RepaymentLDF>> GetNextUncompletedRepayments(long aigBasicInformationId, int repaymentSerial);
        Task<bool> IsPreviousRepaymentCompleted(long aigBasicInformationId, int repaymentSerial);
    }
}