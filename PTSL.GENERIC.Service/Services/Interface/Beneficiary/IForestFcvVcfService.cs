using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public interface IForestFcvVcfService : IBaseService<ForestFcvVcfVM, ForestFcvVcf>
    {
        Task<(ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message)> ListByForestBeat(long ForestBeatId);
        Task<(ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message)> GetFcvVcfByType(bool isFcv);
        Task<(ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message)> ListByForestBeatAndType(long forestBeatId, FcvVcfType type);
    }
}
