using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

using System.Collections.Generic;
using System.Threading.Tasks;
using PTSL.GENERIC.Common.Model.CustomModel;


namespace PTSL.GENERIC.Business.Businesses.Interface.Capacity
{
    public interface ICommunityTrainingBusiness : IBaseBusiness<CommunityTraining>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long communityTrainingParticipentsMapId);
        Task<(ExecutionState executionState, PaginationResutl<CommunityTraining> entity, string message)> GetTrainingByFilter(CommunityTrainingFilterVM filterData);

    }
}
