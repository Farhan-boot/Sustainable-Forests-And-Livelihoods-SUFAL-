using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface IForestRangeBusiness : IBaseBusiness<ForestRange>
    {
        Task<(ExecutionState executionState, IQueryable<ForestRange> entity, string message)> ListByForestDivision(long forestDivisionId);
    }
}
