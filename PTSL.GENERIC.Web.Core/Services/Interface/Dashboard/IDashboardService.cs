using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.DashBoard;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Dashboard;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Dashboard;

public interface IDashboardService
{
    (ExecutionState executionState, DashboardHouseholdVM entity, string message) TotalHouseholdWithPercentage(ForestCivilLocationFilter filter);
    (ExecutionState executionState, List<EnergyUsesPercentageVM> entity, string message) GetEnergyUsesPercentage(ForestCivilLocationFilter filter);
    (ExecutionState executionState, CommitteeMemberCount? entity, string message) GetTotalFcvVcfAndExecutiveSubExecutive(ForestCivilLocationFilter filter);
    (ExecutionState executionState, BeneficiaryVM entity, string message) GetTotalBeneficiary(ForestCivilLocationFilter filter);
    (ExecutionState executionState, AIGLoanOverviewVM? entity, string message) LoanOverview(ForestCivilLocationFilter filter);
    (ExecutionState executionState, SurveyDashboardVM? entity, string message) BeneficiaryDashboardData(long? surveyId);

    (ExecutionState executionState, DashboardSavingsAmountVM entity, string message) TotalDashboardSavingsAmount(ForestCivilLocationFilter filter);
    (ExecutionState executionState, DashboardLoanResponse entity, string message) GetLoanData(DashboardLoanRequest filter);
    (ExecutionState executionState, CIPDetailsVM entity, string message) GetCIPDetails(ForestCivilLocationFilter filter);
}

