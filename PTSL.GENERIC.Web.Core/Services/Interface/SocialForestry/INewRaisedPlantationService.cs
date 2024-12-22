using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface INewRaisedPlantationService
    {
        (ExecutionState executionState, List<NewRaisedPlantationVM> entity, string message) List();
        (ExecutionState executionState, NewRaisedPlantationVM entity, string message) Create(NewRaisedPlantationVM model);
        (ExecutionState executionState, NewRaisedPlantationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NewRaisedPlantationVM entity, string message) Update(NewRaisedPlantationVM model);
        (ExecutionState executionState, NewRaisedPlantationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, NewRaisedPlantationVM entity, string message) GetDetails(long id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, string entity, string message) GetNextRotationNo(long newRaisedId);
        (ExecutionState executionState, NewRaisedPlantationVM entity, string message) GetDetailsForEdit(long id);
        (ExecutionState executionState, List<NewRaisedPlantationVM> entity, string message) ListByFilter(NewRaisedPlantationFilter filter);
        (ExecutionState executionState, List<NewRaisedPlantationVM> entity, string message) GetInformationAndDataOnNewlyRaisedPlantationReport(InformationAndDataOnNewlyRaisedPlantationFilterVM filter);
        (ExecutionState executionState, List<NewRaisedPlantationVM> entity, string message) GetInformationAndDataOnPlantationsFelledOrCutReport(InformationAndDataOnNewlyRaisedPlantationFilterVM filter);

    }
}