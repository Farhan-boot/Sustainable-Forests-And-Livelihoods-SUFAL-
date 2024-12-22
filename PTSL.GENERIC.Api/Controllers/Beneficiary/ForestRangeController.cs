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
    public class ForestRangeController : BaseController<IForestRangeService, ForestRangeVM, ForestRange>
    {
        private readonly IForestRangeService _forestRangeService;

        public ForestRangeController(IForestRangeService service) :
            base(service)
        {
            _forestRangeService = service;
        }

        [HttpGet("ListByForestDivision/{forestDivisionId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ForestRangeVM>>> ListByForestDivision([FromRoute] long forestDivisionId)
        {
            (ExecutionState executionState, IList<ForestRangeVM> entity, string message) result = await _forestRangeService.ListByForestDivision(forestDivisionId);
            (ExecutionState executionState, IList<ForestRangeVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestRangeVM>> apiResponse = new WebApiResponse<IList<ForestRangeVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestRangeVM>> apiResponse = new WebApiResponse<IList<ForestRangeVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
