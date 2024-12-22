using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class GroupLDFInfoFormMemberService : BaseService<GroupLDFInfoFormMemberVM, GroupLDFInfoFormMember>, IGroupLDFInfoFormMemberService
    {
        public IMapper _mapper;

        public GroupLDFInfoFormMemberService(IGroupLDFInfoFormMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override GroupLDFInfoFormMember CastModelToEntity(GroupLDFInfoFormMemberVM model)
        {
            return _mapper.Map<GroupLDFInfoFormMember>(model);
        }

        public override GroupLDFInfoFormMemberVM CastEntityToModel(GroupLDFInfoFormMember entity)
        {
            return _mapper.Map<GroupLDFInfoFormMemberVM>(entity);
        }

        public override IList<GroupLDFInfoFormMemberVM> CastEntityToModel(IQueryable<GroupLDFInfoFormMember> entity)
        {
            return _mapper.Map<IList<GroupLDFInfoFormMemberVM>>(entity).ToList();
        }
    }
}