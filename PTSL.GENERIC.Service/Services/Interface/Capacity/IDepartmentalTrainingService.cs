using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Interface.Capacity
{
    public interface IDepartmentalTrainingService : IBaseService<DepartmentalTrainingVM, DepartmentalTraining>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long DepartmentalTrainingParticipentsMapId);
        Task<(ExecutionState executionState, IList<DepartmentalTrainingVM> entity, string message)> GetByFilter(long finalYearId);
        Task<(ExecutionState executionState, PaginationResutl<DepartmentalTrainingVM> entity, string message)> GetByFilterVM(DepartmentalTrainingFilterVM filter);
    }
}
