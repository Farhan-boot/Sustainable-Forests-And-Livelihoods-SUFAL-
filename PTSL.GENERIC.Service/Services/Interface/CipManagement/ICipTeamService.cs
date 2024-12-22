using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.CipManagement
{
    public interface ICipTeamService : IBaseService<CipTeamVM, CipTeam>
    {
        Task<(ExecutionState executionState, PaginationResutl<CipTeamVM> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filter);
    }
}