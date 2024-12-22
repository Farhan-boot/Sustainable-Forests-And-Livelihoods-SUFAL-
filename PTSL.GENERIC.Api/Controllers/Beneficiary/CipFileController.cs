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
    public class CipFileController : BaseController<ICipFileService, CipFileVM, CipFile>
    {
        public CipFileController(ICipFileService service) :
            base(service)
        {
        }
    }
}