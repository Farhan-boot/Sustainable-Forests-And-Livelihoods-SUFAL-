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
    public class AnnualHouseholdExpenditureService : BaseService<AnnualHouseholdExpenditureVM, AnnualHouseholdExpenditure>, IAnnualHouseholdExpenditureService
    {
        public IMapper _mapper;

        public AnnualHouseholdExpenditureService(IAnnualHouseholdExpenditureBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override AnnualHouseholdExpenditure CastModelToEntity(AnnualHouseholdExpenditureVM model)
        {
            try
            {
                return _mapper.Map<AnnualHouseholdExpenditure>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override AnnualHouseholdExpenditureVM CastEntityToModel(AnnualHouseholdExpenditure entity)
        {
            try
            {
                var model = _mapper.Map<AnnualHouseholdExpenditureVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<AnnualHouseholdExpenditureVM> CastEntityToModel(IQueryable<AnnualHouseholdExpenditure> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<AnnualHouseholdExpenditureVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
