using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestryTraining
{
    public interface ISocialForestryTrainingService : IBaseService<SocialForestryTrainingVM, Common.Entity.SocialForestryTraining.SocialForestryTraining>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long SocialForestryTrainingParticipentsMapId);
        Task<(ExecutionState executionState, IList<SocialForestryTrainingVM> entity, string message)> GetByFilterVM(SocialForestryTrainingFilterVM filter);
    }
}