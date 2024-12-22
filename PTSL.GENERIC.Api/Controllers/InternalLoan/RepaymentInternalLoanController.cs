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
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.AIG;
using PTSL.GENERIC.Service.Services.InternalLoan;

namespace PTSL.GENERIC.Api.Controllers.InternalLoan
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepaymentInternalLoanController : BaseController<IRepaymentInternalLoanService, RepaymentInternalLoanVM, RepaymentInternalLoan>
    {
        private readonly IRepaymentInternalLoanService _service;

        public RepaymentInternalLoanController(IRepaymentInternalLoanService service) :
            base(service)
        {
            _service = service;
        }


        [HttpGet("CompletePayment/{repaymentId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<RepaymentInternalLoanVM>>> CompletePayment(long repaymentId)
        {
            (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
                _ = long.TryParse(userIdJwt, out var userId);

                (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) result = await _service.CompletePayment(repaymentId, userId);
                if (result.executionState == ExecutionState.Failure)
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<RepaymentInternalLoanVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<RepaymentInternalLoanVM>(responseResult);
                    return Ok(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<RepaymentInternalLoanVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

    }
}
