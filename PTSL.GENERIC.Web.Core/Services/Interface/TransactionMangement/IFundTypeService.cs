using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.TransactionMangement
{
    public interface IFundTypeService
    {
        (ExecutionState executionState, List<FundTypeVM> entity, string message) List();
        (ExecutionState executionState, FundTypeVM entity, string message) Create(FundTypeVM model);
        (ExecutionState executionState, FundTypeVM entity, string message) GetById(long? id);
        (ExecutionState executionState, FundTypeVM entity, string message) Update(FundTypeVM model);
        (ExecutionState executionState, FundTypeVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
