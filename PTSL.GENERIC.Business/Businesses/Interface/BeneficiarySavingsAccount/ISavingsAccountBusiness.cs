using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;

namespace PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount
{
    public interface ISavingsAccountBusiness : IBaseBusiness<SavingsAccount>
    {
        Task<(ExecutionState executionState, PaginationResutl<SavingsAccount> entity, string message)> GetByFilter(SavingsAccountFilterVM filterData);

        Task<(ExecutionState executionState, DashboardSavingsAmountVM entity, string message)> TotalDashboardSavingsAmount(ForestCivilLocationFilter filter);
    }
}
