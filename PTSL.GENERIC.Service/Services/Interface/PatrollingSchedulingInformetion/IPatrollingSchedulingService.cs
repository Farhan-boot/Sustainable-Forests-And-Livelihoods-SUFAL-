using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Interface.PatrollingSchedulingInformetion
{
    public interface IPatrollingSchedulingService : IBaseService<PatrollingSchedulingVM, PatrollingScheduling>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long patrollingSchedulingParticipentsMapId);
        Task<(ExecutionState executionState, PaginationResutl<PatrollingSchedulingVM> entity, string message)> GetTrainingByFilter(PatrollingSchedulingFilterVM filterData);
    }
}
