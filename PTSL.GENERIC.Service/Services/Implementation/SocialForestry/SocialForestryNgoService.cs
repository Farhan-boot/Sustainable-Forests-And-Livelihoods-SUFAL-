using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestry
{
    public class SocialForestryNgoService : BaseService<SocialForestryNgoVM, SocialForestryNgo>, ISocialForestryNgoService
    {
        public IMapper _mapper;

        public SocialForestryNgoService(ISocialForestryNgoBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SocialForestryNgo CastModelToEntity(SocialForestryNgoVM model)
        {
            return _mapper.Map<SocialForestryNgo>(model);
        }

        public override SocialForestryNgoVM CastEntityToModel(SocialForestryNgo entity)
        {
            return _mapper.Map<SocialForestryNgoVM>(entity);
        }

        public override IList<SocialForestryNgoVM> CastEntityToModel(IQueryable<SocialForestryNgo> entity)
        {
            return _mapper.Map<IList<SocialForestryNgoVM>>(entity).ToList();
        }
    }
}