using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestry.Cutting;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Cutting
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionFundTypeController : BaseController<IDistributionFundTypeService, DistributionFundTypeVM, DistributionFundType>
    {
        public DistributionFundTypeController(IDistributionFundTypeService service) :
            base(service)
        {
        }
    }
}