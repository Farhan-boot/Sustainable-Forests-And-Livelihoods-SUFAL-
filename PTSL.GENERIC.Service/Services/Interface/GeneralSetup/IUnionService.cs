using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services
{
    public interface IUnionService : IBaseService<UnionVM, Union>
    {
        Task<(ExecutionState executionState, IList<UnionVM> entity, string message)> ListByMultipleUpazilla(List<long> upazillas);
        Task<(ExecutionState executionState, IList<UnionVM> entity, string message)> ListByUpazilla(long UpazillaId);
    }
}
