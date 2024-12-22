using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Service.Services.Beneficiary;
using PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.Services.Patrolling;

namespace PTSL.GENERIC.Api.Controllers.Patrolling
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OtherPatrollingMemberController : BaseController<IOtherPatrollingMemberService, OtherPatrollingMemberVM, OtherPatrollingMember>
    {
        public OtherPatrollingMemberController(IOtherPatrollingMemberService service) :
            base(service)
        { }

        //Implement here new api, if we want.
    }
}
