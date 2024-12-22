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
    public class DisabilityTypeService : BaseService<DisabilityTypeVM, DisabilityType>, IDisabilityTypeService
    {
        public IMapper _mapper;

        public DisabilityTypeService(IDisabilityTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override DisabilityType CastModelToEntity(DisabilityTypeVM model)
        {
            try
            {
                return _mapper.Map<DisabilityType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override DisabilityTypeVM CastEntityToModel(DisabilityType entity)
        {
            try
            {
                var model = _mapper.Map<DisabilityTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<DisabilityTypeVM> CastEntityToModel(IQueryable<DisabilityType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<DisabilityTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
