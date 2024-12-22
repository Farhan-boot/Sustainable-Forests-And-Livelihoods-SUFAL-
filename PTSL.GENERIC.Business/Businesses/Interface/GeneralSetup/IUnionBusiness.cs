using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface
{
    public interface IUnionBusiness : IBaseBusiness<Union>
    {
        Task<(ExecutionState executionState, IQueryable<Union> entity, string message)> ListByMultipleUpazilla(List<long> upazillas);
        Task<(ExecutionState executionState, IQueryable<Union> entity, string message)> ListByUpazilla(long UpazillaId);
    }
}
