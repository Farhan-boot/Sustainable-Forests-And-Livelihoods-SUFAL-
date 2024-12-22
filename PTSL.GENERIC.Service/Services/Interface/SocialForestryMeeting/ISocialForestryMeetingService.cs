using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestryMeeting
{
    public interface ISocialForestryMeetingService : IBaseService<SocialForestryMeetingVM, Common.Entity.SocialForestryMeeting.SocialForestryMeeting>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long SocialForestryMeetingParticipentsMapId);
        //Task<(ExecutionState executionState, IList<SocialForestryMeetingVM> entity, string message)> GetByFilterVM(SocialForestryMeetingFilterVM filter);
    }
}