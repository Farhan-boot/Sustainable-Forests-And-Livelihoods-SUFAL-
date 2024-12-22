using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public interface IIndividualLDFInfoFormService : IBaseService<IndividualLDFInfoFormVM, IndividualLDFInfoForm>
    {
        Task<(ExecutionState executionState, double amount, string message)> GetLDFAmountForBeneficiary(long beneficiaryId);
        Task<(ExecutionState executionState, PaginationResutl<IndividualLDFInfoFormVM> entity, string message)> ListByFilter(IndividualLDFFilterVM filter);
        Task<(ExecutionState executionState, List<IndividualLDFInfoFormVM> entity, string message)> ListByFilterBasic(IndividualLDFFilterVM filter);
    }
}