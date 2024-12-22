using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Business.Businesses.Interface.Patrolling
{
    public interface IPatrollingScheduleInformetionBusiness : IBaseBusiness<PatrollingScheduleInformetion>
    {
        Task<(ExecutionState executionState, List<PatrollingScheduleInformetion> entity, string message)> GetPatrollingScheduleInformetionByFilter(PatrollingScheduleFilterVM filterData);
    }
}
