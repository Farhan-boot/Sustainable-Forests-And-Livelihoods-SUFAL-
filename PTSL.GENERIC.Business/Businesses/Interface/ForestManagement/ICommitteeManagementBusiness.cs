using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Business.Businesses.Interface.ForestManagement
{
    public interface ICommitteeManagementBusiness : IBaseBusiness<CommitteeManagement>
    {
        Task<(ExecutionState executionState, PaginationResutl<CommitteeManagement> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filterData);
        Task<(ExecutionState executionState, CommitteeMemberCount entity, string message)> GetTotalFcvVcfAndExecutiveSubExecutive(ForestCivilLocationFilter filter);
    }
}