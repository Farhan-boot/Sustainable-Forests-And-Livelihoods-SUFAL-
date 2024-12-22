using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Service.Services.TransactionMangement;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class FundTypeController : BaseController<IFundTypeService, FundTypeVM, FundType>
{
    public FundTypeController(IFundTypeService service) :
        base(service)
    { }

    // Implement new api, if you want.
}
