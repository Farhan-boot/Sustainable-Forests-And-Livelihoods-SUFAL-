using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public interface ICuttingPlantationService : IBaseService<CuttingPlantationVM, CuttingPlantation>
    {
        Task<(ExecutionState executionState, IList<CuttingPlantationVM> entity, string message)> ListByNewRaised(long newRaisedId);

        Task<(ExecutionState executionState, List<CuttingPlantationVM> data, string message)> ListByFilter(NewRaisedPlantationFilter filter);
    }
}