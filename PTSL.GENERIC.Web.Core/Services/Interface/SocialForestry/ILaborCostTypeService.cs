using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ILaborCostTypeService
    {
        (ExecutionState executionState, List<LaborCostTypeVM> entity, string message) List();
        (ExecutionState executionState, LaborCostTypeVM entity, string message) Create(LaborCostTypeVM model);
        (ExecutionState executionState, LaborCostTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LaborCostTypeVM entity, string message) Update(LaborCostTypeVM model);
        (ExecutionState executionState, LaborCostTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}