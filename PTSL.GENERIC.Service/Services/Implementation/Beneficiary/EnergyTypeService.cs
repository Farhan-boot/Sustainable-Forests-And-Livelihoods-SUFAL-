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
    public class EnergyTypeService : BaseService<EnergyTypeVM, EnergyType>, IEnergyTypeService
    {
        public IMapper _mapper;

        public EnergyTypeService(IEnergyTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override EnergyType CastModelToEntity(EnergyTypeVM model)
        {
            try
            {
                return _mapper.Map<EnergyType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override EnergyTypeVM CastEntityToModel(EnergyType entity)
        {
            try
            {
                var model = _mapper.Map<EnergyTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<EnergyTypeVM> CastEntityToModel(IQueryable<EnergyType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<EnergyTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
