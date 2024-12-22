using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Business.Businesses.Interface.Archive
{
    public interface IRegistrationArchiveBusiness : IBaseBusiness<RegistrationArchive>
    {
        Task<(ExecutionState executionState, List<RegistrationArchive> entity, string message)> GetRegistrationArchiveByFilter(MeetingFilterVM filterData);
    }
}