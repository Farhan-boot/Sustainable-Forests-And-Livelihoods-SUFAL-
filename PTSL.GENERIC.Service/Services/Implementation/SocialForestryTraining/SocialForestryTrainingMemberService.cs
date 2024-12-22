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
    public class SocialForestryTrainingMemberService : BaseService<SocialForestryTrainingMemberVM, SocialForestryTrainingMember>, ISocialForestryTrainingMemberService
    {
        public IMapper _mapper;

        public SocialForestryTrainingMemberService(ISocialForestryTrainingMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SocialForestryTrainingMember CastModelToEntity(SocialForestryTrainingMemberVM model)
        {
            return _mapper.Map<SocialForestryTrainingMember>(model);
        }

        public override SocialForestryTrainingMemberVM CastEntityToModel(SocialForestryTrainingMember entity)
        {
            return _mapper.Map<SocialForestryTrainingMemberVM>(entity);
        }

        public override IList<SocialForestryTrainingMemberVM> CastEntityToModel(IQueryable<SocialForestryTrainingMember> entity)
        {
            return _mapper.Map<IList<SocialForestryTrainingMemberVM>>(entity).ToList();
        }
    }
}