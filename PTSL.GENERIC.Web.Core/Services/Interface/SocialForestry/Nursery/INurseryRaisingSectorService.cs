using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery
{
    public interface INurseryRaisingSectorService
    {
        (ExecutionState executionState, List<NurseryRaisingSectorVM> entity, string message) List();
        (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) Create(NurseryRaisingSectorVM model);
        (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) Update(NurseryRaisingSectorVM model);
        (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}