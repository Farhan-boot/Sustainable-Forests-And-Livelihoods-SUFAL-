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
    public class  SocialForestryMeetingFileService : BaseService<SocialForestryMeetingFileVM,  SocialForestryMeetingFile>, ISocialForestryMeetingFileService
    {
        public IMapper _mapper;

        public  SocialForestryMeetingFileService(ISocialForestryMeetingFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override  SocialForestryMeetingFile CastModelToEntity( SocialForestryMeetingFileVM model)
        {
            return _mapper.Map<SocialForestryMeetingFile>(model);
        }

        public override  SocialForestryMeetingFileVM CastEntityToModel( SocialForestryMeetingFile entity)
        {
            return _mapper.Map<SocialForestryMeetingFileVM>(entity);
        }

        public override IList<SocialForestryMeetingFileVM> CastEntityToModel(IQueryable< SocialForestryMeetingFile> entity)
        {
            return _mapper.Map<IList< SocialForestryMeetingFileVM>>(entity).ToList();
        }
    }
}