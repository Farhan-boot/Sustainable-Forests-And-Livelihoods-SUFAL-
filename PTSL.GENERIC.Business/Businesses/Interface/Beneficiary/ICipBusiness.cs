using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface ICipBusiness : IBaseBusiness<Cip>
    {
        Task<(ExecutionState executionState, CIPDetailsVM entity, string message)> GetCipDetails(ForestCivilLocationFilter filter);

        // Task<(ExecutionState executionState, IList<Cip> entity, string message)> ListByFilter(CipFilterVM filter);
        Task<(ExecutionState executionState, PaginationResutl<Cip> entity, string message)> ListByFilter(CipFilterVM filter);
        Task<(ExecutionState executionState, IList<Cip> entity, string message)> ListByFilterForBeneficiary(CipFilterVM filter);
    }
}