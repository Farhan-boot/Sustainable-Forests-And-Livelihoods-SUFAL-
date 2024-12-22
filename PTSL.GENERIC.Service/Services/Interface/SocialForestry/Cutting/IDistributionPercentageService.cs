using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public interface IDistributionPercentageService : IBaseService<DistributionPercentageVM, DistributionPercentage>
    {
        Task<(ExecutionState executionState, List<DistributionPercentageVM> entity, string message)> CreateRangeAsync(DistributionPercentageCustomVM model);
        Task<(ExecutionState executionState, List<DistributionPercentageVM> entity, string message)> UpdateRangeAsync(long id, DistributionPercentageCustomVM model);
        Task<(ExecutionState executionState, IList<DistributionPercentageVM> entity, string message)> GetByPlantationTypeId(long? id);

    }
}