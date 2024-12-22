using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestryMeeting
{
    public interface ISocialForestryMeetingBusiness : IBaseBusiness<Common.Entity.SocialForestryMeeting.SocialForestryMeeting>
    {

        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long SocialForestryMeetingParticipentsMapId);

        //Task<(ExecutionState executionState, IList<Common.Entity.SocialForestryTraining.SocialForestryTraining> entity, string message)> GetByFilterVM(SocialForestryTrainingFilterVM filter);
    }
}