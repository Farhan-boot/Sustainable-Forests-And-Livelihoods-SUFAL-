using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.Services.AIG;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualGroupFormSetupController : BaseController<IIndividualGroupFormSetupService, IndividualGroupFormSetupVM, IndividualGroupFormSetup>
    {
        public IndividualGroupFormSetupController(IIndividualGroupFormSetupService service) :
            base(service)
        { }
    }
}
