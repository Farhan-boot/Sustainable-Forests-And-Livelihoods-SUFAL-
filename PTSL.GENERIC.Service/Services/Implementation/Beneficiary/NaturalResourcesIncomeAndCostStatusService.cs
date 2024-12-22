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
    public class NaturalResourcesIncomeAndCostStatusService : BaseService<NaturalResourcesIncomeAndCostStatusVM, NaturalResourcesIncomeAndCostStatus>, INaturalResourcesIncomeAndCostStatusService
    {
        public IMapper _mapper;

        public NaturalResourcesIncomeAndCostStatusService(INaturalResourcesIncomeAndCostStatusBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override NaturalResourcesIncomeAndCostStatus CastModelToEntity(NaturalResourcesIncomeAndCostStatusVM model)
        {
            try
            {
                return _mapper.Map<NaturalResourcesIncomeAndCostStatus>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override NaturalResourcesIncomeAndCostStatusVM CastEntityToModel(NaturalResourcesIncomeAndCostStatus entity)
        {
            try
            {
                var model = _mapper.Map<NaturalResourcesIncomeAndCostStatusVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<NaturalResourcesIncomeAndCostStatusVM> CastEntityToModel(IQueryable<NaturalResourcesIncomeAndCostStatus> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<NaturalResourcesIncomeAndCostStatusVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
