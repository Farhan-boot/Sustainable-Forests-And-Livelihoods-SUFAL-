using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IPlantationUnitService
    {
        (ExecutionState executionState, List<PlantationUnitVM> entity, string message) List();
        (ExecutionState executionState, PlantationUnitVM entity, string message) Create(PlantationUnitVM model);
        (ExecutionState executionState, PlantationUnitVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PlantationUnitVM entity, string message) Update(PlantationUnitVM model);
        (ExecutionState executionState, PlantationUnitVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<PlantationUnitVM> entity, string message) ListByType(UnitType unitType);
    }
}