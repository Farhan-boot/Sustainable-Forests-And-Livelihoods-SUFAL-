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
    public class ForestFcvVcfService : BaseService<ForestFcvVcfVM, ForestFcvVcf>, IForestFcvVcfService
    {
        private readonly IForestFcvVcfBusiness _ForestFcvVcfBusiness;
        public IMapper _mapper;

        public ForestFcvVcfService(IForestFcvVcfBusiness ForestFcvVcfBusiness, IMapper mapper) : base(ForestFcvVcfBusiness)
        {
            _ForestFcvVcfBusiness = ForestFcvVcfBusiness;
            _mapper = mapper;
            
        }

        public override ForestFcvVcf CastModelToEntity(ForestFcvVcfVM model)
        {
            try
            {
                return _mapper.Map<ForestFcvVcf>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ForestFcvVcfVM CastEntityToModel(ForestFcvVcf entity)
        {
            try
            {
                var model = _mapper.Map<ForestFcvVcfVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ForestFcvVcfVM> CastEntityToModel(IQueryable<ForestFcvVcf> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ForestFcvVcfVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message)> ListByForestBeat(long ForestBeatId)
        {
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message) response = await _ForestFcvVcfBusiness.ListByForestBeat(ForestBeatId);

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

        public async Task<(ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message)> GetFcvVcfByType(bool isFcv)
        {
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message) response = await _ForestFcvVcfBusiness.GetFcvVcfByType(isFcv);

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

        public async Task<(ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message)> ListByForestBeatAndType(long forestBeatId, FcvVcfType type)
        {
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IQueryable<ForestFcvVcf> entity, string message) response = await _ForestFcvVcfBusiness.ListByForestBeatAndType(forestBeatId, type);

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
