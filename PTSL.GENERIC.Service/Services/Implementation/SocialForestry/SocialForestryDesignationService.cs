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
    public class SocialForestryDesignationService : BaseService<SocialForestryDesignationVM, SocialForestryDesignation>, ISocialForestryDesignationService
    {
        public IMapper _mapper;

        public SocialForestryDesignationService(ISocialForestryDesignationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SocialForestryDesignation CastModelToEntity(SocialForestryDesignationVM model)
        {
            return _mapper.Map<SocialForestryDesignation>(model);
        }

        public override SocialForestryDesignationVM CastEntityToModel(SocialForestryDesignation entity)
        {
            return _mapper.Map<SocialForestryDesignationVM>(entity);
        }

        public override IList<SocialForestryDesignationVM> CastEntityToModel(IQueryable<SocialForestryDesignation> entity)
        {
            return _mapper.Map<IList<SocialForestryDesignationVM>>(entity).ToList();
        }
    }
}