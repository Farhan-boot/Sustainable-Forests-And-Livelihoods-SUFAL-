using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public class DistributionFundTypeService : BaseService<DistributionFundTypeVM, DistributionFundType>, IDistributionFundTypeService
    {
        public IMapper _mapper;

        public DistributionFundTypeService(IDistributionFundTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override DistributionFundType CastModelToEntity(DistributionFundTypeVM model)
        {
            return _mapper.Map<DistributionFundType>(model);
        }

        public override DistributionFundTypeVM CastEntityToModel(DistributionFundType entity)
        {
            return _mapper.Map<DistributionFundTypeVM>(entity);
        }

        public override IList<DistributionFundTypeVM> CastEntityToModel(IQueryable<DistributionFundType> entity)
        {
            return _mapper.Map<IList<DistributionFundTypeVM>>(entity).ToList();
        }
    }
}