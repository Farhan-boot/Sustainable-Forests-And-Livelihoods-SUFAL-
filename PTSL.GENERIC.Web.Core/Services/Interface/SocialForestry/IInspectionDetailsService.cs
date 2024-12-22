using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IInspectionDetailsService
    {
        (ExecutionState executionState, List<InspectionDetailsVM> entity, string message) List();
        (ExecutionState executionState, InspectionDetailsVM entity, string message) Create(InspectionDetailsVM model);
        (ExecutionState executionState, InspectionDetailsVM entity, string message) GetById(long? id);
        (ExecutionState executionState, InspectionDetailsVM entity, string message) Update(InspectionDetailsVM model);
        (ExecutionState executionState, InspectionDetailsVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}