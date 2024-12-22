using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting
{
    public interface ICuttingPlantationBusiness : IBaseBusiness<CuttingPlantation>
    {
        Task<(ExecutionState executionState, IQueryable<CuttingPlantation> entity, string message)> ListByNewRaised(long newRaisedId);

        Task<(ExecutionState executionState, List<CuttingPlantation> entity, string message)> ListByFilter(NewRaisedPlantationFilter filter);
    }
}