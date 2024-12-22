using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.Capacity
{
    public class CommunityTrainingTypeService : BaseService<CommunityTrainingTypeVM, CommunityTrainingType>, ICommunityTrainingTypeService
    {
        public IMapper _mapper;

        public CommunityTrainingTypeService(ICommunityTrainingTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CommunityTrainingType CastModelToEntity(CommunityTrainingTypeVM model)
        {
            try
            {
                return _mapper.Map<CommunityTrainingType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override CommunityTrainingTypeVM CastEntityToModel(CommunityTrainingType entity)
        {
            try
            {
                var model = _mapper.Map<CommunityTrainingTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<CommunityTrainingTypeVM> CastEntityToModel(IQueryable<CommunityTrainingType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<CommunityTrainingTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
