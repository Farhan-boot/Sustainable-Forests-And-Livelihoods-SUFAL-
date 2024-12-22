using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Service.Services.ForestManagement
{
    public interface ICommitteesConfigurationService : IBaseService<CommitteesConfigurationVM, CommitteesConfiguration>
    {
        Task<(ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message)> GetCommitteesConfigurationByCommitteeTypeConfigurationId(long id);
    }
}