using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.Patrolling
{
    public interface IPatrollingScheduleInformetionService : IBaseService<PatrollingScheduleInformetionVM, PatrollingScheduleInformetion>
    {
        Task<(ExecutionState executionState, List<PatrollingScheduleInformetionVM> entity, string message)> GetPatrollingScheduleInformetionByFilter(PatrollingScheduleFilterVM filterData);
    }
}
