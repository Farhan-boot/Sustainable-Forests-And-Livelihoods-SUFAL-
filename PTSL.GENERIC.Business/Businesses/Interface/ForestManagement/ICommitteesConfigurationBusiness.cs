using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.ForestManagement
{
    public interface ICommitteesConfigurationBusiness : IBaseBusiness<CommitteesConfiguration>
    {
        Task<(ExecutionState executionState, List<CommitteesConfiguration> entity, string message)> GetCommitteesConfigurationByCommitteeTypeConfigurationId(long id);
    }
}