using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement
{
    public interface ISourceOfFundService
    {
        (ExecutionState executionState, List<SourceOfFundVM> entity, string message) List();
        (ExecutionState executionState, SourceOfFundVM entity, string message) Create(SourceOfFundVM model);
        (ExecutionState executionState, SourceOfFundVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SourceOfFundVM entity, string message) Update(SourceOfFundVM model);
        (ExecutionState executionState, SourceOfFundVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}