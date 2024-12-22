using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IPlantationDamageInformationService
    {
        (ExecutionState executionState, List<PlantationDamageInformationVM> entity, string message) List();
        (ExecutionState executionState, PlantationDamageInformationVM entity, string message) Create(PlantationDamageInformationVM model);
        (ExecutionState executionState, PlantationDamageInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PlantationDamageInformationVM entity, string message) Update(PlantationDamageInformationVM model);
        (ExecutionState executionState, PlantationDamageInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}