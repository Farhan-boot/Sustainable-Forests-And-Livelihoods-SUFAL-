using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.Beneficiary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ForestDivisionController : BaseController<IForestDivisionService, ForestDivisionVM, ForestDivision>
    {
        private readonly IForestDivisionService _forestDivisionService;

        public ForestDivisionController(IForestDivisionService service) : base(service)
        {
            _forestDivisionService = service;
        }

        [HttpGet("ListByForestCircle/{forestCircleId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ForestDivisionVM>>> ListByForestCircle([FromRoute] long forestCircleId)
        {
            (ExecutionState executionState, IList<ForestDivisionVM> entity, string message) result = await _forestDivisionService.ListByForestCircle(forestCircleId);
            (ExecutionState executionState, IList<ForestDivisionVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestDivisionVM>> apiResponse = new WebApiResponse<IList<ForestDivisionVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestDivisionVM>> apiResponse = new WebApiResponse<IList<ForestDivisionVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPost("ListByMultipleForestCircle")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ForestDivisionVM>>> ListByMultipleForestCircle([FromBody] List<long> forestCircleIds)
        {
            (ExecutionState executionState, IList<ForestDivisionVM> entity, string message) result = await _forestDivisionService.ListByMultipleForestCircle(forestCircleIds);
            (ExecutionState executionState, IList<ForestDivisionVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestDivisionVM>> apiResponse = new WebApiResponse<IList<ForestDivisionVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestDivisionVM>> apiResponse = new WebApiResponse<IList<ForestDivisionVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
