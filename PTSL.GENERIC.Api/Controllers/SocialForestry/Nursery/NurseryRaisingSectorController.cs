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
    public class NurseryRaisingSectorController : BaseController<INurseryRaisingSectorService, NurseryRaisingSectorVM, NurseryRaisingSector>
    {
        public NurseryRaisingSectorController(INurseryRaisingSectorService service) :
            base(service)
        {
        }
    }
}