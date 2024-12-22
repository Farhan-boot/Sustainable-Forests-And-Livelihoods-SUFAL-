using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface INgoBusiness : IBaseBusiness<Ngo>
    {
        Task<(ExecutionState executionState, Ngo entity, List<ForestDivision> forestDivisions, string message)> GetCustomAsync(long key);
        Task<(ExecutionState executionState, List<Ngo> entity, string message)> ListByForestDivisions(List<long> divisions);
    }
}
