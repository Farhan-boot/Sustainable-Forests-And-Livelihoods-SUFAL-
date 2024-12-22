using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Service.Services.Interface;

namespace PTSL.GENERIC.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingParticipantsMapController : BaseController<IMeetingParticipantsMapService, MeetingParticipantsMapVM, MeetingParticipantsMap>
    {
        public MeetingParticipantsMapController(IMeetingParticipantsMapService service) :
            base(service)
        { }
    }
}
