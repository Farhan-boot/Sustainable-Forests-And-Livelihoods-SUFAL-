using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IOccupationService
    {
        (ExecutionState executionState, List<OccupationVM> entity, string message) List();
        (ExecutionState executionState, OccupationVM entity, string message) Create(OccupationVM model);
        (ExecutionState executionState, OccupationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, OccupationVM entity, string message) Update(OccupationVM model);
        (ExecutionState executionState, OccupationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
