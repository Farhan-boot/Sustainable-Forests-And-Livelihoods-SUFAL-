using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public interface ICipService : IBaseService<CipVM, Cip>
    {
        Task<(ExecutionState executionState, PaginationResutl<CipVM> entity, string message)> ListByFilter(CipFilterVM filter);
        Task<(ExecutionState executionState, IList<CipVM> entity, string message)> ListByFilterForBeneficiary(CipFilterVM filter);
    }
}