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
    public class LiveStockTypeService : BaseService<LiveStockTypeVM, LiveStockType>, ILiveStockTypeService
    {
        public IMapper _mapper;

        public LiveStockTypeService(ILiveStockTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LiveStockType CastModelToEntity(LiveStockTypeVM model)
        {
            try
            {
                return _mapper.Map<LiveStockType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override LiveStockTypeVM CastEntityToModel(LiveStockType entity)
        {
            try
            {
                var model = _mapper.Map<LiveStockTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<LiveStockTypeVM> CastEntityToModel(IQueryable<LiveStockType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<LiveStockTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
