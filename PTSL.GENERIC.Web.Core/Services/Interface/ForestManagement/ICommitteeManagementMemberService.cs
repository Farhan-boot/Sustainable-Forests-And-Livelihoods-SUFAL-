using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement
{
    public interface ICommitteeManagementMemberService
    {
        (ExecutionState executionState, List<CommitteeManagementMemberVM> entity, string message) List();
        (ExecutionState executionState, CommitteeManagementMemberVM entity, string message) Create(CommitteeManagementMemberVM model);
        (ExecutionState executionState, CommitteeManagementMemberVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CommitteeManagementMemberVM entity, string message) Update(CommitteeManagementMemberVM model);
        (ExecutionState executionState, CommitteeManagementMemberVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}