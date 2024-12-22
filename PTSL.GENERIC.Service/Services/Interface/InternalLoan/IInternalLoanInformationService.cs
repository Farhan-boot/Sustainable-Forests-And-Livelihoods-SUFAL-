using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.InternalLoan
{
    public interface IInternalLoanInformationService : IBaseService<InternalLoanInformationVM, InternalLoanInformation>
    {
        Task<(ExecutionState executionState, InternalLoanAvailableAmountVM entity, string message)> GetInternalLoanAvailableAmount(long fcvVcfId);
        Task<(ExecutionState executionState, PaginationResutl<InternalLoanInformationVM> entity, string message)> GetInternalLoanInformationByFilter(AIGBasicInformationFilterVM filterData);


        //Task<(ExecutionState executionState, AIGBasicInformationVM entity, string message)> GetIncludeFirstSecondAndBen(long aigId);
    }
}