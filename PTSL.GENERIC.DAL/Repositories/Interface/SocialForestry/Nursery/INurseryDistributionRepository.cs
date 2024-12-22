using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Nursery
{
    public interface INurseryDistributionRepository : IBaseRepository<NurseryDistribution>
    {
        Task<(ExecutionState executionState, NurseryInformation entity, string message)> GetNursaryDistributionsByNurseryIdAsync(long id);

    }
}