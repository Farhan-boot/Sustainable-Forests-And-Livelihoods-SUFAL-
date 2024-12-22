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
    public class PlantationSocialForestryBeneficiaryMapService : BaseService<PlantationSocialForestryBeneficiaryMapVM, PlantationSocialForestryBeneficiaryMap>, IPlantationSocialForestryBeneficiaryMapService
    {
        public IMapper _mapper;

        public PlantationSocialForestryBeneficiaryMapService(IPlantationSocialForestryBeneficiaryMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PlantationSocialForestryBeneficiaryMap CastModelToEntity(PlantationSocialForestryBeneficiaryMapVM model)
        {
            return _mapper.Map<PlantationSocialForestryBeneficiaryMap>(model);
        }

        public override PlantationSocialForestryBeneficiaryMapVM CastEntityToModel(PlantationSocialForestryBeneficiaryMap entity)
        {
            return _mapper.Map<PlantationSocialForestryBeneficiaryMapVM>(entity);
        }

        public override IList<PlantationSocialForestryBeneficiaryMapVM> CastEntityToModel(IQueryable<PlantationSocialForestryBeneficiaryMap> entity)
        {
            return _mapper.Map<IList<PlantationSocialForestryBeneficiaryMapVM>>(entity).ToList();
        }
    }
}