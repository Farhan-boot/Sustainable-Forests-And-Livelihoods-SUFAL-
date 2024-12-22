using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Service.Services.AIG;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecondFourtyPercentageLDFController : BaseController<ISecondFourtyPercentageLDFService, SecondFourtyPercentageLDFVM, SecondFourtyPercentageLDF>
    {
        public SecondFourtyPercentageLDFController(ISecondFourtyPercentageLDFService service) :
            base(service)
        { }
    }
}
