using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IPlantationFileService
    {
        (ExecutionState executionState, List<PlantationFileVM> entity, string message) List();
        (ExecutionState executionState, PlantationFileVM entity, string message) Create(PlantationFileVM model);
        (ExecutionState executionState, PlantationFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PlantationFileVM entity, string message) Update(PlantationFileVM model);
        (ExecutionState executionState, PlantationFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}