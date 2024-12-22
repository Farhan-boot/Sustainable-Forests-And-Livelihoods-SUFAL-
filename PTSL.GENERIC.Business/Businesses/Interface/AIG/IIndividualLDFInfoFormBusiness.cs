using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Business.Businesses.Interface.AIG
{
    public interface IIndividualLDFInfoFormBusiness : IBaseBusiness<IndividualLDFInfoForm>
    {
        Task<(ExecutionState executionState, bool entity, string message)> ApproveLDF(long ldfId, double approvedLoanAmount);
        Task<(ExecutionState executionState, double amount, string message)> GetLDFAmountForBeneficiary(long beneficiaryId);
        Task<(ExecutionState executionState, PaginationResutl<IndividualLDFInfoForm> entity, string message)> ListByFilter(IndividualLDFFilterVM filter);
        Task<(ExecutionState executionState, List<IndividualLDFInfoForm> entity, string message)> ListByFilterBasic(IndividualLDFFilterVM filter);
        Task<(ExecutionState executionState, IList<SurveyDropdownVM> entity, string message)> ListByFilterBeneficiary(IndividualLDFFilterVM filter);
        Task<(ExecutionState executionState, bool entity, string message)> RejectLDF(long ldfId);
    }
}