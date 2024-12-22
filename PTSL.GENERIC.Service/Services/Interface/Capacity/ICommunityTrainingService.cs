using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Interface.Capacity
{
    public interface ICommunityTrainingService : IBaseService<CommunityTrainingVM, CommunityTraining>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long communityTrainingParticipentsMapId);
        Task<(ExecutionState executionState, PaginationResutl<CommunityTrainingVM> entity, string message)> GetTrainingByFilter(CommunityTrainingFilterVM filterData);
    }
}
