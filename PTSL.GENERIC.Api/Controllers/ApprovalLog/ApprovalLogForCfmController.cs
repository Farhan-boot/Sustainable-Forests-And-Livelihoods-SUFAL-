using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.ApprovalLog;

namespace PTSL.GENERIC.Api.Controllers.ApprovalLog
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalLogForCfmController : BaseController<IApprovalLogForCfmService, ApprovalLogForCfmVM, ApprovalLogForCfm>
    {
        public ApprovalLogForCfmController(IApprovalLogForCfmService service) :
            base(service)
        {
        }
    }
}