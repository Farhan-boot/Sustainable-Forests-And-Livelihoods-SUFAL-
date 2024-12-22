using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.Beneficiary;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DisabilityTypeHouseholdMembersMapController : BaseController<IDisabilityTypeHouseholdMembersMapService, DisabilityTypeHouseholdMembersMapVM, DisabilityTypeHouseholdMembersMap>
    {
        public DisabilityTypeHouseholdMembersMapController(IDisabilityTypeHouseholdMembersMapService service) :
            base(service)
        { }

        //Implement here new api, if we want.
    }
}
