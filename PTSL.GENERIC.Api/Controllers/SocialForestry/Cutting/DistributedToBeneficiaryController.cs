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
    public class DistributedToBeneficiaryController : BaseController<IDistributedToBeneficiaryService, DistributedToBeneficiaryVM, DistributedToBeneficiary>
    {
        public DistributedToBeneficiaryController(IDistributedToBeneficiaryService service) :
            base(service)
        {
        }
    }
}