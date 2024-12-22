using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public interface IRealizationService : IBaseService<RealizationVM, Realization>
    {
        Task<(ExecutionState executionState, DefaultRealizationDataVM data, string message)> GetDefaultRealizationData(long cuttingPlantationId);
        Task<(ExecutionState executionState, List<RealizationVM> data, string message)> GetRealizationsByCuttingId(long id);
    }
}