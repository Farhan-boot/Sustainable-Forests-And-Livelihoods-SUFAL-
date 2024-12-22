using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IPlantationCauseOfDamageService
    {
        (ExecutionState executionState, List<PlantationCauseOfDamageVM> entity, string message) List();
        (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) Create(PlantationCauseOfDamageVM model);
        (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) Update(PlantationCauseOfDamageVM model);
        (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}