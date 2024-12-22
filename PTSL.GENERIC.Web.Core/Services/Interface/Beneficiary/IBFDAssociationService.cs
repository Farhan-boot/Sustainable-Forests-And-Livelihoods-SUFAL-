using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;

public interface IBFDAssociationService
{
    (ExecutionState executionState, List<BFDAssociationVM> entity, string message) List();
    (ExecutionState executionState, BFDAssociationVM entity, string message) Create(BFDAssociationVM model);
    (ExecutionState executionState, BFDAssociationVM entity, string message) GetById(long? id);
    (ExecutionState executionState, BFDAssociationVM entity, string message) Update(BFDAssociationVM model);
    (ExecutionState executionState, BFDAssociationVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
}
