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
    public class PlantationPlantService : BaseService<PlantationPlantVM, PlantationPlant>, IPlantationPlantService
    {
        public IMapper _mapper;

        public PlantationPlantService(IPlantationPlantBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PlantationPlant CastModelToEntity(PlantationPlantVM model)
        {
            return _mapper.Map<PlantationPlant>(model);
        }

        public override PlantationPlantVM CastEntityToModel(PlantationPlant entity)
        {
            return _mapper.Map<PlantationPlantVM>(entity);
        }

        public override IList<PlantationPlantVM> CastEntityToModel(IQueryable<PlantationPlant> entity)
        {
            return _mapper.Map<IList<PlantationPlantVM>>(entity).ToList();
        }
    }
}