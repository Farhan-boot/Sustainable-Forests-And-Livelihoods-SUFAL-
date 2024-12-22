using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting
{
    public interface IDistributionPercentageService
    {
        (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) List();
        (ExecutionState executionState, DistributionPercentageVM entity, string message) Create(DistributionPercentageVM model);
        (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) CreateRange(DistributionPercentageCustomVM model);
        (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) UpadateRange(long id,DistributionPercentageCustomVM model);
        (ExecutionState executionState, DistributionPercentageVM entity, string message) GetById(long? id);
        (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) GetByPlantationTypeId(long? id);
        (ExecutionState executionState, DistributionPercentageVM entity, string message) Update(DistributionPercentageVM model);
        (ExecutionState executionState, DistributionPercentageVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}