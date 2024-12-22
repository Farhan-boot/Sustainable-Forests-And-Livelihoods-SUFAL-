using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface.PatrollingSchedulingInformetion
{
    public interface IPatrollingSchedulingBusiness : IBaseBusiness<PatrollingScheduling>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long patrollingSchedulingParticipentsMapId);
        Task<(ExecutionState executionState, PaginationResutl<PatrollingScheduling> entity, string message)> GetTrainingByFilter(PatrollingSchedulingFilterVM filterData);
    }
}
