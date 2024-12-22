using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.AIG;
using PTSL.GENERIC.Service.Services.InternalLoan;

namespace PTSL.GENERIC.Api.Controllers.InternalLoan
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InternalLoanInformationController : BaseController<IInternalLoanInformationService, InternalLoanInformationVM, InternalLoanInformation>
    {
        private readonly IInternalLoanInformationService _service;

        public InternalLoanInformationController(IInternalLoanInformationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetInternalLoanAvailableAmount/{fcvVcfId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<InternalLoanAvailableAmountVM>>> GetInternalLoanAvailableAmount(long fcvVcfId)
        {
            (ExecutionState executionState, InternalLoanAvailableAmountVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, InternalLoanAvailableAmountVM entity, string message) result = await _service.GetInternalLoanAvailableAmount(fcvVcfId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<InternalLoanAvailableAmountVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<InternalLoanAvailableAmountVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<InternalLoanAvailableAmountVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }






        [HttpPost("GetInternalLoanInformationByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<InternalLoanInformationVM>>>> GetAIGByFilter(AIGBasicInformationFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<InternalLoanInformationVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<InternalLoanInformationVM> entity, string message) result = await _service.GetInternalLoanInformationByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<PaginationResutl<InternalLoanInformationVM>> apiResponse = new WebApiResponse<PaginationResutl<InternalLoanInformationVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<PaginationResutl<InternalLoanInformationVM>> apiResponse = new WebApiResponse<PaginationResutl<InternalLoanInformationVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<PaginationResutl<InternalLoanInformationVM>> apiResponse = new WebApiResponse<PaginationResutl<InternalLoanInformationVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }
    }
}
