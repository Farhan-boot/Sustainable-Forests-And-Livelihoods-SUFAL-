using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestryMeeting
{
    public class SocialForestryMeetingMemberService : BaseService<SocialForestryMeetingMemberVM, SocialForestryMeetingMember>, ISocialForestryMeetingMemberService
    {
        public IMapper _mapper;

        public SocialForestryMeetingMemberService(ISocialForestryMeetingMemberBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SocialForestryMeetingMember CastModelToEntity(SocialForestryMeetingMemberVM model)
        {
            return _mapper.Map<SocialForestryMeetingMember>(model);
        }

        public override SocialForestryMeetingMemberVM CastEntityToModel(SocialForestryMeetingMember entity)
        {
            return _mapper.Map<SocialForestryMeetingMemberVM>(entity);
        }

        public override IList<SocialForestryMeetingMemberVM> CastEntityToModel(IQueryable<SocialForestryMeetingMember> entity)
        {
            return _mapper.Map<IList<SocialForestryMeetingMemberVM>>(entity).ToList();
        }
    }
}