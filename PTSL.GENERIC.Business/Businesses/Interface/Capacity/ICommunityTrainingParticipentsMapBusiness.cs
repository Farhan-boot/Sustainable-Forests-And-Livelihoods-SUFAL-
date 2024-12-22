using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Business.Businesses.Interface.Capacity
{
    public interface ICommunityTrainingParticipentsMapBusiness : IBaseBusiness<CommunityTrainingParticipentsMap>
    {
        Task<(ExecutionState executionState, IList<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message)> GetCommunityTrainingParticipentsMapByFilter(CommunityTrainingFilterByBeneficiaryVM filterData);
    }
}
