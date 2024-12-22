using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.Services.AccountManagement;

namespace PTSL.GENERIC.Api.Controllers.AccountManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTransferLogController : BaseController<IAccountTransferLogService, AccountTransferLogVM, AccountTransferLog>
    {
        public AccountTransferLogController(IAccountTransferLogService service) :
            base(service)
        {
        }
    }
}