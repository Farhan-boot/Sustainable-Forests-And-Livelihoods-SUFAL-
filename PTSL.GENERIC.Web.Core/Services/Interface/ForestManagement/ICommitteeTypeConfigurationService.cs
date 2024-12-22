using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement
{
    public interface ICommitteeTypeConfigurationService
    {
        (ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message) List();
        (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) Create(CommitteeTypeConfigurationVM model);
        (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) Update(CommitteeTypeConfigurationVM model);
        (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);

        (ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message) GetCommitteeTypeConfigurationByFcvOrVcfId(long id);
    }
}