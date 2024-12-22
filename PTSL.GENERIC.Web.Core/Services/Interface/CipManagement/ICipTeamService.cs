using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.CipManagement
{
    public interface ICipTeamService
    {
        (ExecutionState executionState, List<CipTeamVM> entity, string message) List();
        (ExecutionState executionState, CipTeamVM entity, string message) Create(CipTeamVM model);
        (ExecutionState executionState, CipTeamVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CipTeamVM entity, string message) Update(CipTeamVM model);
        (ExecutionState executionState, CipTeamVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, PaginationResutlVM<CipTeamVM> entity, string message) GetByFilter(ExecutiveCommitteeFilterVM filter);
    }
}