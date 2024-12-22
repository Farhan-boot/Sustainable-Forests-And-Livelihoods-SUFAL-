using System.Collections.Generic;
using System.Threading.Tasks;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Model.CustomModel;

namespace PTSL.GENERIC.Business.Businesses.Interface.CipManagement
{
    public interface ICipTeamBusiness : IBaseBusiness<CipTeam>
    {
        Task<(ExecutionState executionState, PaginationResutl<CipTeam> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filterData);
    }
}