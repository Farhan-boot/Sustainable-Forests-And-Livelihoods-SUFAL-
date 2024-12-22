using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IPlantationTypeService
    {
        (ExecutionState executionState, List<PlantationTypeVM> entity, string message) List();
        (ExecutionState executionState, PlantationTypeVM entity, string message) Create(PlantationTypeVM model);
        (ExecutionState executionState, PlantationTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PlantationTypeVM entity, string message) Update(PlantationTypeVM model);
        (ExecutionState executionState, PlantationTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}