using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting
{
    public interface IShareDistributionBusiness : IBaseBusiness<ShareDistribution>
    {
        Task<(ExecutionState executionState, DefaultDistributionDataVM data, string message)> GetDefaultDistributionData(long cuttingPlantationId);
        Task<(ExecutionState executionState, List<ShareDistribution> data, string message)> ListByCuttingPlantation(long cuttingPlantationId);
    }
}