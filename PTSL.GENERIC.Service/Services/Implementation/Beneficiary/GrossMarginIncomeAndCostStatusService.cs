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
    public class GrossMarginIncomeAndCostStatusService : BaseService<GrossMarginIncomeAndCostStatusVM, GrossMarginIncomeAndCostStatus>, IGrossMarginIncomeAndCostStatusService
    {
        public IMapper _mapper;

        public GrossMarginIncomeAndCostStatusService(IGrossMarginIncomeAndCostStatusBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override GrossMarginIncomeAndCostStatus CastModelToEntity(GrossMarginIncomeAndCostStatusVM model)
        {
            try
            {
                return _mapper.Map<GrossMarginIncomeAndCostStatus>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override GrossMarginIncomeAndCostStatusVM CastEntityToModel(GrossMarginIncomeAndCostStatus entity)
        {
            try
            {
                var model = _mapper.Map<GrossMarginIncomeAndCostStatusVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<GrossMarginIncomeAndCostStatusVM> CastEntityToModel(IQueryable<GrossMarginIncomeAndCostStatus> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<GrossMarginIncomeAndCostStatusVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
