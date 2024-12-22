using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.NecessaryLinkManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.NecessaryLinkManagement;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.NecessaryLinkManagement;

namespace PTSL.GENERIC.Api.Controllers.NecessaryLinkManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NecessaryLinkController : BaseController<INecessaryLinkService, NecessaryLinkVM, NecessaryLink>
    {
        public NecessaryLinkController(INecessaryLinkService service) :
            base(service)
        {
        }
    }
}