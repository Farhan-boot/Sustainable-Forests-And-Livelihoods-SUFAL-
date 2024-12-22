using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup
{
    public interface IFinancialYearService
    {
        (ExecutionState executionState, List<FinancialYearVM> entity, string message) List();
        (ExecutionState executionState, FinancialYearVM entity, string message) Create(FinancialYearVM model);
        (ExecutionState executionState, FinancialYearVM entity, string message) GetById(long? id);
        (ExecutionState executionState, FinancialYearVM entity, string message) Update(FinancialYearVM model);
        (ExecutionState executionState, FinancialYearVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}
