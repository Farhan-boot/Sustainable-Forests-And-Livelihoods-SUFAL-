using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.Services.AccountManagement;

namespace PTSL.GENERIC.Api.Controllers.AccountManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDepositController : BaseController<IAccountDepositService, AccountDepositVM, AccountDeposit>
    {
        private readonly IAccountDepositService _service;

        public AccountDepositController(IAccountDepositService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetDetails/{id}")]
        public async Task<ActionResult<WebApiResponse<AccountDepositVM>>> GetDetails([FromRoute] long id)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetDetailsAsync(id);

                return Ok(new WebApiResponse<AccountDepositVM>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<AccountDepositVM>(
                        (ExecutionState.Failure, null, ex.Message)
                    ));
            }
        }

        [HttpPost("Create/{permissionHeaderSettingsId}")]
        public async Task<ActionResult<WebApiResponse<AccountDepositVM>>> CreateAsync([FromBody] AccountDepositVM model, long permissionHeaderSettingsId)
        {
            try
            {
                var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
                _ = long.TryParse(userIdJwt, out var userId);

                model.CreatedBy = userId;
                model.CreatedAt = DateTime.Now;

                var (executionState, entity, message) = await _service.CreateAsync(model, userId, permissionHeaderSettingsId);

                return Ok(new WebApiResponse<AccountDepositVM>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<AccountDepositVM>(
                        (ExecutionState.Failure, null, ex.Message)
                    ));
            }
        }

        [HttpGet("ListForCashIn")]
        public async Task<ActionResult<WebApiResponse<List<AccountDepositVM>>>> ListForCashIn()
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, entity, message) = await _service.ListForCashIn(userId);

                return Ok(new WebApiResponse<List<AccountDepositVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<List<AccountDepositVM>>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("ListForRequestList/{permissionHeaderSettingsId}")]
        public async Task<ActionResult<WebApiResponse<List<AccountDepositVM>>>> ListForRequestList(long permissionHeaderSettingsId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, entity, message) = await _service.ListForRequestList(permissionHeaderSettingsId, userId);

                return Ok(new WebApiResponse<List<AccountDepositVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<List<AccountDepositVM>>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("ForwardApproval")]
        public async Task<ActionResult<WebApiResponse<string>>> ForwardApproval([FromBody] AccountDepositForwardRequestVM request)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, message) = await _service.ForwardApproval(userId, request);

                return Ok(new WebApiResponse<string>(
                        (executionState, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<string>(
                        (ExecutionState.Failure, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("LastStageApproval/{accountTransferId}/{permissionHeaderSettingsId}")]
        public async Task<ActionResult<WebApiResponse<string>>> LastStageApproval(long accountTransferId, long permissionHeaderSettingsId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, message) = await _service.LastStageApproval(userId, accountTransferId, permissionHeaderSettingsId);

                return Ok(new WebApiResponse<string>(
                        (executionState, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<string>(
                        (ExecutionState.Failure, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("AcceptDeposit/{accountTransferId}")]
        public async Task<ActionResult<WebApiResponse<string>>> AcceptDeposit(long accountTransferId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, message) = await _service.AcceptDeposit(accountTransferId, userId);

                return Ok(new WebApiResponse<string>(
                        (executionState, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<string>(
                        (ExecutionState.Failure, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("CancelDeposit/{accountTransferId}")]
        public async Task<ActionResult<WebApiResponse<string>>> CancelDeposit(long accountTransferId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, message) = await _service.CancelDeposit(accountTransferId, userId);

                return Ok(new WebApiResponse<string>(
                        (executionState, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<string>(
                        (ExecutionState.Failure, "Unexpected error occurred")
                    ));
            }
        }




        //New filter add
        [HttpPost("ListByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<AccountDepositVM>>>> ListByFilter([FromBody] ForestCivilLocationFilter filter)
        {
            try
            {
                var (executionState, entity, message) = await _service.ListByFilter(filter);

                return Ok(new WebApiResponse<PaginationResutl<AccountDepositVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<PaginationResutl<AccountDepositVM>>(
                        (ExecutionState.Failure, new PaginationResutl<AccountDepositVM>(), "Unexpected error occurred")
                    ));
            }
        }



    }
}
