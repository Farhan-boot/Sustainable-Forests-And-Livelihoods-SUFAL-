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
    public class ForestBeatService : BaseService<ForestBeatVM, ForestBeat>, IForestBeatService
    {
        private readonly IForestBeatBusiness _forestBeatService;
        public IMapper _mapper;

        public ForestBeatService(IForestBeatBusiness business, IMapper mapper) : base(business)
        {
            this._forestBeatService=business;
            _mapper = mapper;
        }

        public override ForestBeat CastModelToEntity(ForestBeatVM model)
        {
            try
            {
                return _mapper.Map<ForestBeat>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ForestBeatVM CastEntityToModel(ForestBeat entity)
        {
            try
            {
                var model = _mapper.Map<ForestBeatVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ForestBeatVM> CastEntityToModel(IQueryable<ForestBeat> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ForestBeatVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<ForestBeatVM> entity, string message)> ListByForestRange(long forestRangeId)
        {
            (ExecutionState executionState, IList<ForestBeatVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<ForestBeat> entity, string message) response = await _forestBeatService.ListByForestRange(forestRangeId);

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
