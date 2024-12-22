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
    public class ReplantationLaborInfoService : BaseService<ReplantationLaborInfoVM, ReplantationLaborInfo>, IReplantationLaborInfoService
    {
        public IMapper _mapper;

        public ReplantationLaborInfoService(IReplantationLaborInfoBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ReplantationLaborInfo CastModelToEntity(ReplantationLaborInfoVM model)
        {
            return _mapper.Map<ReplantationLaborInfo>(model);
        }

        public override ReplantationLaborInfoVM CastEntityToModel(ReplantationLaborInfo entity)
        {
            return _mapper.Map<ReplantationLaborInfoVM>(entity);
        }

        public override IList<ReplantationLaborInfoVM> CastEntityToModel(IQueryable<ReplantationLaborInfo> entity)
        {
            return _mapper.Map<IList<ReplantationLaborInfoVM>>(entity).ToList();
        }
    }
}