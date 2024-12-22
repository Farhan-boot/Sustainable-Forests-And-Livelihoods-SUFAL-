using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IProjectTypeService
    {
        (ExecutionState executionState, List<ProjectTypeVM> entity, string message) List();
        (ExecutionState executionState, ProjectTypeVM entity, string message) Create(ProjectTypeVM model);
        (ExecutionState executionState, ProjectTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ProjectTypeVM entity, string message) Update(ProjectTypeVM model);
        (ExecutionState executionState, ProjectTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}