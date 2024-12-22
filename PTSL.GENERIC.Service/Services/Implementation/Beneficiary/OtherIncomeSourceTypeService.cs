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
    public class OtherIncomeSourceTypeService : BaseService<OtherIncomeSourceTypeVM, OtherIncomeSourceType>, IOtherIncomeSourceTypeService
    {
        public IMapper _mapper;

        public OtherIncomeSourceTypeService(IOtherIncomeSourceTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override OtherIncomeSourceType CastModelToEntity(OtherIncomeSourceTypeVM model)
        {
            try
            {
                return _mapper.Map<OtherIncomeSourceType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override OtherIncomeSourceTypeVM CastEntityToModel(OtherIncomeSourceType entity)
        {
            try
            {
                var model = _mapper.Map<OtherIncomeSourceTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<OtherIncomeSourceTypeVM> CastEntityToModel(IQueryable<OtherIncomeSourceType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<OtherIncomeSourceTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
