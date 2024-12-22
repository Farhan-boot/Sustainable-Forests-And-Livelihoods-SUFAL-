using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.ForestManagement
{
    public interface ICommitteeDesignationsConfigurationService : IBaseService<CommitteeDesignationsConfigurationVM, CommitteeDesignationsConfiguration>
    {
        Task<(ExecutionState executionState, List<CommitteeDesignationsConfigurationVM> entity, string message)> GetCommitteeDesignationsConfigurationByCommitteesConfigurationId(long id);
    }
}