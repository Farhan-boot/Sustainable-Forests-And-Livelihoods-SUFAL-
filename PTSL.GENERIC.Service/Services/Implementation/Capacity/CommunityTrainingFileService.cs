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
    public class CommunityTrainingFileService : BaseService<CommunityTrainingFileVM, CommunityTrainingFile>, ICommunityTrainingFileService
    {
        public IMapper _mapper;

        public CommunityTrainingFileService(ICommunityTrainingFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CommunityTrainingFile CastModelToEntity(CommunityTrainingFileVM model)
        {
            try
            {
                return _mapper.Map<CommunityTrainingFile>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override CommunityTrainingFileVM CastEntityToModel(CommunityTrainingFile entity)
        {
            try
            {
                var model = _mapper.Map<CommunityTrainingFileVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<CommunityTrainingFileVM> CastEntityToModel(IQueryable<CommunityTrainingFile> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<CommunityTrainingFileVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
