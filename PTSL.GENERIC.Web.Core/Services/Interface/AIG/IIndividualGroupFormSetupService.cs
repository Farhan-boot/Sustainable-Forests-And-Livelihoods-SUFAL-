using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface IIndividualGroupFormSetupService
    {
        (ExecutionState executionState, List<IndividualGroupFormSetupVM> entity, string message) List();
        (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) Create(IndividualGroupFormSetupVM model);
        (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) GetById(long? id);
        (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) Update(IndividualGroupFormSetupVM model);
        (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}