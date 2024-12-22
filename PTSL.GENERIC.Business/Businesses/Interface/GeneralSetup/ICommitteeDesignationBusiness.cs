using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface
{
    public interface ICommitteeDesignationBusiness : IBaseBusiness<CommitteeDesignation>
    {
        Task<(ExecutionState executionState, List<CommitteeDesignation> entity, string message)> ListByFilter(CommitteeDesignationFilterVM filter);
    }
}
