using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface.ForestManagement
{
    public interface IOtherCommitteeMemberBusiness : IBaseBusiness<OtherCommitteeMember>
    {
        Task<(ExecutionState executionState, IQueryable<OtherCommitteeMember> entity, string message)> ListByForestFcvVcf(long id);
    }
}
