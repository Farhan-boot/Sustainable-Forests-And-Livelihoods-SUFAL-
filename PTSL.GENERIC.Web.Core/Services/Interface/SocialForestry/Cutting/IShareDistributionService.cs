using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting
{
    public interface IShareDistributionService
    {
        (ExecutionState executionState, List<ShareDistributionVM> entity, string message) List();
        (ExecutionState executionState, ShareDistributionVM entity, string message) Create(ShareDistributionVM model);
        (ExecutionState executionState, ShareDistributionVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ShareDistributionVM entity, string message) Update(ShareDistributionVM model);
        (ExecutionState executionState, ShareDistributionVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, DefaultDistributionDataVM entity, string message) GetDefaultDistributionData(long cuttingId);
        (ExecutionState executionState, List<ShareDistributionVM> entity, string message) ListByCuttingPlantation(long cuttingId);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}