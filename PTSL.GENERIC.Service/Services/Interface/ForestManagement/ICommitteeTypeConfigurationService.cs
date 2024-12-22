using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.ForestManagement
{
    public interface ICommitteeTypeConfigurationService : IBaseService<CommitteeTypeConfigurationVM, CommitteeTypeConfiguration>
    {
        Task<(ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message)> GetCommitteeTypeConfigurationByFcvOrVcfId(long id);
    }
}