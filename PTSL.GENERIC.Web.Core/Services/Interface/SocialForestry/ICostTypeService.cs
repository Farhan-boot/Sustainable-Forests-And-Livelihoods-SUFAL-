using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ICostTypeService
    {
        (ExecutionState executionState, List<CostTypeVM> entity, string message) List();
        (ExecutionState executionState, CostTypeVM entity, string message) Create(CostTypeVM model);
        (ExecutionState executionState, CostTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CostTypeVM entity, string message) Update(CostTypeVM model);
        (ExecutionState executionState, CostTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}