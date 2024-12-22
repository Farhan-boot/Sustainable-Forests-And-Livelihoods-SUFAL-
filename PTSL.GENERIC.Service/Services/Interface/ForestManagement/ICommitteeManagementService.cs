using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.ForestManagement
{
    public interface ICommitteeManagementService : IBaseService<CommitteeManagementVM, CommitteeManagement>
    {
        Task<(ExecutionState executionState, PaginationResutl<CommitteeManagementVM> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filter);
    }
}