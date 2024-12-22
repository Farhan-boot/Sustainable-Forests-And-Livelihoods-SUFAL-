using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG.Reports;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface IAIGBasicInformationService
    {
        (ExecutionState executionState, List<AIGBasicInformationVM> entity, string message) List();
        (ExecutionState executionState, AIGBasicInformationVM entity, string message) Create(AIGBasicInformationVM model);
        (ExecutionState executionState, AIGBasicInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, AIGBasicInformationVM entity, string message) Update(AIGBasicInformationVM model);
        (ExecutionState executionState, AIGBasicInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, AIGBasicInformationVM entity, string message) GetIncludeFirstSecondAndBen(long? aigId);
        (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) GetAIGByFilter(AIGBasicInformationFilterVM filter);
        (ExecutionState executionState, List<AIGBasicInformationVM> entity, string message) RepaymentReport(RepaymentReportFilterVM filter);
        (ExecutionState executionState, List<AIGBasicInformationVM> entity, string message) BeneficiaryWiseRepaymentProgress(long surveyId);
        (ExecutionState executionState, List<AverageLoanSizeVM> entity, string message) AverageLoanSizeFilter(AverageLoanSizeFilterVM filter);
        (ExecutionState executionState, List<AIGLoanStatusReportVM> entity, string message) AIGLoanStatusReport(AIGLoanStatusReportFilterVM filter);
        (ExecutionState executionState, AIGBeneficiaryCheckEligibilityVM entity, string message) AIGBeneficiaryCheckEligibility(long surveyId);
        (ExecutionState executionState, List<CumulativeRecoveryRateVM> entity, string message) CumulativeRecoveryRateReportList(CumulativeRecoveryRateFilterVM filter);
        (ExecutionState executionState, List<OnTimeRecoveryRateVM> entity, string message) OnTimeRecoveryRateList(OnTimeRecoveryRateFilterVM filter);
        (ExecutionState executionState, List<PortfolioAtRiskVM> entity, string message) PortfolioAtRiskList(PortfolioAtRiskFilterVM filter);
        (ExecutionState executionState, List<DelinquencyRatioVM> entity, string message) DelinquencyRatioList(DelinquencyRatioFilterVM filter);
        (ExecutionState executionState, List<BorrowerPerVillageVM> entity, string message) BorrowerPerVillageReport(BorrowerPerVillageFilterVM filter);
        (ExecutionState executionState, List<BorrowerCoverageVM> entity, string message) BorrowerCoverageReport(BorrowerCoverageFilterVM filter);
        (ExecutionState executionState, List<PortfolioPerVillageVM> entity, string message) PortfolioPerVillageList(PortfolioPerVillageFilterVM filter);
    }
}