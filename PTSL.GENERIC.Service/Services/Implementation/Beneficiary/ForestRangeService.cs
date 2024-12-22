using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class ForestRangeService : BaseService<ForestRangeVM, ForestRange>, IForestRangeService
    {
        private readonly IForestRangeBusiness _forestRangeBusiness;
        public IMapper _mapper;

        public ForestRangeService(IForestRangeBusiness business, IMapper mapper) : base(business)
        {
            _forestRangeBusiness = business;
            _mapper = mapper;
        }

        public override ForestRange CastModelToEntity(ForestRangeVM model)
        {
            try
            {
                return _mapper.Map<ForestRange>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ForestRangeVM CastEntityToModel(ForestRange entity)
        {
            try
            {
                var model = _mapper.Map<ForestRangeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ForestRangeVM> CastEntityToModel(IQueryable<ForestRange> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ForestRangeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<ForestRangeVM> entity, string message)> ListByForestDivision(long forestDivisionId)
        {
            (ExecutionState executionState, IList<ForestRangeVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<ForestRange> entity, string message) response = await _forestRangeBusiness.ListByForestDivision(forestDivisionId);

                if (response.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (response.executionState, entity: CastEntityToModel(response.entity), response.message);
                }
                else
                {
                    returnResponse = (response.executionState, entity: null, response.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
    }
}
