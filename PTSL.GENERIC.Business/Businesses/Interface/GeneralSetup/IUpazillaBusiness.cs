using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface
{
    public interface IUpazillaBusiness : IBaseBusiness<Upazilla>
    {
        Task<(ExecutionState executionState, IQueryable<Upazilla> entity, string message)> ListByDistrict(long districtId);
    }
}
