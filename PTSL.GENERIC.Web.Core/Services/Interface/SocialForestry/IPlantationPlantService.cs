using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IPlantationPlantService
    {
        (ExecutionState executionState, List<PlantationPlantVM> entity, string message) List();
        (ExecutionState executionState, PlantationPlantVM entity, string message) Create(PlantationPlantVM model);
        (ExecutionState executionState, PlantationPlantVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PlantationPlantVM entity, string message) Update(PlantationPlantVM model);
        (ExecutionState executionState, PlantationPlantVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}