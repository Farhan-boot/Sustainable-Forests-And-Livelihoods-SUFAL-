using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Labour;

public interface IOtherLabourMemberService
{
    (ExecutionState executionState, List<OtherLabourMemberVM> entity, string message) List();
    (ExecutionState executionState, OtherLabourMemberVM entity, string message) Create(OtherLabourMemberVM model);
    (ExecutionState executionState, OtherLabourMemberVM entity, string message) GetById(long? id);
    (ExecutionState executionState, OtherLabourMemberVM entity, string message) Update(OtherLabourMemberVM model);
    (ExecutionState executionState, OtherLabourMemberVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, List<OtherLabourMemberVM> entity, string message) ListByForestFcvVcf2(long id);
}
