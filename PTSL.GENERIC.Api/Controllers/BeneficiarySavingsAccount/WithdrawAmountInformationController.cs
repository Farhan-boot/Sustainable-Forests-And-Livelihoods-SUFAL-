using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.Services.Beneficiary;
using PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount;

namespace PTSL.GENERIC.Api.Controllers.BeneficiarySavingsAccount
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawAmountInformationController : BaseController<IWithdrawAmountInformationService, WithdrawAmountInformationVM, WithdrawAmountInformation>
    {
        public WithdrawAmountInformationController(IWithdrawAmountInformationService service) :
            base(service)
        { }

        //Implement here new api, if we want.
    }
}
