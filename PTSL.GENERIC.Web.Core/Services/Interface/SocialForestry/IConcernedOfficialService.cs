using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IConcernedOfficialService
    {
        (ExecutionState executionState, List<ConcernedOfficialVM> entity, string message) List();
        (ExecutionState executionState, ConcernedOfficialVM entity, string message) Create(ConcernedOfficialVM model);
        (ExecutionState executionState, ConcernedOfficialVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ConcernedOfficialVM entity, string message) Update(ConcernedOfficialVM model);
        (ExecutionState executionState, ConcernedOfficialVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}