using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IPlantationTopographyService
    {
        (ExecutionState executionState, List<PlantationTopographyVM> entity, string message) List();
        (ExecutionState executionState, PlantationTopographyVM entity, string message) Create(PlantationTopographyVM model);
        (ExecutionState executionState, PlantationTopographyVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PlantationTopographyVM entity, string message) Update(PlantationTopographyVM model);
        (ExecutionState executionState, PlantationTopographyVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}