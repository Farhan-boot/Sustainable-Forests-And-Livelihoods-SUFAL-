using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;

public interface IAssetTypeService
{
    (ExecutionState executionState, List<AssetTypeVM> entity, string message) List();
    (ExecutionState executionState, AssetTypeVM entity, string message) Create(AssetTypeVM model);
    (ExecutionState executionState, AssetTypeVM entity, string message) GetById(long? id);
    (ExecutionState executionState, AssetTypeVM entity, string message) Update(AssetTypeVM model);
    (ExecutionState executionState, AssetTypeVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
