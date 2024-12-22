using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.Interface
{
    public interface IMeetingService : IBaseService<MeetingVM, Meeting>
    {
        Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long mapId);
        Task<(ExecutionState executionState, PaginationResutl<MeetingVM> entity, string message)> GetMeetingByFilter(MeetingFilterVM filterData);
    }
}

