using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IUpazilaService
    {
        (ExecutionState executionState, List<UpazilaVM> entity, string message) List();
        (ExecutionState executionState, UpazilaVM entity, string message) Create(UpazilaVM model);
        (ExecutionState executionState, UpazilaVM entity, string message) GetById(long? id);
        (ExecutionState executionState, UpazilaVM entity, string message) Update(UpazilaVM model);
        (ExecutionState executionState, UpazilaVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
