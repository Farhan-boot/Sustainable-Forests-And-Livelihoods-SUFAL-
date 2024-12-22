using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Service.Services.AIG;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupLDFInfoFormMemberController : BaseController<IGroupLDFInfoFormMemberService, GroupLDFInfoFormMemberVM, GroupLDFInfoFormMember>
    {
        public GroupLDFInfoFormMemberController(IGroupLDFInfoFormMemberService service) :
            base(service)
        {
        }
    }
}
