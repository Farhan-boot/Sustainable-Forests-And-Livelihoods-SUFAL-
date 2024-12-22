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
    public class ReplantationNurseryInfoService : BaseService<ReplantationNurseryInfoVM, ReplantationNurseryInfo>, IReplantationNurseryInfoService
    {
        public IMapper _mapper;

        public ReplantationNurseryInfoService(IReplantationNurseryInfoBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ReplantationNurseryInfo CastModelToEntity(ReplantationNurseryInfoVM model)
        {
            return _mapper.Map<ReplantationNurseryInfo>(model);
        }

        public override ReplantationNurseryInfoVM CastEntityToModel(ReplantationNurseryInfo entity)
        {
            return _mapper.Map<ReplantationNurseryInfoVM>(entity);
        }

        public override IList<ReplantationNurseryInfoVM> CastEntityToModel(IQueryable<ReplantationNurseryInfo> entity)
        {
            return _mapper.Map<IList<ReplantationNurseryInfoVM>>(entity).ToList();
        }
    }
}