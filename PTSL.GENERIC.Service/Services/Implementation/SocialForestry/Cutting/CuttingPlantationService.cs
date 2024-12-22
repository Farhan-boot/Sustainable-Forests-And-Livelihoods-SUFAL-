using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public class CuttingPlantationService : BaseService<CuttingPlantationVM, CuttingPlantation>, ICuttingPlantationService
    {
        private readonly ICuttingPlantationBusiness _business;
        public IMapper _mapper;

        public CuttingPlantationService(ICuttingPlantationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override CuttingPlantation CastModelToEntity(CuttingPlantationVM model)
        {
            return _mapper.Map<CuttingPlantation>(model);
        }

        public override CuttingPlantationVM CastEntityToModel(CuttingPlantation entity)
        {
            return _mapper.Map<CuttingPlantationVM>(entity);
        }

        public override IList<CuttingPlantationVM> CastEntityToModel(IQueryable<CuttingPlantation> entity)
        {
            return _mapper.Map<IList<CuttingPlantationVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, IList<CuttingPlantationVM> entity, string message)> ListByNewRaised(long newRaisedId)
        {
            var result = await _business.ListByNewRaised(newRaisedId);
            if (result.entity is null)
            {
                return (result.executionState, null!, result.message);
            }

            return (result.executionState, CastEntityToModel(result.entity), result.message);
        }


        public async Task<(ExecutionState executionState, List<CuttingPlantationVM> data, string message)> ListByFilter(NewRaisedPlantationFilter filter)
        {
            var data = await _business.ListByFilter(filter);
            if (data.entity is null)
            {
                return (data.executionState, null, data.message);
            }

            return (data.executionState, _mapper.Map<List<CuttingPlantationVM>>(data.entity), data.message);
        }


    }
}