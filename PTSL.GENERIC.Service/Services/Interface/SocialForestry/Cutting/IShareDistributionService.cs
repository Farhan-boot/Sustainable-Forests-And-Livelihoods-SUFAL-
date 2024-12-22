using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public interface IShareDistributionService : IBaseService<ShareDistributionVM, ShareDistribution>
    {
        Task<(ExecutionState executionState, DefaultDistributionDataVM data, string message)> GetDefaultDistributionData(long cuttingPlantationId);
        Task<(ExecutionState executionState, List<ShareDistributionVM> data, string message)> ListByCuttingPlantation(long cuttingPlantationId);
    }
}