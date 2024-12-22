using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface.Capacity
{
    public interface IDepartmentalTrainingBusiness : IBaseBusiness<DepartmentalTraining>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long DepartmentalTrainingParticipentsMapId);
        Task<(ExecutionState executionState, IQueryable<DepartmentalTraining> entity, string message)> GetByFilter(long finalYearId);
        Task<(ExecutionState executionState, PaginationResutl<DepartmentalTraining> entity, string message)> GetByFilterVM(DepartmentalTrainingFilterVM filter);
    }
}
