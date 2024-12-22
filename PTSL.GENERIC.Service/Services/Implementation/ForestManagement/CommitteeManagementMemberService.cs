using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.ForestManagement
{
    public class CommitteeManagementMemberService : BaseService<CommitteeManagementMemberVM, CommitteeManagementMember>, ICommitteeManagementMemberService
    {
        public IMapper _mapper;

        public CommitteeManagementMemberService(ICommitteeManagementMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CommitteeManagementMember CastModelToEntity(CommitteeManagementMemberVM model)
        {
            return _mapper.Map<CommitteeManagementMember>(model);
        }

        public override CommitteeManagementMemberVM CastEntityToModel(CommitteeManagementMember entity)
        {
            return _mapper.Map<CommitteeManagementMemberVM>(entity);
        }

        public override IList<CommitteeManagementMemberVM> CastEntityToModel(IQueryable<CommitteeManagementMember> entity)
        {
            return _mapper.Map<IList<CommitteeManagementMemberVM>>(entity).ToList();
        }
    }
}