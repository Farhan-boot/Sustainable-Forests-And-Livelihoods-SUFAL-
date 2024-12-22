using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.Trades;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Trades;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Trade;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Trades
{
    public class TradeService : BaseService<TradeVM, Trade>, ITradeService
    {
        public IMapper _mapper;

        public TradeService(ITradeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override Trade CastModelToEntity(TradeVM model)
        {
            try
            {
                return _mapper.Map<Trade>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override TradeVM CastEntityToModel(Trade entity)
        {
            try
            {
                var model = _mapper.Map<TradeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<TradeVM> CastEntityToModel(IQueryable<Trade> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<TradeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
