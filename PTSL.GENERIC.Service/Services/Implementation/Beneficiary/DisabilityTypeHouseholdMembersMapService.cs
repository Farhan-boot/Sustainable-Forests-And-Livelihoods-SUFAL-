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
    public class DisabilityTypeHouseholdMembersMapService : BaseService<DisabilityTypeHouseholdMembersMapVM, DisabilityTypeHouseholdMembersMap>, IDisabilityTypeHouseholdMembersMapService
    {
        public IMapper _mapper;

        public DisabilityTypeHouseholdMembersMapService(IDisabilityTypeHouseholdMembersMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override DisabilityTypeHouseholdMembersMap CastModelToEntity(DisabilityTypeHouseholdMembersMapVM model)
        {
            try
            {
                return _mapper.Map<DisabilityTypeHouseholdMembersMap>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override DisabilityTypeHouseholdMembersMapVM CastEntityToModel(DisabilityTypeHouseholdMembersMap entity)
        {
            try
            {
                var model = _mapper.Map<DisabilityTypeHouseholdMembersMapVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<DisabilityTypeHouseholdMembersMapVM> CastEntityToModel(IQueryable<DisabilityTypeHouseholdMembersMap> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<DisabilityTypeHouseholdMembersMapVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
