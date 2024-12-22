using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry
{
    public class PlantationUnitService : BaseService<PlantationUnitVM, PlantationUnit>, IPlantationUnitService
    {
        private readonly IPlantationUnitBusiness _business;
        public IMapper _mapper;

        public PlantationUnitService(IPlantationUnitBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override PlantationUnit CastModelToEntity(PlantationUnitVM model)
        {
            return _mapper.Map<PlantationUnit>(model);
        }

        public override PlantationUnitVM CastEntityToModel(PlantationUnit entity)
        {
            return _mapper.Map<PlantationUnitVM>(entity);
        }

        public override IList<PlantationUnitVM> CastEntityToModel(IQueryable<PlantationUnit> entity)
        {
            return _mapper.Map<IList<PlantationUnitVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<PlantationUnitVM> entity, string message)> ListByType(UnitType unitType)
        {
            var data = await _business.ListByType(unitType);

            return (data.executionState, _mapper.Map<List<PlantationUnitVM>>(data.entity), "Ok");
        }
    }
}