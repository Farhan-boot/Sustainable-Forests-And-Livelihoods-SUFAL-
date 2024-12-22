using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IRelationWithHeadHouseHoldTypeService
    {
        (ExecutionState executionState, List<RelationWithHeadHouseHoldTypeVM> entity, string message) List();
        (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) Create(RelationWithHeadHouseHoldTypeVM model);
        (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) Update(RelationWithHeadHouseHoldTypeVM model);
        (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
