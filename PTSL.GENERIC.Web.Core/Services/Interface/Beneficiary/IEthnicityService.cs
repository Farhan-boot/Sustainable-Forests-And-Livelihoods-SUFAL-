using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IEthnicityService
    {
        (ExecutionState executionState, List<EthnicityVM> entity, string message) List();
        (ExecutionState executionState, EthnicityVM entity, string message) Create(EthnicityVM model);
        (ExecutionState executionState, EthnicityVM entity, string message) GetById(long? id);
        (ExecutionState executionState, EthnicityVM entity, string message) Update(EthnicityVM model);
        (ExecutionState executionState, EthnicityVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
