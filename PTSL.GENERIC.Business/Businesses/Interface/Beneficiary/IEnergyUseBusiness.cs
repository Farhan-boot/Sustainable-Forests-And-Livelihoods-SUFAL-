using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface IEnergyUseBusiness : IBaseBusiness<EnergyUse>
    {
        Task<(ExecutionState executionState, IList<EnergyUsesPercentageVM> entity, string message)> GetEnergyUsesPercentage(ForestCivilLocationFilter filter);
    }
}
