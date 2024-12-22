using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public class RealizationService : BaseService<RealizationVM, Realization>, IRealizationService
    {
        private readonly IRealizationBusiness _business;
        public IMapper _mapper;

        public RealizationService(IRealizationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override Realization CastModelToEntity(RealizationVM model)
        {
            return _mapper.Map<Realization>(model);
        }

        public override RealizationVM CastEntityToModel(Realization entity)
        {
            return _mapper.Map<RealizationVM>(entity);
        }

        public override IList<RealizationVM> CastEntityToModel(IQueryable<Realization> entity)
        {
            return _mapper.Map<IList<RealizationVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<RealizationVM> data, string message)> GetRealizationsByCuttingId(long id)
        {
            var list = await _business.GetRealizationsByCuttingId(id);
            if (list.data is null)
            {
                return (ExecutionState.Failure,  new List<RealizationVM>(), "Not data found");
            }

            return (ExecutionState.Success, _mapper.Map<List<RealizationVM>>(list.data), "Not data found");
        }

        public async Task<(ExecutionState executionState, DefaultRealizationDataVM data, string message)> GetDefaultRealizationData(long cuttingPlantationId)
        {
            var list = await _business.GetDefaultRealizationData(cuttingPlantationId);
            if (list.data is null)
            {
                return (ExecutionState.Failure, null!, "Not data found");
            }

            list.data.Realizations = _mapper.Map<List<RealizationVM>>(list.data.RealizationEntities);
            list.data.RealizationEntities.Clear();

            return (ExecutionState.Success, list.data, "Not data found");
        }
    }
}