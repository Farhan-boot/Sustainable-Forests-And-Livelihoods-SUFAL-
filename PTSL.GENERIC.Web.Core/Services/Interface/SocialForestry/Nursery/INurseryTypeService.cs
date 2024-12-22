using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery
{
    public interface INurseryTypeService
    {
        (ExecutionState executionState, List<NurseryTypeVM> entity, string message) List();
        (ExecutionState executionState, NurseryTypeVM entity, string message) Create(NurseryTypeVM model);
        (ExecutionState executionState, NurseryTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NurseryTypeVM entity, string message) Update(NurseryTypeVM model);
        (ExecutionState executionState, NurseryTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}