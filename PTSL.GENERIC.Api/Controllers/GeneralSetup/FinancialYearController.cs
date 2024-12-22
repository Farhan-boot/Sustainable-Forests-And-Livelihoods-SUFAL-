using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.Services.GeneralSetup;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FinancialYearController : BaseController<IFinancialYearService, FinancialYearVM, FinancialYear>
{
    public FinancialYearController(IFinancialYearService service) :
        base(service)
    { }

    // Implement new api, if you want.
}
