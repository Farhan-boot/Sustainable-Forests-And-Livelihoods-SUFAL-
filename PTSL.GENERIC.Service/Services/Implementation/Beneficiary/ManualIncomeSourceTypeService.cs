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
    public class ManualIncomeSourceTypeService : BaseService<ManualIncomeSourceTypeVM, ManualIncomeSourceType>, IManualIncomeSourceTypeService
    {
        public IMapper _mapper;

        public ManualIncomeSourceTypeService(IManualIncomeSourceTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ManualIncomeSourceType CastModelToEntity(ManualIncomeSourceTypeVM model)
        {
            try
            {
                return _mapper.Map<ManualIncomeSourceType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ManualIncomeSourceTypeVM CastEntityToModel(ManualIncomeSourceType entity)
        {
            try
            {
                var model = _mapper.Map<ManualIncomeSourceTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ManualIncomeSourceTypeVM> CastEntityToModel(IQueryable<ManualIncomeSourceType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ManualIncomeSourceTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
