using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Reforestation
{
    public interface IReplantationLaborInfoService
    {
        (ExecutionState executionState, List<ReplantationLaborInfoVM> entity, string message) List();
        (ExecutionState executionState, ReplantationLaborInfoVM entity, string message) Create(ReplantationLaborInfoVM model);
        (ExecutionState executionState, ReplantationLaborInfoVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ReplantationLaborInfoVM entity, string message) Update(ReplantationLaborInfoVM model);
        (ExecutionState executionState, ReplantationLaborInfoVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}