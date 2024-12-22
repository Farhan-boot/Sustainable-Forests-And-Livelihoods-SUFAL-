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
    public class PlantationCauseOfDamageService : BaseService<PlantationCauseOfDamageVM, PlantationCauseOfDamage>, IPlantationCauseOfDamageService
    {
        public IMapper _mapper;

        public PlantationCauseOfDamageService(IPlantationCauseOfDamageBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PlantationCauseOfDamage CastModelToEntity(PlantationCauseOfDamageVM model)
        {
            return _mapper.Map<PlantationCauseOfDamage>(model);
        }

        public override PlantationCauseOfDamageVM CastEntityToModel(PlantationCauseOfDamage entity)
        {
            return _mapper.Map<PlantationCauseOfDamageVM>(entity);
        }

        public override IList<PlantationCauseOfDamageVM> CastEntityToModel(IQueryable<PlantationCauseOfDamage> entity)
        {
            return _mapper.Map<IList<PlantationCauseOfDamageVM>>(entity).ToList();
        }
    }
}