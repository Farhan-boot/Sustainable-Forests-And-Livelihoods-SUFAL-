using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface IForestDivisionBusiness : IBaseBusiness<ForestDivision>
    {
        Task<(ExecutionState executionState, IQueryable<ForestDivision> entity, string message)> ListByForestCircle(long forestCircleId);
        Task<(ExecutionState executionState, IQueryable<ForestDivision> entity, string message)> ListByMultipleForestCircle(List<long> forestCircleIds);
    }
}
