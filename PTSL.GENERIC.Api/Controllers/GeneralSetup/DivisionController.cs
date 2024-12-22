using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : BaseController<IDivisionService, DivisionVM, Division>
    {
        private IDivisionService _DivisionService { get; }
        //private readonly IEmployeeInformationService _EmployeeInformationService;
        public DivisionController(IDivisionService DivisionService) :
            base(DivisionService)
        {
            //_DivisionService = DivisionService;
        }

        //public DivisionController(IDivisionService Divisionervice) :
        //    base(Divisionervice)
        //{ }

        //[HttpGet("{id}")]
        ////[Authorize]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<WebApiResponse<DivisionVM>>> GetAsync(long id)
        //{ 
        //    (ExecutionState executionState, DivisionVM entity, string message) result = await _DivisionService.GetAsync(id);

        //    WebApiResponse<DivisionVM> apiResponse = new WebApiResponse<DivisionVM>(result);

        //    if (result.executionState == ExecutionState.Failure)
        //    {
        //        return NotFound(apiResponse);
        //    }
        //    else
        //    {
        //        return Ok(apiResponse);
        //    }
        //}

        //Implement here new api, if we want.
    }
}
