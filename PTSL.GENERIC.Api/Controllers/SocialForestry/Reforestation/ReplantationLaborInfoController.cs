using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.Services.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Reforestation
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplantationLaborInfoController : BaseController<IReplantationLaborInfoService, ReplantationLaborInfoVM, ReplantationLaborInfo>
    {
        public ReplantationLaborInfoController(IReplantationLaborInfoService service) :
            base(service)
        {
        }
    }
}