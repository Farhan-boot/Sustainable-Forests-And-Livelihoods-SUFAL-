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
    public class MeetingTypeForSocialForestryMeetingService : BaseService<MeetingTypeForSocialForestryMeetingVM, MeetingTypeForSocialForestryMeeting>, IMeetingTypeForSocialForestryMeetingService
    {
        public IMapper _mapper;

        public MeetingTypeForSocialForestryMeetingService(IMeetingTypeForSocialForestryMeetingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override MeetingTypeForSocialForestryMeeting CastModelToEntity(MeetingTypeForSocialForestryMeetingVM model)
        {
            return _mapper.Map<MeetingTypeForSocialForestryMeeting>(model);
        }

        public override MeetingTypeForSocialForestryMeetingVM CastEntityToModel(MeetingTypeForSocialForestryMeeting entity)
        {
            return _mapper.Map<MeetingTypeForSocialForestryMeetingVM>(entity);
        }

        public override IList<MeetingTypeForSocialForestryMeetingVM> CastEntityToModel(IQueryable<MeetingTypeForSocialForestryMeeting> entity)
        {
            return _mapper.Map<IList<MeetingTypeForSocialForestryMeetingVM>>(entity).ToList();
        }
    }
}