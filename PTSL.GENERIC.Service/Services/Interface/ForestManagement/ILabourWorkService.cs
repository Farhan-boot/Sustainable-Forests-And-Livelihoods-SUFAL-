using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.Labour
{
    public interface ILabourWorkService : IBaseService<LabourWorkVM, LabourWork>
    {
        Task<(ExecutionState executionState, List<LabourWorkVM> entity, string message)> ListByFilter(LabourWorkFilterVM filter);
    }
}