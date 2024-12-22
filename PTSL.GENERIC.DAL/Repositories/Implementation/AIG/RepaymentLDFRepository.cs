using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.DAL.Repositories.Interface.AIG;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.AIG
{
    public class RepaymentLDFRepository : BaseRepository<RepaymentLDF>, IRepaymentLDFRepository
    {
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public RepaymentLDFRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx)
        {
            _writeOnlyCtx = writeOnlyCtx;
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<int> GetMaxRepaymentSerial(long aigBasicInformationId)
        {
            return await _readOnlyCtx
                .Set<RepaymentLDF>()
                .Where(x => x.AIGBasicInformationId == aigBasicInformationId)
                .MaxAsync(x => x.RepaymentSerial);
        }

        public async Task<List<RepaymentLDF>> GetNextUncompletedRepayments(long aigBasicInformationId, int repaymentSerial)
        {
            var nextRepayments = await _writeOnlyCtx.Set<RepaymentLDF>()
                .Where(x => x.AIGBasicInformationId == aigBasicInformationId)
                .Where(x => x.RepaymentSerial > repaymentSerial)
                .Where(x => x.IsPaymentCompleted == false)
                .ToListAsync();

            return nextRepayments;
        }

        public async Task<bool> IsPreviousRepaymentCompleted(long aigBasicInformationId, int repaymentSerial)
        {
            var previousPaymentCount = await _readOnlyCtx.Set<RepaymentLDF>()
                .CountAsync(x => x.RepaymentSerial < repaymentSerial
                    && x.IsPaymentCompleted == false
                    && x.AIGBasicInformationId == aigBasicInformationId);

            return previousPaymentCount == 0;
        }
    }
}