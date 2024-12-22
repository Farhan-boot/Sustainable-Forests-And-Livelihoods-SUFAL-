using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.CipManagement;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.CipManagement
{
    public class CipTeamMemberService : BaseService<CipTeamMemberVM, CipTeamMember>, ICipTeamMemberService
    {
        public IMapper _mapper;

        public CipTeamMemberService(ICipTeamMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CipTeamMember CastModelToEntity(CipTeamMemberVM model)
        {
            return _mapper.Map<CipTeamMember>(model);
        }

        public override CipTeamMemberVM CastEntityToModel(CipTeamMember entity)
        {
            return _mapper.Map<CipTeamMemberVM>(entity);
        }

        public override IList<CipTeamMemberVM> CastEntityToModel(IQueryable<CipTeamMember> entity)
        {
            return _mapper.Map<IList<CipTeamMemberVM>>(entity).ToList();
        }
    }
}