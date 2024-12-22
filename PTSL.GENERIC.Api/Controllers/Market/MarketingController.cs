using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.Beneficiary;
using PTSL.GENERIC.Service.Services.Market;

namespace PTSL.GENERIC.Api.Controllers.Market
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketingController : BaseController<IMarketingService, MarketingVM, Marketing>
    {
        public MarketingController(IMarketingService service) :
            base(service)
        { }

        //Implement here new api, if we want.
    }
}
