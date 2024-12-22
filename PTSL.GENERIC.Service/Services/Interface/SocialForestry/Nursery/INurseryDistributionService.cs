using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Nursery
{
    public interface INurseryDistributionService : IBaseService<NurseryDistributionVM, NurseryDistribution>
    {
        Task<(ExecutionState executionState, List<NurseryDistributionVM> entity, string message)> GetByNurseryAsync(long id);
        Task<(ExecutionState executionState, List<DistributionVM> entity, string message)> ListByNurseryId(long nurseryId, QueryOptions<NurseryDistribution> queryOptions = null);

        Task<(ExecutionState executionState, List<NurseryDistributionVM> entity, string message)> CreateRangeAsync(NurseryDistributionListVM model);
        Task<(ExecutionState executionState, List<NurseryDistributionVM> entity, string message)> UpdateRangeAsync(NurseryDistributionListVM model);
        Task<(ExecutionState executionState, IList<NurseryDistributionVM> entity, string message)> ListByDistributionById(long id, QueryOptions<NurseryDistribution> queryOptions = null);
        Task<(ExecutionState executionState, IList<NurseryDistributionVM> entity, string message)> GetFilterData(DistributionFilter model);
        Task<(ExecutionState executionState, IList<DistributionVM> entity, string message)> GetFilterByDate(long nurseryId, NurseryFilterVM model);
    }
}