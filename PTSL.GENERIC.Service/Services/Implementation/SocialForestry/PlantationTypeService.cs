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
    public class PlantationTypeService : BaseService<PlantationTypeVM, PlantationType>, IPlantationTypeService
    {
        public IMapper _mapper;

        public PlantationTypeService(IPlantationTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PlantationType CastModelToEntity(PlantationTypeVM model)
        {
            return _mapper.Map<PlantationType>(model);
        }

        public override PlantationTypeVM CastEntityToModel(PlantationType entity)
        {
            return _mapper.Map<PlantationTypeVM>(entity);
        }

        public override IList<PlantationTypeVM> CastEntityToModel(IQueryable<PlantationType> entity)
        {
            return _mapper.Map<IList<PlantationTypeVM>>(entity).ToList();
        }
    }
}