using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.CipManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.CipManagement
{
    public interface ICipTeamMemberService
    {
        (ExecutionState executionState, List<CipTeamMemberVM> entity, string message) List();
        (ExecutionState executionState, CipTeamMemberVM entity, string message) Create(CipTeamMemberVM model);
        (ExecutionState executionState, CipTeamMemberVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CipTeamMemberVM entity, string message) Update(CipTeamMemberVM model);
        (ExecutionState executionState, CipTeamMemberVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}