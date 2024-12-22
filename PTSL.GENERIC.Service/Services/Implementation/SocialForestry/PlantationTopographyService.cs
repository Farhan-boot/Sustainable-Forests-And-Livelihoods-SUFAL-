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
    public class PlantationTopographyService : BaseService<PlantationTopographyVM, PlantationTopography>, IPlantationTopographyService
    {
        public IMapper _mapper;

        public PlantationTopographyService(IPlantationTopographyBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PlantationTopography CastModelToEntity(PlantationTopographyVM model)
        {
            return _mapper.Map<PlantationTopography>(model);
        }

        public override PlantationTopographyVM CastEntityToModel(PlantationTopography entity)
        {
            return _mapper.Map<PlantationTopographyVM>(entity);
        }

        public override IList<PlantationTopographyVM> CastEntityToModel(IQueryable<PlantationTopography> entity)
        {
            return _mapper.Map<IList<PlantationTopographyVM>>(entity).ToList();
        }
    }
}