using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.Beneficiary;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NgoController : BaseController<INgoService, NgoVM, Ngo>
    {
        private readonly INgoService _service;

        public NgoController(INgoService service) :
            base(service)
        {
            _service = service;
        }

        [HttpPost("ListByForestDivisions")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<NgoVM>>> ListByForestDivisions([FromBody] List<long> divisions)
        {
            (ExecutionState executionState, IList<NgoVM> entity, string message) responseResult;
            (ExecutionState executionState, IList<NgoVM> entity, string message) result = await _service.ListByForestDivisions(divisions);

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                var apiResponse = new WebApiResponse<IList<NgoVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                var apiResponse = new WebApiResponse<IList<NgoVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
