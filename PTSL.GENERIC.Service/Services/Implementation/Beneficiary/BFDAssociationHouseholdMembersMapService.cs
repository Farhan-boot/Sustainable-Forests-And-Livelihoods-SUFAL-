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
    public class BFDAssociationHouseholdMembersMapService : BaseService<BFDAssociationHouseholdMembersMapVM, BFDAssociationHouseholdMembersMap>, IBFDAssociationHouseholdMembersMapService
    {
        public IMapper _mapper;

        public BFDAssociationHouseholdMembersMapService(IBFDAssociationHouseholdMembersMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override BFDAssociationHouseholdMembersMap CastModelToEntity(BFDAssociationHouseholdMembersMapVM model)
        {
            try
            {
                return _mapper.Map<BFDAssociationHouseholdMembersMap>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override BFDAssociationHouseholdMembersMapVM CastEntityToModel(BFDAssociationHouseholdMembersMap entity)
        {
            try
            {
                var model = _mapper.Map<BFDAssociationHouseholdMembersMapVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<BFDAssociationHouseholdMembersMapVM> CastEntityToModel(IQueryable<BFDAssociationHouseholdMembersMap> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<BFDAssociationHouseholdMembersMapVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
