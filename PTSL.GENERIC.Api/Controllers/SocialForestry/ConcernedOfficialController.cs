using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestry;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConcernedOfficialController : BaseController<IConcernedOfficialService, ConcernedOfficialVM, ConcernedOfficial>
    {
        public ConcernedOfficialController(IConcernedOfficialService service) :
            base(service)
        {
        }
    }
}