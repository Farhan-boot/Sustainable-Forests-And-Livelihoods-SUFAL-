using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
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
    public class CommunityTrainingService : BaseService<CommunityTrainingVM, CommunityTraining>, ICommunityTrainingService
    {
        private readonly ICommunityTrainingBusiness _business;
        public IMapper _mapper;

        public CommunityTrainingService(ICommunityTrainingBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override CommunityTraining CastModelToEntity(CommunityTrainingVM model)
        {
            try
            {
                return _mapper.Map<CommunityTraining>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override CommunityTrainingVM CastEntityToModel(CommunityTraining entity)
        {
            try
            {
                var model = _mapper.Map<CommunityTrainingVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<CommunityTrainingVM> CastEntityToModel(IQueryable<CommunityTraining> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<CommunityTrainingVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CommunityTrainingVM> CastEntityListToModel(List<CommunityTraining> entity)
        {
            return _mapper.Map<List<CommunityTrainingVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<CommunityTrainingVM> entity, string message)> GetTrainingByFilter(CommunityTrainingFilterVM filterData)
        {
            var result = await _business.GetTrainingByFilter(filterData);

            if (result.entity is not null)
            {
               // return (result.executionState, CastEntityListToModel(result.entity), result.message);
                return (result.executionState, _mapper.Map<PaginationResutl<CommunityTrainingVM>>(result.entity), result.message);

            }

            return (result.executionState, new PaginationResutl<CommunityTrainingVM>(), result.message);
        }

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long communityTrainingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                (ExecutionState executionState, bool isDeleted, string message) response = await _business.DeleteParticipant(communityTrainingParticipentsMapId);

                returnResponse = (response.executionState, response.isDeleted, response.message);
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, false, message: ex.Message);
            }

            return returnResponse;
        }


    }
}
