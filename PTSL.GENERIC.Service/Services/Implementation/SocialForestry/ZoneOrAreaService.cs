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
    public class ZoneOrAreaService : BaseService<ZoneOrAreaVM, ZoneOrArea>, IZoneOrAreaService
    {
        public IMapper _mapper;

        public ZoneOrAreaService(IZoneOrAreaBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ZoneOrArea CastModelToEntity(ZoneOrAreaVM model)
        {
            return _mapper.Map<ZoneOrArea>(model);
        }

        public override ZoneOrAreaVM CastEntityToModel(ZoneOrArea entity)
        {
            return _mapper.Map<ZoneOrAreaVM>(entity);
        }

        public override IList<ZoneOrAreaVM> CastEntityToModel(IQueryable<ZoneOrArea> entity)
        {
            return _mapper.Map<IList<ZoneOrAreaVM>>(entity).ToList();
        }
    }
}