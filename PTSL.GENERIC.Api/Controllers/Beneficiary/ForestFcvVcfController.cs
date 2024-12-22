using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.Beneficiary;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ForestFcvVcfController : BaseController<IForestFcvVcfService, ForestFcvVcfVM, ForestFcvVcf>
    {
        private readonly IForestFcvVcfService _forestFcvVcfService;
        private readonly IForestFcvVcfBusiness _business;
        public ForestFcvVcfController(IForestFcvVcfService forestFcvVcfService, IForestFcvVcfBusiness business) :
            base(forestFcvVcfService)
        {
            _forestFcvVcfService = forestFcvVcfService;
            _business = business;
        }

        //Implement here new api, if we want.

        [HttpGet("ListByForestBeat/{ForestBeatId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ForestFcvVcfVM>>> ListByForestBeat([FromRoute] long ForestBeatId)
        {
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) result = await _forestFcvVcfService.ListByForestBeat(ForestBeatId);
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestFcvVcfVM>> apiResponse = new WebApiResponse<IList<ForestFcvVcfVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestFcvVcfVM>> apiResponse = new WebApiResponse<IList<ForestFcvVcfVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("GetListOfFcvVcfByType/{isFcv}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ForestFcvVcfVM>>> GetFcvVcfByType(bool isFcv)
        {
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) result = await _forestFcvVcfService.GetFcvVcfByType(isFcv);
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestFcvVcfVM>> apiResponse = new WebApiResponse<IList<ForestFcvVcfVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestFcvVcfVM>> apiResponse = new WebApiResponse<IList<ForestFcvVcfVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("ListByForestBeatAndType")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ForestFcvVcfVM>>> ListByForestBeatAndType([FromQuery]long forestBeatId, [FromQuery]FcvVcfType type)
        {
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) result = await _forestFcvVcfService.ListByForestBeatAndType(forestBeatId, type);
            (ExecutionState executionState, IList<ForestFcvVcfVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestFcvVcfVM>> apiResponse = new WebApiResponse<IList<ForestFcvVcfVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<ForestFcvVcfVM>> apiResponse = new WebApiResponse<IList<ForestFcvVcfVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }


        [HttpPost("MemberPerVillage")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<MemberPerVillageVM>>>> MemberPerVillage([FromBody] MemberPerVillageFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.MemberPerVillage(filter);

                return Ok(new WebApiResponse<List<MemberPerVillageVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<MemberPerVillageVM>>(
                        (ExecutionState.Failure, new List<MemberPerVillageVM>(), "Unexpected error occurred")
                    ));
            }
        }




    }
}
