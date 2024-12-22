using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class LiveStockService : BaseService<LiveStockVM, LiveStock>, ILiveStockService
    {
        public IMapper _mapper;

        public LiveStockService(ILiveStockBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LiveStock CastModelToEntity(LiveStockVM model)
        {
            try
            {
                return _mapper.Map<LiveStock>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override LiveStockVM CastEntityToModel(LiveStock entity)
        {
            try
            {
                var model = _mapper.Map<LiveStockVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<LiveStockVM> CastEntityToModel(IQueryable<LiveStock> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<LiveStockVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
