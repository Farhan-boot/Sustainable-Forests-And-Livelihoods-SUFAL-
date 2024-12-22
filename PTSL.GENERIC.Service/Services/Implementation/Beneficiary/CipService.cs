using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class CipService : BaseService<CipVM, Cip>, ICipService
    {
        private readonly ICipBusiness _business;
        public IMapper _mapper;

        public CipService(ICipBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override Cip CastModelToEntity(CipVM model)
        {
            return _mapper.Map<Cip>(model);
        }

        public override CipVM CastEntityToModel(Cip entity)
        {
            return _mapper.Map<CipVM>(entity);
        }

        public override IList<CipVM> CastEntityToModel(IQueryable<Cip> entity)
        {
            return _mapper.Map<IList<CipVM>>(entity).ToList();
        }

        public IList<CipVM> CastEntityListToModel(IList<Cip> entity)
        {
            return _mapper.Map<IList<CipVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<CipVM> entity, string message)> ListByFilter(CipFilterVM filter)
        {
            var result = await _business.ListByFilter(filter);

            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, _mapper.Map<PaginationResutl<CipVM>>(result.entity), result.message);
            }

            return (result.executionState, null!, result.message);
        }

        public async Task<(ExecutionState executionState, IList<CipVM> entity, string message)> ListByFilterForBeneficiary(CipFilterVM filter)
        {
            var result = await _business.ListByFilterForBeneficiary(filter);

            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, null!, result.message);
        }
    }
}