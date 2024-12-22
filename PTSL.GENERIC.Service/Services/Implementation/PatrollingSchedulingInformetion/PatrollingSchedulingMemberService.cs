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
    public class PatrollingSchedulingMemberService : BaseService<PatrollingSchedulingMemberVM, PatrollingSchedulingMember>, IPatrollingSchedulingMemberService
    {
        public IMapper _mapper;

        public PatrollingSchedulingMemberService(IPatrollingSchedulingMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PatrollingSchedulingMember CastModelToEntity(PatrollingSchedulingMemberVM model)
        {
            try
            {
                return _mapper.Map<PatrollingSchedulingMember>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override PatrollingSchedulingMemberVM CastEntityToModel(PatrollingSchedulingMember entity)
        {
            try
            {
                var model = _mapper.Map<PatrollingSchedulingMemberVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<PatrollingSchedulingMemberVM> CastEntityToModel(IQueryable<PatrollingSchedulingMember> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<PatrollingSchedulingMemberVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
