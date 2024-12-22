using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Archive;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.Archive
{
    public interface IRegistrationArchiveService : IBaseService<RegistrationArchiveVM, RegistrationArchive>
    {
        Task<(ExecutionState executionState, List<RegistrationArchiveVM> entity, string message)> GetRegistrationArchiveByFilter(MeetingFilterVM filterData);
    }
}