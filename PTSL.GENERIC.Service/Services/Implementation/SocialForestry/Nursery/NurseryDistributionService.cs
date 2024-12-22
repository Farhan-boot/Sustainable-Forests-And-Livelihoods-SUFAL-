using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Nursery
{
    public class NurseryDistributionService : BaseService<NurseryDistributionVM, NurseryDistribution>, INurseryDistributionService
    {
        private readonly INurseryDistributionBusiness _business;
        public IMapper _mapper;

        public NurseryDistributionService(INurseryDistributionBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override NurseryDistribution CastModelToEntity(NurseryDistributionVM model)
        {
            return _mapper.Map<NurseryDistribution>(model);
        }

        public override NurseryDistributionVM CastEntityToModel(NurseryDistribution entity)
        {
            return _mapper.Map<NurseryDistributionVM>(entity);
        }

        public override IList<NurseryDistributionVM> CastEntityToModel(IQueryable<NurseryDistribution> entity)
        {
            return _mapper.Map<IList<NurseryDistributionVM>>(entity).ToList();
        }

        public List<NurseryDistributionVM> CastEntityListToModel(List<NurseryDistribution> entity)
        {
            return _mapper.Map<List<NurseryDistributionVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<NurseryDistributionVM> entity, string message)> GetByNurseryAsync(long id)
        {
            (ExecutionState executionState, IList<NurseryDistribution> entity, string message) result = await _business.GetByNurseryAsync(id);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<NurseryDistributionVM>(), result.message);
        }

        public List<NurseryDistributionVM> CastEntityListToModel(IList<NurseryDistribution> entity)
        {
            return _mapper.Map<List<NurseryDistributionVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<DistributionVM> entity, string message)> ListByNurseryId(long nurseryId, QueryOptions<NurseryDistribution> queryOptions = null)
        {
            (ExecutionState executionState, List<DistributionVM> entity, string message) result = await _business.ListByNurseryId(nurseryId);

            if (result.entity is not null)
            {
                return (result.executionState, result.entity, result.message);
            }

            return (result.executionState, new List<DistributionVM>(), result.message);
        }

        public async Task<(ExecutionState executionState, List<NurseryDistributionVM> entity, string message)> CreateRangeAsync(NurseryDistributionListVM model)
        {
            var distributionList = _mapper.Map<List<NurseryDistribution>>(model.NurseryDistributionList);


            var result = await _business.CreateRangeAsync(distributionList);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<NurseryDistributionVM>(), result.message);
        }

        public async Task<(ExecutionState executionState, List<NurseryDistributionVM> entity, string message)> UpdateRangeAsync(NurseryDistributionListVM model)
        {
            var distributionList = _mapper.Map<List<NurseryDistribution>>(model.NurseryDistributionList);


            var result = await _business.UpdateRangeAsync(distributionList);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<NurseryDistributionVM>(), result.message);
        }

        public async Task<(ExecutionState executionState, IList<NurseryDistributionVM> entity, string message)> ListByDistributionById(long id, QueryOptions<NurseryDistribution> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<NurseryDistribution> entity, string message) result = await _business.ListByDistributionById(id);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, new List<NurseryDistributionVM>(), result.message);
        }

        public async Task<(ExecutionState executionState, IList<NurseryDistributionVM> entity, string message)> GetFilterData(DistributionFilter model)
        {
            try
            {
                (ExecutionState executionState, IQueryable<NurseryDistribution> entity, string message) result = await _business.GetFilterData(model);
                if (result.entity is not null)
                {
                    return (result.executionState, CastEntityToModel(result.entity), result.message);
                }

                return (result.executionState, new List<NurseryDistributionVM>(), result.message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<(ExecutionState executionState, IList<DistributionVM> entity, string message)> GetFilterByDate(long nurseryId,NurseryFilterVM model)
        {
            try
            {
                (ExecutionState executionState, IList<DistributionVM> entity, string message) result = await _business.GetFilterByDate(nurseryId, model);
                if (result.entity is not null)
                {
                    return (result.executionState, result.entity, result.message);
                }

                return (result.executionState, new List<DistributionVM>(), result.message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}