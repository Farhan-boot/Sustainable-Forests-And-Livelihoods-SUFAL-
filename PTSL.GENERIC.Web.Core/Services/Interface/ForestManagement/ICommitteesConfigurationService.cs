using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement
{
    public interface ICommitteesConfigurationService
    {
        (ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message) List();
        (ExecutionState executionState, CommitteesConfigurationVM entity, string message) Create(CommitteesConfigurationVM model);
        (ExecutionState executionState, CommitteesConfigurationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CommitteesConfigurationVM entity, string message) Update(CommitteesConfigurationVM model);
        (ExecutionState executionState, CommitteesConfigurationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message) GetCommitteesConfigurationByCommitteeTypeConfigurationId(long id);
    }
}