using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface ISafetyNetService
    {
        (ExecutionState executionState, List<SafetyNetVM> entity, string message) List();
        (ExecutionState executionState, SafetyNetVM entity, string message) Create(SafetyNetVM model);
        (ExecutionState executionState, SafetyNetVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SafetyNetVM entity, string message) Update(SafetyNetVM model);
        (ExecutionState executionState, SafetyNetVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
