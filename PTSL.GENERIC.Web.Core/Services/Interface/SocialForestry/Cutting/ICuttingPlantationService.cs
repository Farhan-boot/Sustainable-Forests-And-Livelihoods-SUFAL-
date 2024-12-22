using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting
{
    public interface ICuttingPlantationService
    {
        (ExecutionState executionState, List<CuttingPlantationVM> entity, string message) List();
        (ExecutionState executionState, CuttingPlantationVM entity, string message) Create(CuttingPlantationVM model);
        (ExecutionState executionState, CuttingPlantationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CuttingPlantationVM entity, string message) Update(CuttingPlantationVM model);
        (ExecutionState executionState, CuttingPlantationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, List<CuttingPlantationVM> entity, string message) ListByNewRaised(long newRaisedId);
        (ExecutionState executionState, List<CuttingPlantationVM> entity, string message) ListByFilter(NewRaisedPlantationFilter filter);

    }
}