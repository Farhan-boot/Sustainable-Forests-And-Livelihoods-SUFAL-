using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.Services.Interface.Labour;

namespace PTSL.GENERIC.Api.Controllers.Labour
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OtherLabourMemberController : BaseController<IOtherLabourMemberService, OtherLabourMemberVM, OtherLabourMember>
    {
        public OtherLabourMemberController(IOtherLabourMemberService service) :
            base(service)
        {
        }
    }
}
