using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Implementation.Capacity
{
    public class CommunityTrainingParticipentsMapService : BaseService<CommunityTrainingParticipentsMapVM, CommunityTrainingParticipentsMap>, ICommunityTrainingParticipentsMapService
    {
        public IMapper _mapper;
        private readonly ICommunityTrainingParticipentsMapBusiness _business;

        public CommunityTrainingParticipentsMapService(ICommunityTrainingParticipentsMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override CommunityTrainingParticipentsMap CastModelToEntity(CommunityTrainingParticipentsMapVM model)
        {
            try
            {
                return _mapper.Map<CommunityTrainingParticipentsMap>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override CommunityTrainingParticipentsMapVM CastEntityToModel(CommunityTrainingParticipentsMap entity)
        {
            try
            {
                var model = _mapper.Map<CommunityTrainingParticipentsMapVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<CommunityTrainingParticipentsMapVM> CastEntityToModel(IQueryable<CommunityTrainingParticipentsMap> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<CommunityTrainingParticipentsMapVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CommunityTrainingParticipentsMapVM> CastEntityListToModel(IList<CommunityTrainingParticipentsMap> entity)
        {
            return _mapper.Map<List<CommunityTrainingParticipentsMapVM>>(entity);
        }

        public async Task<(ExecutionState executionState, IList<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message)> GetCommunityTrainingParticipentsMapByFilter(CommunityTrainingFilterByBeneficiaryVM filterData)
        {
            (ExecutionState executionState, IList<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, IList<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message) result = await _business.GetCommunityTrainingParticipentsMapByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (result.executionState, result.entity, result.message);
                }
                else
                {
                    returnResponse = (result.executionState, entity: null, result.message);
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
