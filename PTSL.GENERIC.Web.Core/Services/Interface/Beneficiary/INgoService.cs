using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface INgoService
    {
        (ExecutionState executionState, List<NgoVM> entity, string message) List();
        (ExecutionState executionState, NgoVM entity, string message) Create(NgoVM model);
        (ExecutionState executionState, NgoVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NgoVM entity, string message) Update(NgoVM model);
        (ExecutionState executionState, NgoVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<NgoVM> entity, string message) ListByForestDivisions(List<long> divisions);
    }
}
