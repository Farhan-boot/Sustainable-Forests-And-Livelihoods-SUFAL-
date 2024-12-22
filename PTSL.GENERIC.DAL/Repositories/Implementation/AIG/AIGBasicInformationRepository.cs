using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.DAL.Repositories.Interface.AIG;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.AIG
{
    public class AIGBasicInformationRepository : BaseRepository<AIGBasicInformation>, IAIGBasicInformationRepository
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public AIGBasicInformationRepository(GENERICWriteOnlyCtx writeOnlyCtx, GENERICReadOnlyCtx readOnlyCtx) : base(writeOnlyCtx, readOnlyCtx)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public async Task<bool> IsLoanCleared(long surveyId, int ldfCount = 0)
        {
            var total = await _readOnlyCtx.Set<RepaymentLDF>()
                .Where(x => x.AIGBasicInformation!.SurveyId == surveyId)
                .WhereIf(ldfCount > 0, x => x.AIGBasicInformation!.LDFCount == ldfCount)
                .Select(x => x.IsPaymentCompleted)
                .ToListAsync();

            return total.Count == total.Where(x => x).Count();
        }
    }
}