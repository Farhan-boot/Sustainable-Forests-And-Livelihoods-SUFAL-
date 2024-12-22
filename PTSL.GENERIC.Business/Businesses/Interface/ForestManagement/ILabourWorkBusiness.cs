using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;

namespace PTSL.GENERIC.Business.Businesses.Interface.Labour
{
    public interface ILabourWorkBusiness : IBaseBusiness<LabourWork>
    {
        Task<(ExecutionState executionState, List<LabourWork> entity, string message)> ListByFilter(LabourWorkFilterVM filter);
    }
}