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
    public class RelationWithHeadHouseHoldTypeService : BaseService<RelationWithHeadHouseHoldTypeVM, RelationWithHeadHouseHoldType>, IRelationWithHeadHouseHoldTypeService
    {
        public IMapper _mapper;

        public RelationWithHeadHouseHoldTypeService(IRelationWithHeadHouseHoldTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override RelationWithHeadHouseHoldType CastModelToEntity(RelationWithHeadHouseHoldTypeVM model)
        {
            try
            {
                return _mapper.Map<RelationWithHeadHouseHoldType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override RelationWithHeadHouseHoldTypeVM CastEntityToModel(RelationWithHeadHouseHoldType entity)
        {
            try
            {
                var model = _mapper.Map<RelationWithHeadHouseHoldTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<RelationWithHeadHouseHoldTypeVM> CastEntityToModel(IQueryable<RelationWithHeadHouseHoldType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<RelationWithHeadHouseHoldTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
