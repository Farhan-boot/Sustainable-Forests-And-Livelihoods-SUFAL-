using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Reforestation
{
    public interface IReplantationInspectionMapService
    {
        (ExecutionState executionState, List<ReplantationInspectionMapVM> entity, string message) List();
        (ExecutionState executionState, ReplantationInspectionMapVM entity, string message) Create(ReplantationInspectionMapVM model);
        (ExecutionState executionState, ReplantationInspectionMapVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ReplantationInspectionMapVM entity, string message) Update(ReplantationInspectionMapVM model);
        (ExecutionState executionState, ReplantationInspectionMapVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}