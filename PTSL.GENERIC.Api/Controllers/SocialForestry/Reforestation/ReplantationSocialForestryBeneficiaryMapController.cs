using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.Services.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Reforestation
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplantationSocialForestryBeneficiaryMapController : BaseController<IReplantationSocialForestryBeneficiaryMapService, ReplantationSocialForestryBeneficiaryMapVM, ReplantationSocialForestryBeneficiaryMap>
    {
        public ReplantationSocialForestryBeneficiaryMapController(IReplantationSocialForestryBeneficiaryMapService service) :
            base(service)
        {
        }
    }
}