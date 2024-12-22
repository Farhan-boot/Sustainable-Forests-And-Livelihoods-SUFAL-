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
    public class ReplantationSocialForestryBeneficiaryMapService : BaseService<ReplantationSocialForestryBeneficiaryMapVM, ReplantationSocialForestryBeneficiaryMap>, IReplantationSocialForestryBeneficiaryMapService
    {
        public IMapper _mapper;

        public ReplantationSocialForestryBeneficiaryMapService(IReplantationSocialForestryBeneficiaryMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ReplantationSocialForestryBeneficiaryMap CastModelToEntity(ReplantationSocialForestryBeneficiaryMapVM model)
        {
            return _mapper.Map<ReplantationSocialForestryBeneficiaryMap>(model);
        }

        public override ReplantationSocialForestryBeneficiaryMapVM CastEntityToModel(ReplantationSocialForestryBeneficiaryMap entity)
        {
            return _mapper.Map<ReplantationSocialForestryBeneficiaryMapVM>(entity);
        }

        public override IList<ReplantationSocialForestryBeneficiaryMapVM> CastEntityToModel(IQueryable<ReplantationSocialForestryBeneficiaryMap> entity)
        {
            return _mapper.Map<IList<ReplantationSocialForestryBeneficiaryMapVM>>(entity).ToList();
        }
    }
}