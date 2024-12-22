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
    public class BusinessIncomeSourceTypeService : BaseService<BusinessIncomeSourceTypeVM, BusinessIncomeSourceType>, IBusinessIncomeSourceTypeService
    {
        public IMapper _mapper;

        public BusinessIncomeSourceTypeService(IBusinessIncomeSourceTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override BusinessIncomeSourceType CastModelToEntity(BusinessIncomeSourceTypeVM model)
        {
            try
            {
                return _mapper.Map<BusinessIncomeSourceType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override BusinessIncomeSourceTypeVM CastEntityToModel(BusinessIncomeSourceType entity)
        {
            try
            {
                var model = _mapper.Map<BusinessIncomeSourceTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<BusinessIncomeSourceTypeVM> CastEntityToModel(IQueryable<BusinessIncomeSourceType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<BusinessIncomeSourceTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
