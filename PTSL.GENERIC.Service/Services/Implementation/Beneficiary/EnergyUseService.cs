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
    public class EnergyUseService : BaseService<EnergyUseVM, EnergyUse>, IEnergyUseService
    {
        public IMapper _mapper;

        public EnergyUseService(IEnergyUseBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override EnergyUse CastModelToEntity(EnergyUseVM model)
        {
            try
            {
                return _mapper.Map<EnergyUse>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override EnergyUseVM CastEntityToModel(EnergyUse entity)
        {
            try
            {
                var model = _mapper.Map<EnergyUseVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<EnergyUseVM> CastEntityToModel(IQueryable<EnergyUse> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<EnergyUseVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
