using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.AccountManagement;

namespace PTSL.GENERIC.Api.Controllers.AccountManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsUserTagLogController : BaseController<IAccountsUserTagLogService, AccountsUserTagLogVM, AccountsUserTagLog>
    {
        private readonly IAccountsUserTagLogService _service;
        public AccountsUserTagLogController(IAccountsUserTagLogService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetAccountsUserTagLogsByAccountId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<AccountsUserTagLogVM>>>> GetAccountsUserTagLogsByAccountId(long accountId)
        {
            (ExecutionState executionState, List<AccountsUserTagLogVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<AccountsUserTagLogVM> entity, string message) result = await _service.GetAccountsUserTagLogsByAccountId(accountId);
                //if (result.executionState == ExecutionState.Retrieved)
                //{
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<AccountsUserTagLogVM>>(responseResult);
                    return Ok(apiResponse);
                //}
                //else
                //{
                    //responseResult.entity = null;
                   // responseResult.executionState = result.executionState;
                   // responseResult.message = result.message;
                   // var apiResponse = new WebApiResponse<List<AccountsUserTagLogVM>>(responseResult);
                   // return NotFound(apiResponse);
                //}
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<AccountsUserTagLogVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }


    }
}