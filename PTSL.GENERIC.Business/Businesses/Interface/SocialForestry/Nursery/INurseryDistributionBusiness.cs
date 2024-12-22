using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery
{
    public interface INurseryDistributionBusiness : IBaseBusiness<NurseryDistribution>
    {
        Task<(ExecutionState executionState, IList<NurseryDistribution> entity, string message)> GetByNurseryAsync(long id);
        Task<(ExecutionState executionState, List<DistributionVM> entity, string message)> ListByNurseryId(long nurseryId, QueryOptions<NurseryDistribution> queryOptions = null);
        Task<(ExecutionState executionState, List<NurseryDistribution> entity, string message)> CreateRangeAsync(List<NurseryDistribution> model);
        Task<(ExecutionState executionState, List<NurseryDistribution> entity, string message)> UpdateRangeAsync(List<NurseryDistribution> model);
        Task<(ExecutionState executionState, IQueryable<NurseryDistribution> entity, string message)> ListByDistributionById(long id, QueryOptions<NurseryDistribution> queryOptions = null);
        Task<(ExecutionState executionState, IQueryable<NurseryDistribution> entity, string message)> GetFilterData(DistributionFilter model);
        Task<(ExecutionState executionState, IList<DistributionVM> entity, string message)> GetFilterByDate(long nurseryId,NurseryFilterVM model);
    }

    
}