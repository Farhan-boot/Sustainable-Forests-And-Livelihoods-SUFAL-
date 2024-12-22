using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting
{
    public interface IDistributionFundTypeService
    {
        (ExecutionState executionState, List<DistributionFundTypeVM> entity, string message) List();
        (ExecutionState executionState, DistributionFundTypeVM entity, string message) Create(DistributionFundTypeVM model);
        (ExecutionState executionState, DistributionFundTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DistributionFundTypeVM entity, string message) Update(DistributionFundTypeVM model);
        (ExecutionState executionState, DistributionFundTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}