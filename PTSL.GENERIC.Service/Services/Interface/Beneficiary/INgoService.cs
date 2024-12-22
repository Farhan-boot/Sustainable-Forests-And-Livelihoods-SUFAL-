using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public interface INgoService : IBaseService<NgoVM, Ngo>
    {
        Task<(ExecutionState executionState, IList<NgoVM> entity, string message)> ListByForestDivisions(List<long> districts);
    }
}
