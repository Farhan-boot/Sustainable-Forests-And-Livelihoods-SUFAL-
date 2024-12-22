using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Service.Services.SocialForestry.Nursery;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Nursery
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NurseryTypeController : BaseController<INurseryTypeService, NurseryTypeVM, NurseryType>
    {
        public NurseryTypeController(INurseryTypeService service) :
            base(service)
        {
        }
    }
}