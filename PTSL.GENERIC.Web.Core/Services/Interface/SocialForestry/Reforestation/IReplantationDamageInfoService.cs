using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Reforestation
{
    public interface IReplantationDamageInfoService
    {
        (ExecutionState executionState, List<ReplantationDamageInfoVM> entity, string message) List();
        (ExecutionState executionState, ReplantationDamageInfoVM entity, string message) Create(ReplantationDamageInfoVM model);
        (ExecutionState executionState, ReplantationDamageInfoVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ReplantationDamageInfoVM entity, string message) Update(ReplantationDamageInfoVM model);
        (ExecutionState executionState, ReplantationDamageInfoVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}