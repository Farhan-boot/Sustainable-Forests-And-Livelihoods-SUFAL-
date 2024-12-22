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
    public class AccountTransferController : BaseController<IAccountTransferService, AccountTransferVM, AccountTransfer>
    {
        private readonly IAccountTransferService _service;

        public AccountTransferController(IAccountTransferService service) :
            base(service)
        {
            _service = service;
        }

        [HttpPost("Transfer/{permissionHeaderSettingsId}")]
        public async Task<ActionResult<WebApiResponse<AccountTransferVM>>> Transfer([FromBody] AccountTransferVM model, long permissionHeaderSettingsId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, entity, message) = await _service.Transfer(model, userId, permissionHeaderSettingsId);

                return Ok(new WebApiResponse<AccountTransferVM>(
                        (executionState, entity, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<AccountTransferVM>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("ListForCashIn")]
        public async Task<ActionResult<WebApiResponse<List<AccountTransferVM>>>> ListForCashIn()
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, entity, message) = await _service.ListForCashIn(userId);

                return Ok(new WebApiResponse<List<AccountTransferVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<List<AccountTransferVM>>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("AcceptTransfer/{accountTransferId}")]
        public async Task<ActionResult<WebApiResponse<AccountTransferVM>>> AcceptTransfer([FromRoute] long accountTransferId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, message) = await _service.AcceptTransfer(accountTransferId, userId);

                return Ok(new WebApiResponse<AccountTransferVM>(
                        (executionState, null, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<AccountTransferVM>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("CancelTransfer/{accountTransferId}")]
        public async Task<ActionResult<WebApiResponse<AccountTransferVM>>> CancelTransfer([FromRoute] long accountTransferId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, message) = await _service.CancelTransfer(accountTransferId, userId);

                return Ok(new WebApiResponse<AccountTransferVM>(
                        (executionState, null, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<AccountTransferVM>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("RollbackTransfer/{accountTransferId}")]
        public async Task<ActionResult<WebApiResponse<AccountTransferVM>>> RollbackTransfer([FromRoute] long accountTransferId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, message) = await _service.RollbackTransfer(accountTransferId, userId);

                return Ok(new WebApiResponse<AccountTransferVM>(
                        (executionState, null, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<AccountTransferVM>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("ModifyTransfer")]
        public async Task<ActionResult<WebApiResponse<AccountTransferVM>>> ModifyTransfer([FromBody] AccountTransferVM model)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, message) = await _service.ModifyTransfer(model, userId);

                return Ok(new WebApiResponse<AccountTransferVM>(
                        (executionState, null, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<AccountTransferVM>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("ListForRequestList/{permissionHeaderSettingsId}")]
        public async Task<ActionResult<WebApiResponse<List<AccountTransferVM>>>> ListForRequestList(long permissionHeaderSettingsId)
        {
            try
            {
                long userId = HttpContext.GetCurrentUserId();

                var (executionState, entity, message) = await _service.ListForRequestList(permissionHeaderSettingsId, userId);

                return Ok(new WebApiResponse<List<AccountTransferVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<List<AccountTransferVM>>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("ForwardApproval")]
        public async Task<ActionResult<WebApiResponse<string>>> ForwardApproval([FromBody] AccountForwardRequestVM request)
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


        [HttpPost("ListByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<AccountTransferVM>>>> ListByFilter([FromBody] ForestCivilLocationFilter filter)
        {
            try
            {
                var (executionState, entity, message) = await _service.ListByFilter(filter);

                return Ok(new WebApiResponse<List<AccountTransferVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<AccountTransferVM>>(
                        (ExecutionState.Failure, new List<AccountTransferVM>(), "Unexpected error occurred")
                    ));
            }
        }
    }
}