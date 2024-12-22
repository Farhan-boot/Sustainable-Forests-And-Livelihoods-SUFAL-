using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services
{
    public interface IUpazillaService : IBaseService<UpazillaVM, Upazilla>
    {
        Task<(ExecutionState executionState, IList<UpazillaVM> entity, string message)> ListByDistrict(long districtId);
    }
}
