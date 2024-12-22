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
    public class EthnicityService : BaseService<EthnicityVM, Ethnicity>, IEthnicityService
    {
        public IMapper _mapper;

        public EthnicityService(IEthnicityBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override Ethnicity CastModelToEntity(EthnicityVM model)
        {
            try
            {
                return _mapper.Map<Ethnicity>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override EthnicityVM CastEntityToModel(Ethnicity entity)
        {
            try
            {
                var model = _mapper.Map<EthnicityVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<EthnicityVM> CastEntityToModel(IQueryable<Ethnicity> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<EthnicityVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
