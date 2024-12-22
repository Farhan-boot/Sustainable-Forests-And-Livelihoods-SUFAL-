using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Reforestation
{
    public class ReplantationDamageInfoService : BaseService<ReplantationDamageInfoVM, ReplantationDamageInfo>, IReplantationDamageInfoService
    {
        public IMapper _mapper;

        public ReplantationDamageInfoService(IReplantationDamageInfoBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ReplantationDamageInfo CastModelToEntity(ReplantationDamageInfoVM model)
        {
            return _mapper.Map<ReplantationDamageInfo>(model);
        }

        public override ReplantationDamageInfoVM CastEntityToModel(ReplantationDamageInfo entity)
        {
            return _mapper.Map<ReplantationDamageInfoVM>(entity);
        }

        public override IList<ReplantationDamageInfoVM> CastEntityToModel(IQueryable<ReplantationDamageInfo> entity)
        {
            return _mapper.Map<IList<ReplantationDamageInfoVM>>(entity).ToList();
        }
    }
}