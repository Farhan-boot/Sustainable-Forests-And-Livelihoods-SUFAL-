using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestryTraining
{
    public class SocialForestryTrainingFileService : BaseService<SocialForestryTrainingFileVM, SocialForestryTrainingFile>, ISocialForestryTrainingFileService
    {
        public IMapper _mapper;

        public SocialForestryTrainingFileService(ISocialForestryTrainingFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SocialForestryTrainingFile CastModelToEntity(SocialForestryTrainingFileVM model)
        {
            return _mapper.Map<SocialForestryTrainingFile>(model);
        }

        public override SocialForestryTrainingFileVM CastEntityToModel(SocialForestryTrainingFile entity)
        {
            return _mapper.Map<SocialForestryTrainingFileVM>(entity);
        }

        public override IList<SocialForestryTrainingFileVM> CastEntityToModel(IQueryable<SocialForestryTrainingFile> entity)
        {
            return _mapper.Map<IList<SocialForestryTrainingFileVM>>(entity).ToList();
        }
    }
}