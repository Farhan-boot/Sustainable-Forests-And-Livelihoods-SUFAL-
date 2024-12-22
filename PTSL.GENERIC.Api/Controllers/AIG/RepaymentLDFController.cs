using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Service.Services.AIG;
using System;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Api.Helpers.Authorize;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepaymentLDFController : BaseController<IRepaymentLDFService, RepaymentLDFVM, RepaymentLDF>
    {
        private readonly IRepaymentLDFService _service;
        private readonly IRepaymentLDFBusiness _business;

        public RepaymentLDFController(IRepaymentLDFService service, IRepaymentLDFBusiness business) :
            base(service)
        {
            _service = service;
            _business = business;
        }

        [HttpGet("GetListByFirstLDFId/{ldfId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<RepaymentLDFVM>>>> GetListByFirstLDFId(long ldfId)
        {
            (ExecutionState executionState, IList<RepaymentLDFVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<RepaymentLDFVM> entity, string message) result = await _service.GetListByFirstLDFId(ldfId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("GetListBySecondLDFId/{ldfId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<RepaymentLDFVM>>>> GetListBySecondLDFId(long ldfId)
        {
            (ExecutionState executionState, IList<RepaymentLDFVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<RepaymentLDFVM> entity, string message) result = await _service.GetListBySecondLDFId(ldfId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("GetListByAIGId/{ldfId}")]
        [Authorize(Policy = AIGRepaymentGetListByAIGIdPermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<RepaymentLDFVM>>>> GetListByAIGId(long ldfId)
        {
            (ExecutionState executionState, IList<RepaymentLDFVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<RepaymentLDFVM> entity, string message) result = await _service.GetListByAIGId(ldfId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("CompletePayment")]
        [Authorize(Policy = AIGRepaymentCompletePaymentPermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<RepaymentLDFVM>>> CompletePayment(CompleteRepaymentVM completeRepayment)
        {
            (ExecutionState executionState, RepaymentLDFVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
                _ = long.TryParse(userIdJwt, out var userId);

                (ExecutionState executionState, RepaymentLDFVM entity, string message) result = await _service.CompletePayment(completeRepayment, userId);
                if (result.executionState == ExecutionState.Failure)
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<RepaymentLDFVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<RepaymentLDFVM>(responseResult);
                    return Ok(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<RepaymentLDFVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("RemovePayment/{repaymentId}")]
        [Authorize(Policy = AIGRepaymentRemovePaymentPermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<RepaymentLDFVM>>> RemovePayment(long repaymentId)
        {
            (ExecutionState executionState, RepaymentLDFVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
                _ = long.TryParse(userIdJwt, out var userId);

                (ExecutionState executionState, RepaymentLDFVM entity, string message) result = await _service.RemovePayment(repaymentId, userId);

                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<RepaymentLDFVM>(responseResult);

                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<RepaymentLDFVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LockUnlockPayment/{repaymentId}")]
        [Authorize(Policy = AIGRepaymentLockUnlockPaymentPermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<RepaymentLDFVM>>> LockUnlockPayment([FromRoute] long repaymentId, [FromQuery] bool shouldLock)
        {
            (ExecutionState executionState, RepaymentLDFVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
                _ = long.TryParse(userIdJwt, out var userId);

                if (userId < 1)
                {
                    return Unauthorized();
                }

                (ExecutionState executionState, RepaymentLDFVM entity, string message) result = await _service.LockUnlockPayment(repaymentId, userId, shouldLock);

                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<RepaymentLDFVM>(responseResult);

                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<RepaymentLDFVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("GetListWithProgress/{aigId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<RepaymentLDFVM>>>> GetListWithProgress(long aigId)
        {
            (ExecutionState executionState, IList<RepaymentLDFVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<RepaymentLDFVM> entity, string message) result = await _service.GetListWithProgress(aigId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<RepaymentLDFVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("ListHistory/{repaymentId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<RepaymentLDFHistoryVM>>>> ListHistory(long repaymentId)
        {
            (ExecutionState executionState, IList<RepaymentLDFHistoryVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<RepaymentLDFHistoryVM> entity, string message) result = await _service.ListHistory(repaymentId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFHistoryVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<RepaymentLDFHistoryVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<RepaymentLDFHistoryVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("OutstandingLoanPerBorrowerList")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<RepaymentLDFOutstandingLoanPerBorrowerVM>>>> OutstandingLoanPerBorrowerList([FromBody] RepaymentLDFOutstandingLoanPerBorrowerFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.OutstandingLoanPerBorrowerFilter(filter);

                return Ok(new WebApiResponse<List<RepaymentLDFOutstandingLoanPerBorrowerVM>>(
                        (executionState, entity, message)
                    ));

            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<RepaymentLDFOutstandingLoanPerBorrowerVM>>(
                        (ExecutionState.Failure, new List<RepaymentLDFOutstandingLoanPerBorrowerVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("DateWiseRepaymentReport")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<DateWiseRepaymentReportVM>>>> DateWiseRepaymentReport(DateWiseRepaymentReportFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.DateWiseRepaymentReport(filter);

                return Ok(new WebApiResponse<List<DateWiseRepaymentReportVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<DateWiseRepaymentReportVM>>(
                        (ExecutionState.Failure, new List<DateWiseRepaymentReportVM>(), "Unexpected error occurred")
                    ));
            }
        }
    }
}

public class AIGRepaymentGetListByAIGIdPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIGRepayment.GetListByAIGId";
    public string PermissionName => "AIGRepayment.GetListByAIGId";
    public string PermissionDetails => "Repayments by AIG";
}

public class AIGRepaymentCompletePaymentPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIGRepayment.CompletePayment";
    public string PermissionName => "AIGRepayment.CompletePayment";
    public string PermissionDetails => "Complete repayment";
}

public class AIGRepaymentRemovePaymentPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIGRepayment.RemovePayment";
    public string PermissionName => "AIGRepayment.RemovePayment";
    public string PermissionDetails => "Remove repayment";
}

public class AIGRepaymentLockUnlockPaymentPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIGRepayment.LockUnlock";
    public string PermissionName => "AIGRepayment.LockUnlock";
    public string PermissionDetails => "Lock/Unlock repayment";
}
