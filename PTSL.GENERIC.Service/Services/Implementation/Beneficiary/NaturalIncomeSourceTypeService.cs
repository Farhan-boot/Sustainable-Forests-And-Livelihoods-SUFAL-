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
    public class NaturalIncomeSourceTypeService : BaseService<NaturalIncomeSourceTypeVM, NaturalIncomeSourceType>, INaturalIncomeSourceTypeService
    {
        public IMapper _mapper;

        public NaturalIncomeSourceTypeService(INaturalIncomeSourceTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override NaturalIncomeSourceType CastModelToEntity(NaturalIncomeSourceTypeVM model)
        {
            try
            {
                return _mapper.Map<NaturalIncomeSourceType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override NaturalIncomeSourceTypeVM CastEntityToModel(NaturalIncomeSourceType entity)
        {
            try
            {
                var model = _mapper.Map<NaturalIncomeSourceTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<NaturalIncomeSourceTypeVM> CastEntityToModel(IQueryable<NaturalIncomeSourceType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<NaturalIncomeSourceTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
