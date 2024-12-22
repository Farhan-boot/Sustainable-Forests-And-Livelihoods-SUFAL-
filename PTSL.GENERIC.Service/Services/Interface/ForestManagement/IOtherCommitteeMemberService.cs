using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.ForestManagement
{
    public interface IOtherCommitteeMemberService : IBaseService<OtherCommitteeMemberVM, OtherCommitteeMember>
    {
        Task<(ExecutionState executionState, IList<OtherCommitteeMemberVM> entity, string message)> ListByForestFcvVcf(long id);
    }
}
