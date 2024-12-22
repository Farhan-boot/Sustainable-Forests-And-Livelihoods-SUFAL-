using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IPlantationSocialForestryBeneficiaryMapService
    {
        (ExecutionState executionState, List<PlantationSocialForestryBeneficiaryMapVM> entity, string message) List();
        (ExecutionState executionState, PlantationSocialForestryBeneficiaryMapVM entity, string message) Create(PlantationSocialForestryBeneficiaryMapVM model);
        (ExecutionState executionState, PlantationSocialForestryBeneficiaryMapVM entity, string message) GetById(long? id);
        (ExecutionState executionState, PlantationSocialForestryBeneficiaryMapVM entity, string message) Update(PlantationSocialForestryBeneficiaryMapVM model);
        (ExecutionState executionState, PlantationSocialForestryBeneficiaryMapVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}