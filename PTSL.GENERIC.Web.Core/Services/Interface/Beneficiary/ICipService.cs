using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface ICipService
    {
        (ExecutionState executionState, List<CipVM> entity, string message) List();
        (ExecutionState executionState, CipVM entity, string message) Create(CipVM model);
        (ExecutionState executionState, CipVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CipVM entity, string message) Update(CipVM model);
        (ExecutionState executionState, CipVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, PaginationResutlVM<CipVM> entity, string message) ListByFilter(CipFilterVM model);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
        (ExecutionState executionState, List<CipVM> entity, string message) ListByFilterForBeneficiary(CipFilterVM model);
    }
}