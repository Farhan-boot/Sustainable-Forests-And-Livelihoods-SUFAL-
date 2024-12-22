using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class BusinessService : BaseService<BusinessVM, Common.Entity.Beneficiary.Business>, IBusinessService
    {
        public IMapper _mapper;

        public BusinessService(IBusinessBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override Common.Entity.Beneficiary.Business CastModelToEntity(BusinessVM model)
        {
            try
            {
                return _mapper.Map<Common.Entity.Beneficiary.Business>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override BusinessVM CastEntityToModel(Common.Entity.Beneficiary.Business entity)
        {
            try
            {
                var model = _mapper.Map<BusinessVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<BusinessVM> CastEntityToModel(IQueryable<Common.Entity.Beneficiary.Business> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<BusinessVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
