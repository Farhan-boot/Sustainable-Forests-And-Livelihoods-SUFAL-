using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Business.Businesses.Interface.AIG
{
    public interface IGroupLDFInfoFormBusiness : IBaseBusiness<GroupLDFInfoForm>
    {
        Task<(ExecutionState executionState, GroupLDFInfoForm entity, string message)> GetDetails(long id, bool includeAll = false);
        Task<(ExecutionState executionState, IList<GroupLDFInfoForm> entity, string message)> ListByFilter(GroupLDFInfoFormFilterVM filter);
    }
}