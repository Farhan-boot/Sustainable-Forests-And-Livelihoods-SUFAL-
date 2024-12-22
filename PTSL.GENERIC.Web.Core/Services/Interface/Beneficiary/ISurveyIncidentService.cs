using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface ISurveyIncidentService
    {
        (ExecutionState executionState, List<SurveyIncidentVM> entity, string message) List();
        (ExecutionState executionState, SurveyIncidentVM entity, string message) Create(SurveyIncidentVM model);
        (ExecutionState executionState, SurveyIncidentVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SurveyIncidentVM entity, string message) Update(SurveyIncidentVM model);
        (ExecutionState executionState, SurveyIncidentVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<SurveyIncidentVM> entity, string message) ListByFilter(SurveyIncidentFilterVM filter);
    }
}