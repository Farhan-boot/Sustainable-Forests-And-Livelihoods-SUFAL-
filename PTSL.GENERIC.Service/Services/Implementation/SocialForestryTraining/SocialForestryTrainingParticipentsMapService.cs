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
    public class SocialForestryTrainingParticipentsMapService : BaseService<SocialForestryTrainingParticipentsMapVM, SocialForestryTrainingParticipentsMap>, ISocialForestryTrainingParticipentsMapService
    {
        public IMapper _mapper;

        public SocialForestryTrainingParticipentsMapService(ISocialForestryTrainingParticipentsMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SocialForestryTrainingParticipentsMap CastModelToEntity(SocialForestryTrainingParticipentsMapVM model)
        {
            return _mapper.Map<SocialForestryTrainingParticipentsMap>(model);
        }

        public override SocialForestryTrainingParticipentsMapVM CastEntityToModel(SocialForestryTrainingParticipentsMap entity)
        {
            return _mapper.Map<SocialForestryTrainingParticipentsMapVM>(entity);
        }

        public override IList<SocialForestryTrainingParticipentsMapVM> CastEntityToModel(IQueryable<SocialForestryTrainingParticipentsMap> entity)
        {
            return _mapper.Map<IList<SocialForestryTrainingParticipentsMapVM>>(entity).ToList();
        }
    }
}