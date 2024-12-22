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
    public class DistrictController : BaseController<IDistrictService, DistrictVM, District>
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService Districtervice) :
            base(Districtervice)
        {
            _districtService = Districtervice;
        }

        //Implement here new api, if we want.

        [HttpGet("ListByDivision/{DivisionId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<DistrictVM>>> ListByDivision([FromRoute] long DivisionId)
        {
            (ExecutionState executionState, IList<DistrictVM> entity, string message) result = await _districtService.ListByDivision(DivisionId);
            (ExecutionState executionState, IList<DistrictVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<DistrictVM>> apiResponse = new WebApiResponse<IList<DistrictVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<DistrictVM>> apiResponse = new WebApiResponse<IList<DistrictVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
