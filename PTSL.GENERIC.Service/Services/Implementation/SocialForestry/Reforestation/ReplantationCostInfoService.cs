using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.SocialForestry.Reforestation;

using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.SocialForestry.Reforestation
{
    public class ReplantationCostInfoService : BaseService<ReplantationCostInfoVM, ReplantationCostInfo>, IReplantationCostInfoService
    {
        public IMapper _mapper;

        public ReplantationCostInfoService(IReplantationCostInfoBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ReplantationCostInfo CastModelToEntity(ReplantationCostInfoVM model)
        {
            return _mapper.Map<ReplantationCostInfo>(model);
        }

        public override ReplantationCostInfoVM CastEntityToModel(ReplantationCostInfo entity)
        {
            return _mapper.Map<ReplantationCostInfoVM>(entity);
        }

        public override IList<ReplantationCostInfoVM> CastEntityToModel(IQueryable<ReplantationCostInfo> entity)
        {
            return _mapper.Map<IList<ReplantationCostInfoVM>>(entity).ToList();
        }
    }
}