using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UnionController : BaseController<IUnionService, UnionVM, Union>
    {
        private IUnionService _UnionService { get; }

        public UnionController(IUnionService service) :
            base(service)
        {
            _UnionService = service;
        }

        [HttpGet("ListByUpazilla/{UpazillaId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<UnionVM>>> ListByUpazilla([FromRoute] long UpazillaId)
        {
            (ExecutionState executionState, IList<UnionVM> entity, string message) result = await _UnionService.ListByUpazilla(UpazillaId);
            (ExecutionState executionState, IList<UnionVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<UnionVM>> apiResponse = new WebApiResponse<IList<UnionVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<UnionVM>> apiResponse = new WebApiResponse<IList<UnionVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPost("ListByMultipleUpazilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<UnionVM>>> ListByMultipleUpazilla([FromBody] List<long> upazillas)
        {
            (ExecutionState executionState, IList<UnionVM> entity, string message) result = await _UnionService.ListByMultipleUpazilla(upazillas);
            (ExecutionState executionState, IList<UnionVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<UnionVM>> apiResponse = new WebApiResponse<IList<UnionVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<UnionVM>> apiResponse = new WebApiResponse<IList<UnionVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
