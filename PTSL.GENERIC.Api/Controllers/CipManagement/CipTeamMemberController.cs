using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.CipManagement;

namespace PTSL.GENERIC.Api.Controllers.CipManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CipTeamMemberController : BaseController<ICipTeamMemberService, CipTeamMemberVM, CipTeamMember>
    {
        public CipTeamMemberController(ICipTeamMemberService service) :
            base(service)
        {
        }
    }
}