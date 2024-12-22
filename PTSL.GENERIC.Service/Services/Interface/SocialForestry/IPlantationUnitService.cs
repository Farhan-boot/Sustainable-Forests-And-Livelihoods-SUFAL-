using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry
{
    public interface IPlantationUnitService : IBaseService<PlantationUnitVM, PlantationUnit>
    {
        Task<(ExecutionState executionState, List<PlantationUnitVM> entity, string message)> ListByType(UnitType unitType);
    }
}