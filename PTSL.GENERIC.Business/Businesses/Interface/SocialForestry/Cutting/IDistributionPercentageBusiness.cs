using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting
{
    public interface IDistributionPercentageBusiness : IBaseBusiness<DistributionPercentage>
    {
        Task<(ExecutionState executionState, List<DistributionPercentage> entity, string message)> CreateRangeAsync(List<DistributionPercentage> entity);
        Task<(ExecutionState executionState, List<DistributionPercentage> entity, string message)> UpdateRangeAsync(long id,List<DistributionPercentage> entity);
        Task<(ExecutionState executionState, IQueryable<DistributionPercentage> entity, string message)> GetByPlantationTypeId(long? id);

    }
}