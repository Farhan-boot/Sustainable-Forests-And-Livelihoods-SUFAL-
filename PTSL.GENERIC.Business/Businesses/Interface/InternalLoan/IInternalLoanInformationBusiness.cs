using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Business.Businesses.Interface.InternalLoan
{
    public interface IInternalLoanInformationBusiness : IBaseBusiness<InternalLoanInformation>
    {
        Task<(ExecutionState executionState, InternalLoanAvailableAmountVM entity, string message)> GetInternalLoanAvailableAmount(long fcvVcfId);

        Task<(ExecutionState executionState, PaginationResutl<InternalLoanInformation> entity, string message)> GetInternalLoanInformationByFilter(AIGBasicInformationFilterVM filterData);

        //Task<(ExecutionState executionState, AIGBasicInformation entity, string message)> GetIncludeFirstSecondAndBen(long key);
    }
}