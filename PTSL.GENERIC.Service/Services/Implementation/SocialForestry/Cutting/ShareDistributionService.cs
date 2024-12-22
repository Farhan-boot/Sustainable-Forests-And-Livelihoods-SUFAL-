using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public class ShareDistributionService : BaseService<ShareDistributionVM, ShareDistribution>, IShareDistributionService
    {
        private readonly IShareDistributionBusiness _business;
        public IMapper _mapper;

        public ShareDistributionService(IShareDistributionBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override ShareDistribution CastModelToEntity(ShareDistributionVM model)
        {
            return _mapper.Map<ShareDistribution>(model);
        }

        public override ShareDistributionVM CastEntityToModel(ShareDistribution entity)
        {
            return _mapper.Map<ShareDistributionVM>(entity);
        }

        public override IList<ShareDistributionVM> CastEntityToModel(IQueryable<ShareDistribution> entity)
        {
            return _mapper.Map<IList<ShareDistributionVM>>(entity).ToList();
        }

        public Task<(ExecutionState executionState, DefaultDistributionDataVM data, string message)> GetDefaultDistributionData(long cuttingPlantationId)
        {
            return _business.GetDefaultDistributionData(cuttingPlantationId);
        }

        public async Task<(ExecutionState executionState, List<ShareDistributionVM> data, string message)> ListByCuttingPlantation(long cuttingPlantationId)
        {
            var sharePercentage = await _business.ListByCuttingPlantation(cuttingPlantationId);
            if (sharePercentage.data is null)
            {
                return (sharePercentage.executionState, new List<ShareDistributionVM>(), sharePercentage.message);
            }

            return (sharePercentage.executionState, _mapper.Map<List<ShareDistributionVM>>(sharePercentage.data), "Success");
        }
    }
}