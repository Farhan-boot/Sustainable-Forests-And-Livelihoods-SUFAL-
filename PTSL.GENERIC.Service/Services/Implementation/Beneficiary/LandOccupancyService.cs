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
    public class LandOccupancyService : BaseService<LandOccupancyVM, LandOccupancy>, ILandOccupancyService
    {
        public IMapper _mapper;

        public LandOccupancyService(ILandOccupancyBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LandOccupancy CastModelToEntity(LandOccupancyVM model)
        {
            try
            {
                return _mapper.Map<LandOccupancy>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override LandOccupancyVM CastEntityToModel(LandOccupancy entity)
        {
            try
            {
                var model = _mapper.Map<LandOccupancyVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<LandOccupancyVM> CastEntityToModel(IQueryable<LandOccupancy> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<LandOccupancyVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
