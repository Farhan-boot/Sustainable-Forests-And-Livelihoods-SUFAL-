using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public interface IForestDivisionService : IBaseService<ForestDivisionVM, ForestDivision>
    {
        Task<(ExecutionState executionState, IList<ForestDivisionVM> entity, string message)> ListByForestCircle(long forestCircleId);
        Task<(ExecutionState executionState, IList<ForestDivisionVM> entity, string message)> ListByMultipleForestCircle(List<long> forestCircleIds);
    }
}
