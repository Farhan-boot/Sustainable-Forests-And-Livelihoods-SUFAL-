using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.PermissionSettings;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Business.Businesses.Interface.PermissionSettings
{
    public interface IPermissionHeaderSettingsBusiness : IBaseBusiness<PermissionHeaderSettings>
    {
        Task<(ExecutionState executionState, List<PermissionHeaderSettings> entity, string message)> GetPermissionHeaderSettingsByModuleEnumId(long moduleEnumId);
        Task<(ExecutionState executionState, List<PermissionHeaderSettings> entity, string message)> GetByFilter(ExecutiveCommitteeFilterVM filterData);
        Task<(ExecutionState executionState, long data, string message)> GetPermissionHeaderIdByControllerName(string controller);
    }
}