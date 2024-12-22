using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Service.Services.Beneficiary;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyDocumentController : BaseController<ISurveyDocumentService, SurveyDocumentVM, SurveyDocument>
    {
        public SurveyDocumentController(ISurveyDocumentService service) :
            base(service)
        {
        }
    }
}