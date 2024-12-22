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
    public class ForestDivisionService : BaseService<ForestDivisionVM, ForestDivision>, IForestDivisionService
    {
        private readonly IForestDivisionBusiness _forestDivisionBusiness;
        public IMapper _mapper;

        public ForestDivisionService(IForestDivisionBusiness business, IMapper mapper) : base(business)
        {
            _forestDivisionBusiness = business;
            _mapper = mapper;
        }

        public override ForestDivision CastModelToEntity(ForestDivisionVM model)
        {
            try
            {
                return _mapper.Map<ForestDivision>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ForestDivisionVM CastEntityToModel(ForestDivision entity)
        {
            try
            {
                var model = _mapper.Map<ForestDivisionVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ForestDivisionVM> CastEntityToModel(IQueryable<ForestDivision> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ForestDivisionVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<(ExecutionState executionState, IList<ForestDivisionVM> entity, string message)> ListByForestCircle(long forestCircleId)
        {
            (ExecutionState executionState, IList<ForestDivisionVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<ForestDivision> entity, string message) response = await _forestDivisionBusiness.ListByForestCircle(forestCircleId);

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

        public async Task<(ExecutionState executionState, IList<ForestDivisionVM> entity, string message)> ListByMultipleForestCircle(List<long> forestCircleIds)
        {
            (ExecutionState executionState, IList<ForestDivisionVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<ForestDivision> entity, string message) response = await _forestDivisionBusiness.ListByMultipleForestCircle(forestCircleIds);

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
