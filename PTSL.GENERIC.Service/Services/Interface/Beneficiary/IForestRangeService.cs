using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public interface IForestRangeService : IBaseService<ForestRangeVM, ForestRange>
    {
        Task<(ExecutionState executionState, IList<ForestRangeVM> entity, string message)> ListByForestDivision(long forestDivisionId);
    }
}
