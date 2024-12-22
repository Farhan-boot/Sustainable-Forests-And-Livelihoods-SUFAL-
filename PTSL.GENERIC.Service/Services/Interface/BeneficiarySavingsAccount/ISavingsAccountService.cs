using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount
{
    public interface ISavingsAccountService : IBaseService<SavingsAccountVM, SavingsAccount>
    {
        Task<(ExecutionState executionState, PaginationResutl<SavingsAccountVM> entity, string message)> GetByFilter(SavingsAccountFilterVM filterData);
    }
}
