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
    public class UpazillaController : BaseController<IUpazillaService, UpazillaVM, Upazilla>
    {
        private IUpazillaService _upazillaService { get; }

        public UpazillaController(IUpazillaService service) :
            base(service)
        {
            _upazillaService = service;
        }

        [HttpGet("ListByDistrict/{districtId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<UpazillaVM>>> ListByDistrict([FromRoute] long districtId)
        {
            (ExecutionState executionState, IList<UpazillaVM> entity, string message) result = await _upazillaService.ListByDistrict(districtId);
            (ExecutionState executionState, IList<UpazillaVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<UpazillaVM>> apiResponse = new WebApiResponse<IList<UpazillaVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<UpazillaVM>> apiResponse = new WebApiResponse<IList<UpazillaVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
