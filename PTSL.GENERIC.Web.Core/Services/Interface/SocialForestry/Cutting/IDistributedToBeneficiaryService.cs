using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting
{
    public interface IDistributedToBeneficiaryService
    {
        (ExecutionState executionState, List<DistributedToBeneficiaryVM> entity, string message) List();
        (ExecutionState executionState, DistributedToBeneficiaryVM entity, string message) Create(DistributedToBeneficiaryVM model);
        (ExecutionState executionState, DistributedToBeneficiaryVM entity, string message) GetById(long? id);
        (ExecutionState executionState, DistributedToBeneficiaryVM entity, string message) Update(DistributedToBeneficiaryVM model);
        (ExecutionState executionState, DistributedToBeneficiaryVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}