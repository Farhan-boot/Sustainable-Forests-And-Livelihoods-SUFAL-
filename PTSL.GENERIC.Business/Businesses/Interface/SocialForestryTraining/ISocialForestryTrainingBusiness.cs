using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining
{
    public interface ISocialForestryTrainingBusiness : IBaseBusiness<Common.Entity.SocialForestryTraining.SocialForestryTraining>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long SocialForestryTrainingParticipentsMapId);

        Task<(ExecutionState executionState, IList<Common.Entity.SocialForestryTraining.SocialForestryTraining> entity, string message)> GetByFilterVM(SocialForestryTrainingFilterVM filter);
    }
}