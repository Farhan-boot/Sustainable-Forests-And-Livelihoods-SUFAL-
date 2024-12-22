using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using PTSL.GENERIC.Service.Services.Interface.PatrollingSchedulingInformetion;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingService : BaseService<PatrollingSchedulingVM, PatrollingScheduling>, IPatrollingSchedulingService
    {
        private readonly IPatrollingSchedulingBusiness _business;
        public IMapper _mapper;

        public PatrollingSchedulingService(IPatrollingSchedulingBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override PatrollingScheduling CastModelToEntity(PatrollingSchedulingVM model)
        {
            try
            {
                return _mapper.Map<PatrollingScheduling>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override PatrollingSchedulingVM CastEntityToModel(PatrollingScheduling entity)
        {
            try
            {
                var model = _mapper.Map<PatrollingSchedulingVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<PatrollingSchedulingVM> CastEntityToModel(IQueryable<PatrollingScheduling> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<PatrollingSchedulingVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PatrollingSchedulingVM> CastEntityListToModel(List<PatrollingScheduling> entity)
        {
            return _mapper.Map<List<PatrollingSchedulingVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<PatrollingSchedulingVM> entity, string message)> GetTrainingByFilter(PatrollingSchedulingFilterVM filterData)
        {
            var result = await _business.GetTrainingByFilter(filterData);

            if (result.entity is not null)
            {
                //return (result.executionState, CastEntityListToModel(result.entity), result.message);

                return (result.executionState, _mapper.Map<PaginationResutl<PatrollingSchedulingVM>>(result.entity), result.message);
            }

            return (result.executionState, new PaginationResutl<PatrollingSchedulingVM>(), result.message);
        }

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long patrollingSchedulingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                (ExecutionState executionState, bool isDeleted, string message) response = await _business.DeleteParticipant(patrollingSchedulingParticipentsMapId);

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
