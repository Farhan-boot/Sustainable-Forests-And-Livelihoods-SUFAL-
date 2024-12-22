using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup
{
    public interface ICommitteeDesignationService
    {
        (ExecutionState executionState, List<CommitteeDesignationVM> entity, string message) List();
        (ExecutionState executionState, CommitteeDesignationVM entity, string message) Create(CommitteeDesignationVM model);
        (ExecutionState executionState, CommitteeDesignationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CommitteeDesignationVM entity, string message) Update(CommitteeDesignationVM model);
        (ExecutionState executionState, CommitteeDesignationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<CommitteeDesignationVM> entity, string message) ListByFilter(CommitteeDesignationFilterVM filter);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}
