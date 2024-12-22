using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Reforestation
{
    public interface IReplantationService
    {
        (ExecutionState executionState, List<ReplantationVM> entity, string message) List();
        (ExecutionState executionState, ReplantationVM entity, string message) Create(ReplantationVM model);
        (ExecutionState executionState, ReplantationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ReplantationVM entity, string message) Update(ReplantationVM model);
        (ExecutionState executionState, ReplantationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, ReplantationVM entity, string message) GetDetails(long id);
    }
}