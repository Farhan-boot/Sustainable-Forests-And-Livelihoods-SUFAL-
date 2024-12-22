using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface IGroupLDFInfoFormService
    {
        (ExecutionState executionState, List<GroupLDFInfoFormVM> entity, string message) List();
        (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) Create(GroupLDFInfoFormVM model);
        (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) GetById(long? id);
        (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) Update(GroupLDFInfoFormVM model);
        (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) GetDetails(long? id, bool includeAll = false);
        (ExecutionState executionState, List<GroupLDFInfoFormVM> entity, string message) ListByFilter(GroupLDFInfoFormFilterVM filter);
    }
}