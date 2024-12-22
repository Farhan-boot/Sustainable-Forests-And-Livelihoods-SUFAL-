using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Nursery;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Nursery
{
    public class NurseryDistributionRepository : BaseRepository<NurseryDistribution>, INurseryDistributionRepository
    {
        public NurseryDistributionRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }

        public Task<(ExecutionState executionState, NurseryInformation entity, string message)> GetNursaryDistributionsByNurseryIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}