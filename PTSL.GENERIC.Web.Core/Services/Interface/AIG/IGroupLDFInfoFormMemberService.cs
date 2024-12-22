using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface IGroupLDFInfoFormMemberService
    {
        (ExecutionState executionState, List<GroupLDFInfoFormMemberVM> entity, string message) List();
        (ExecutionState executionState, GroupLDFInfoFormMemberVM entity, string message) Create(GroupLDFInfoFormMemberVM model);
        (ExecutionState executionState, GroupLDFInfoFormMemberVM entity, string message) GetById(long? id);
        (ExecutionState executionState, GroupLDFInfoFormMemberVM entity, string message) Update(GroupLDFInfoFormMemberVM model);
        (ExecutionState executionState, GroupLDFInfoFormMemberVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}