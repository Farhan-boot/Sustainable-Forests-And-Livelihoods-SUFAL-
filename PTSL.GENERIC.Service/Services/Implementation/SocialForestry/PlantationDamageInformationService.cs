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
    public class PlantationDamageInformationService : BaseService<PlantationDamageInformationVM, PlantationDamageInformation>, IPlantationDamageInformationService
    {
        public IMapper _mapper;

        public PlantationDamageInformationService(IPlantationDamageInformationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PlantationDamageInformation CastModelToEntity(PlantationDamageInformationVM model)
        {
            return _mapper.Map<PlantationDamageInformation>(model);
        }

        public override PlantationDamageInformationVM CastEntityToModel(PlantationDamageInformation entity)
        {
            return _mapper.Map<PlantationDamageInformationVM>(entity);
        }

        public override IList<PlantationDamageInformationVM> CastEntityToModel(IQueryable<PlantationDamageInformation> entity)
        {
            return _mapper.Map<IList<PlantationDamageInformationVM>>(entity).ToList();
        }
    }
}