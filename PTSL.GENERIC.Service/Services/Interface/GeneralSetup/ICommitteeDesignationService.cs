using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services;

public interface ICommitteeDesignationService : IBaseService<CommitteeDesignationVM, CommitteeDesignation>
{
    Task<(ExecutionState executionState, List<CommitteeDesignationVM> entity, string message)> ListByFilter(CommitteeDesignationFilterVM filter);
}
