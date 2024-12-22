using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.Services.AccountManagement;

namespace PTSL.GENERIC.Api.Controllers.AccountManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<IAccountService, AccountVM, Account>
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service) :
            base(service)
        {
            _service = service;
        }

        [HttpPost("GetByFilter")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<AccountVM>>>> GetByFilter([FromBody] AccountFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetByFilter(filter);

                return Ok(new WebApiResponse<PaginationResutl<AccountVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<PaginationResutl<AccountVM>>(
                        (ExecutionState.Failure, new PaginationResutl<AccountVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("GetByFilterBasic")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<AccountVM>>>> GetByFilterBasic([FromBody] AccountFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetByFilterBasic(filter);

                return Ok(new WebApiResponse<List<AccountVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<AccountVM>>(
                        (ExecutionState.Failure, new List<AccountVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("GetCurrentBalance/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<AccountCurrentBalanceVM>>> GetCurrentBalance([FromRoute] long id)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetCurrentBalance(id);

                return Ok(new WebApiResponse<AccountCurrentBalanceVM>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<AccountCurrentBalanceVM>(
                        (ExecutionState.Failure, null!, "Unexpected error occurred")
                    ));
            }
        }
    }
}