using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.Interface.Capacity
{
    public interface ICommunityTrainingParticipentsMapService : IBaseService<CommunityTrainingParticipentsMapVM, CommunityTrainingParticipentsMap>
    {
        Task<(ExecutionState executionState, IList<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message)> GetCommunityTrainingParticipentsMapByFilter(CommunityTrainingFilterByBeneficiaryVM filterData);
    }
}
