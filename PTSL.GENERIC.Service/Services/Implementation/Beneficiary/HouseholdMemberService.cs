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
    public class HouseholdMemberService : BaseService<HouseholdMemberVM, HouseholdMember>, IHouseholdMemberService
    {
        public IMapper _mapper;

        public HouseholdMemberService(IHouseholdMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override HouseholdMember CastModelToEntity(HouseholdMemberVM model)
        {
            try
            {
                return _mapper.Map<HouseholdMember>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override HouseholdMemberVM CastEntityToModel(HouseholdMember entity)
        {
            try
            {
                var model = _mapper.Map<HouseholdMemberVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<HouseholdMemberVM> CastEntityToModel(IQueryable<HouseholdMember> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<HouseholdMemberVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
