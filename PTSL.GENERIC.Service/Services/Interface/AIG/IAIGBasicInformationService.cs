using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public interface IAIGBasicInformationService : IBaseService<AIGBasicInformationVM, AIGBasicInformation>
    {
        Task<(ExecutionState executionState, IList<AIGBasicInformationVM> entity, string message)> BeneficiaryWiseRepaymentProgress(long surveyId);
        Task<(ExecutionState executionState, PaginationResutl<AIGBasicInformationVM> entity, string message)> GetAIGByFilter(AIGBasicInformationFilterVM filterData);
        Task<(ExecutionState executionState, AIGBasicInformationVM entity, string message)> GetIncludeFirstSecondAndBen(long aigId);
        Task<(ExecutionState executionState, List<AIGBasicInformationVM> entity, string message)> RepaymentReport(RepaymentReportFilterVM filter);
    }
}