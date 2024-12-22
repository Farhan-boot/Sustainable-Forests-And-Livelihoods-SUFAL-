using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface ICipFileService
    {
        (ExecutionState executionState, List<CipFileVM> entity, string message) List();
        (ExecutionState executionState, CipFileVM entity, string message) Create(CipFileVM model);
        (ExecutionState executionState, CipFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CipFileVM entity, string message) Update(CipFileVM model);
        (ExecutionState executionState, CipFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}