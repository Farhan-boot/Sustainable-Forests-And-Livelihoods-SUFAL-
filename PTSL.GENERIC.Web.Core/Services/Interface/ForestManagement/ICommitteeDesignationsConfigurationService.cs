using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement
{
    public interface ICommitteeDesignationsConfigurationService
    {
        (ExecutionState executionState, List<CommitteeDesignationsConfigurationVM> entity, string message) List();
        (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) Create(CommitteeDesignationsConfigurationVM model);
        (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) Update(CommitteeDesignationsConfigurationVM model);
        (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<CommitteeDesignationsConfigurationVM> entity, string message) GetCommitteeDesignationsConfigurationByCommitteesConfigurationId(long id);

    }
}