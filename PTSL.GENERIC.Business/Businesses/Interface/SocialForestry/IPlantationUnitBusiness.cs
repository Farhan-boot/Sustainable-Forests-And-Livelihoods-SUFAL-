using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.SocialForestry;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry
{
    public interface IPlantationUnitBusiness : IBaseBusiness<PlantationUnit>
    {
        Task<(ExecutionState executionState, List<PlantationUnit> entity, string message)> ListByType(UnitType unitType);
    }
}