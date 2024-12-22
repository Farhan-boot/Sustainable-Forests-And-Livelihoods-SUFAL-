using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.ForestManagement;

namespace PTSL.GENERIC.Api.Controllers.ForestManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommitteeManagementMemberController : BaseController<ICommitteeManagementMemberService, CommitteeManagementMemberVM, CommitteeManagementMember>
    {
        public CommitteeManagementMemberController(ICommitteeManagementMemberService service) :
            base(service)
        {
        }
    }
}