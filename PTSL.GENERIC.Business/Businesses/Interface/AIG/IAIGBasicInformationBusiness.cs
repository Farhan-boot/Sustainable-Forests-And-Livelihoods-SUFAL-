using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;

namespace PTSL.GENERIC.Business.Businesses.Interface.AIG
{
    public interface IAIGBasicInformationBusiness : IBaseBusiness<AIGBasicInformation>
    {
        Task<(ExecutionState executionState, AIGBeneficiaryCheckEligibilityVM entity, string message)> AIGBeneficiaryCheckEligibility(long surveyId);
        Task<(ExecutionState executionState, List<AIGLoanStatusReportVM> entity, string message)> AIGLoanStatusReport(AIGLoanStatusReportFilterVM filter);
        Task<(ExecutionState executionState, List<AverageLoanSizeVM> entity, string message)> AverageLoanSizeFilter(AverageLoanSizeFilterVM filter);
        Task<(ExecutionState executionState, IList<AIGBasicInformation> entity, string message)> BeneficiaryWiseRepaymentProgress(long surveyId);
        Task<(ExecutionState executionState, List<CumulativeRecoveryRateVM> entity, string message)> CumulativeRecoveryRateReport(CumulativeRecoveryRateFilterVM filter);
        Task<(ExecutionState executionState, PaginationResutl<AIGBasicInformation> entity, string message)> GetAIGByFilter(AIGBasicInformationFilterVM filterData);
        Task<(ExecutionState executionState, AIGBasicInformation entity, string message)> GetIncludeFirstSecondAndBen(long key);
        Task<(ExecutionState executionState, AIGLoanOverviewVM entity, string message)> LoanOverview(ForestCivilLocationFilter filter);
        Task<(ExecutionState executionState, IList<AIGBasicInformation> entity, string message)> RepaymentReport(RepaymentReportFilterVM filter);
        Task<(ExecutionState executionState, bool entity, string message)> SetBadLoanData();
        Task<(ExecutionState executionState, List<OnTimeRecoveryRateVM> entity, string message)> OnTimeRecoveryRate(OnTimeRecoveryRateFilterVM filter);
        Task<(ExecutionState executionState, List<PortfolioAtRiskVM> entity, string message)> PortfolioAtRisk(PortfolioAtRiskFilterVM filter);
        Task<(ExecutionState executionState, List<DelinquencyRatioVM> entity, string message)> DelinquencyRatio(DelinquencyRatioFilterVM filter);
        Task<(ExecutionState executionState, List<BorrowerPerVillageVM> entity, string message)> BorrowerPerVillageReport(BorrowerPerVillageFilterVM filter);
        Task<(ExecutionState executionState, List<BorrowerCoverageVM> entity, string message)> BorrowerCoverageReport(BorrowerCoverageFilterVM filter);
        Task<(ExecutionState executionState, List<PortfolioPerVillageVM> entity, string message)> PortfolioPerVillage(PortfolioPerVillageFilterVM filter);
    }
}