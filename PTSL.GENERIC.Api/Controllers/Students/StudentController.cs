using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Students;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Students;
using PTSL.GENERIC.Service.Services.Beneficiary;
using PTSL.GENERIC.Service.Services.Market;
using PTSL.GENERIC.Service.Services.Students;

namespace PTSL.GENERIC.Api.Controllers.Students
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController<IStudentService, StudentVM, Student>
    {
        public StudentController(IStudentService service) :
            base(service)
        { }

        //Implement here new api, if we want.
    }
}
