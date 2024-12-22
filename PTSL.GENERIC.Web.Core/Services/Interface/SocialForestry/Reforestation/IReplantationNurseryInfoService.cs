using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Reforestation
{
    public interface IReplantationNurseryInfoService
    {
        (ExecutionState executionState, List<ReplantationNurseryInfoVM> entity, string message) List();
        (ExecutionState executionState, ReplantationNurseryInfoVM entity, string message) Create(ReplantationNurseryInfoVM model);
        (ExecutionState executionState, ReplantationNurseryInfoVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ReplantationNurseryInfoVM entity, string message) Update(ReplantationNurseryInfoVM model);
        (ExecutionState executionState, ReplantationNurseryInfoVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}