using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IImmovableAssetTypeService
    {
        (ExecutionState executionState, List<ImmovableAssetTypeVM> entity, string message) List();
        (ExecutionState executionState, ImmovableAssetTypeVM entity, string message) Create(ImmovableAssetTypeVM model);
        (ExecutionState executionState, ImmovableAssetTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ImmovableAssetTypeVM entity, string message) Update(ImmovableAssetTypeVM model);
        (ExecutionState executionState, ImmovableAssetTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
