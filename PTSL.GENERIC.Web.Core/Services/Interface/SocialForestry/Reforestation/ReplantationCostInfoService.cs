using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Reforestation
{
    public interface IReplantationCostInfoService
    {
        (ExecutionState executionState, List<ReplantationCostInfoVM> entity, string message) List();
        (ExecutionState executionState, ReplantationCostInfoVM entity, string message) Create(ReplantationCostInfoVM model);
        (ExecutionState executionState, ReplantationCostInfoVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ReplantationCostInfoVM entity, string message) Update(ReplantationCostInfoVM model);
        (ExecutionState executionState, ReplantationCostInfoVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}