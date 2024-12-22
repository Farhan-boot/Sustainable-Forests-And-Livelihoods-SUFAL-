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
    public class  SocialForestryMeetingParticipentsMapService : BaseService< SocialForestryMeetingParticipentsMapVM,  SocialForestryMeetingParticipentsMap>, ISocialForestryMeetingParticipentsMapService
    {
        public IMapper _mapper;

        public  SocialForestryMeetingParticipentsMapService(ISocialForestryMeetingParticipentsMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override  SocialForestryMeetingParticipentsMap CastModelToEntity( SocialForestryMeetingParticipentsMapVM model)
        {
            return _mapper.Map<SocialForestryMeetingParticipentsMap>(model);
        }

        public override  SocialForestryMeetingParticipentsMapVM CastEntityToModel( SocialForestryMeetingParticipentsMap entity)
        {
            return _mapper.Map<SocialForestryMeetingParticipentsMapVM>(entity);
        }

        public override IList<SocialForestryMeetingParticipentsMapVM> CastEntityToModel(IQueryable< SocialForestryMeetingParticipentsMap> entity)
        {
            return _mapper.Map<IList<SocialForestryMeetingParticipentsMapVM>>(entity).ToList();
        }
    }
}