using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting
{
    public interface IRealizationBusiness : IBaseBusiness<Realization>
    {
        Task<(ExecutionState executionState, DefaultRealizationDataVM data, string message)> GetDefaultRealizationData(long cuttingPlantationId);
        Task<(ExecutionState executionState, List<Realization> data, string message)> GetRealizationsByCuttingId(long id);
    }
}