using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Patrolling;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Patrolling
{
    public class PatrollingScheduleInformetionService : BaseService<PatrollingScheduleInformetionVM, PatrollingScheduleInformetion>, IPatrollingScheduleInformetionService
    {
        public IMapper _mapper;
        private readonly IPatrollingScheduleInformetionBusiness _business;
        public PatrollingScheduleInformetionService(IPatrollingScheduleInformetionBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override PatrollingScheduleInformetion CastModelToEntity(PatrollingScheduleInformetionVM model)
        {
            try
            {
                return _mapper.Map<PatrollingScheduleInformetion>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override PatrollingScheduleInformetionVM CastEntityToModel(PatrollingScheduleInformetion entity)
        {
            try
            {
                var model = _mapper.Map<PatrollingScheduleInformetionVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<PatrollingScheduleInformetionVM> CastEntityToModel(IQueryable<PatrollingScheduleInformetion> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<PatrollingScheduleInformetionVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PatrollingScheduleInformetionVM> CastEntityListToModel(List<PatrollingScheduleInformetion> entity)
        {
            return _mapper.Map<List<PatrollingScheduleInformetionVM>>(entity);
        }

        public async Task<(ExecutionState executionState, List<PatrollingScheduleInformetionVM> entity, string message)> GetPatrollingScheduleInformetionByFilter(PatrollingScheduleFilterVM filterData)
        {
            var result = await _business.GetPatrollingScheduleInformetionByFilter(filterData);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<PatrollingScheduleInformetionVM>(), result.message);
        }
    }
}
