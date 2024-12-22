using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement
{
    public interface ICommitteeManagementService
    {
        (ExecutionState executionState, List<CommitteeManagementVM> entity, string message) List();
        (ExecutionState executionState, CommitteeManagementVM entity, string message) Create(CommitteeManagementVM model);
        (ExecutionState executionState, CommitteeManagementVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CommitteeManagementVM entity, string message) Update(CommitteeManagementVM model);
        (ExecutionState executionState, CommitteeManagementVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, PaginationResutlVM<CommitteeManagementVM> entity, string message) GetByFilter(ExecutiveCommitteeFilterVM filter);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}