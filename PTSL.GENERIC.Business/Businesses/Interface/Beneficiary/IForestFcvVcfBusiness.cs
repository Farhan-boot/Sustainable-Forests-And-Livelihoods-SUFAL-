using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using System.Collections.Generic;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;

using System.Linq;
using System.Threading.Tasks;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface IForestFcvVcfBusiness : IBaseBusiness<ForestFcvVcf>
    {
        Task<(ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message)> ListByForestBeat(long ForestBeatId);
        Task<(ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message)> GetFcvVcfByType(bool isFcv);
        Task<(ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message)> ListByForestBeatAndType(long ForestBeatId, FcvVcfType type);
        Task<(ExecutionState executionState, List<MemberPerVillageVM> entity, string message)> MemberPerVillage(MemberPerVillageFilterVM filter);
    }
}
