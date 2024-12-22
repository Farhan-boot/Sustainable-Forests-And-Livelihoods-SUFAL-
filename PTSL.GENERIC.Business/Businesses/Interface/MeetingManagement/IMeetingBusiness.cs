using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Business.Businesses.Interface
{
    public interface IMeetingBusiness : IBaseBusiness<Meeting>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long mapId);
        Task<(ExecutionState executionState, PaginationResutl<Meeting> entity, string message)> GetMeetingByFilter(MeetingFilterVM filterData);
    }
}
