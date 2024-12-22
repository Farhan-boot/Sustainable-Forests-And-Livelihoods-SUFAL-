using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining
{
    public interface IFinancialYearForTrainingService
    {
        (ExecutionState executionState, List<FinancialYearForTrainingVM> entity, string message) List();
        (ExecutionState executionState, FinancialYearForTrainingVM entity, string message) Create(FinancialYearForTrainingVM model);
        (ExecutionState executionState, FinancialYearForTrainingVM entity, string message) GetById(long? id);
        (ExecutionState executionState, FinancialYearForTrainingVM entity, string message) Update(FinancialYearForTrainingVM model);
        (ExecutionState executionState, FinancialYearForTrainingVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}