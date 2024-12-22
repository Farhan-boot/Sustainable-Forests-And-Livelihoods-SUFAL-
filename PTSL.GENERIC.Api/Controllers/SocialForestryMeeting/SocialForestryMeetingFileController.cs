using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestryMeeting;

namespace PTSL.GENERIC.Api.Controllers.SocialForestryMeeting
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialForestryMeetingFileController : BaseController<ISocialForestryMeetingFileService, SocialForestryMeetingFileVM, SocialForestryMeetingFile>
    {
        public SocialForestryMeetingFileController(ISocialForestryMeetingFileService service) :
            base(service)
        {
        }
    }
}