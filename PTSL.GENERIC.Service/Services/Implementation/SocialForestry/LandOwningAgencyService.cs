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
    public class LandOwningAgencyService : BaseService<LandOwningAgencyVM, LandOwningAgency>, ILandOwningAgencyService
    {
        public IMapper _mapper;

        public LandOwningAgencyService(ILandOwningAgencyBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LandOwningAgency CastModelToEntity(LandOwningAgencyVM model)
        {
            return _mapper.Map<LandOwningAgency>(model);
        }

        public override LandOwningAgencyVM CastEntityToModel(LandOwningAgency entity)
        {
            return _mapper.Map<LandOwningAgencyVM>(entity);
        }

        public override IList<LandOwningAgencyVM> CastEntityToModel(IQueryable<LandOwningAgency> entity)
        {
            return _mapper.Map<IList<LandOwningAgencyVM>>(entity).ToList();
        }
    }
}