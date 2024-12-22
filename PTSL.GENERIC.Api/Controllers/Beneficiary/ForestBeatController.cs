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
    public class ForestBeatController : BaseController<IForestBeatService, ForestBeatVM, ForestBeat>
    {
        private readonly IForestBeatService _forestBeatService;

        public ForestBeatController(IForestBeatService service) :
            base(service)
        {
            this._forestBeatService=service;
        }

        [HttpGet("ListByForestRange/{forestRangeId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ForestBeatVM>>> ListByForestRange([FromRoute] long forestRangeId)
        {
            (ExecutionState executionState, IList<ForestBeatVM> entity, string message) result = await _forestBeatService.ListByForestRange(forestRangeId);
            (ExecutionState executionState, IList<ForestBeatVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestBeatVM>> apiResponse = new WebApiResponse<IList<ForestBeatVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestBeatVM>> apiResponse = new WebApiResponse<IList<ForestBeatVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
