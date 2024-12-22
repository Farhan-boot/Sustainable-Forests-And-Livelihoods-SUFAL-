using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.Market;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Market
{
    public class MarketingService : BaseService<MarketingVM, Marketing>, IMarketingService
    {
        public IMapper _mapper;

        public MarketingService(IMarketingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override Marketing CastModelToEntity(MarketingVM model)
        {
            try
            {
                return _mapper.Map<Marketing>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override MarketingVM CastEntityToModel(Marketing entity)
        {
            try
            {
                var model = _mapper.Map<MarketingVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<MarketingVM> CastEntityToModel(IQueryable<Marketing> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<MarketingVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
