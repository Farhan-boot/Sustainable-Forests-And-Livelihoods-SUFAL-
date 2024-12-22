using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using PTSL.GENERIC.Service.Services.Interface.PatrollingSchedulingInformetion;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingParticipentsMapService : BaseService<PatrollingSchedulingParticipentsMapVM, PatrollingSchedulingParticipentsMap>, IPatrollingSchedulingParticipentsMapService
    {
        public IMapper _mapper;

        public PatrollingSchedulingParticipentsMapService(IPatrollingSchedulingParticipentsMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PatrollingSchedulingParticipentsMap CastModelToEntity(PatrollingSchedulingParticipentsMapVM model)
        {
            try
            {
                return _mapper.Map<PatrollingSchedulingParticipentsMap>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override PatrollingSchedulingParticipentsMapVM CastEntityToModel(PatrollingSchedulingParticipentsMap entity)
        {
            try
            {
                var model = _mapper.Map<PatrollingSchedulingParticipentsMapVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<PatrollingSchedulingParticipentsMapVM> CastEntityToModel(IQueryable<PatrollingSchedulingParticipentsMap> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<PatrollingSchedulingParticipentsMapVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
