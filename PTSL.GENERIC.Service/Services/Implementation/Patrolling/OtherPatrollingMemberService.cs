using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Business.Businesses.Interface.Patrolling;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.Services.Patrolling;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Patrolling
{
    public class OtherPatrollingMemberService : BaseService<OtherPatrollingMemberVM, OtherPatrollingMember>, IOtherPatrollingMemberService
    {
        public IMapper _mapper;

        public OtherPatrollingMemberService(IOtherPatrollingMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override OtherPatrollingMember CastModelToEntity(OtherPatrollingMemberVM model)
        {
            try
            {
                return _mapper.Map<OtherPatrollingMember>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override OtherPatrollingMemberVM CastEntityToModel(OtherPatrollingMember entity)
        {
            try
            {
                var model = _mapper.Map<OtherPatrollingMemberVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<OtherPatrollingMemberVM> CastEntityToModel(IQueryable<OtherPatrollingMember> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<OtherPatrollingMemberVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
