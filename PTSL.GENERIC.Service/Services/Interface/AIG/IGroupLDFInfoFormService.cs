using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public interface IGroupLDFInfoFormService : IBaseService<GroupLDFInfoFormVM, GroupLDFInfoForm>
    {
        Task<(ExecutionState executionState, GroupLDFInfoFormVM entity, string message)> GetDetails(long id, bool includeAll = false);
        Task<(ExecutionState executionState, List<GroupLDFInfoFormVM> entity, string message)> ListByFilter(GroupLDFInfoFormFilterVM filter);
    }
}