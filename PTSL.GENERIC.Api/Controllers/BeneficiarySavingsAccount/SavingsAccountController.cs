using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.Services.Beneficiary;
using PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount;

namespace PTSL.GENERIC.Api.Controllers.BeneficiarySavingsAccount
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsAccountController : BaseController<ISavingsAccountService, SavingsAccountVM, SavingsAccount>
    {
        private readonly ISavingsAccountService _service;

        public SavingsAccountController(ISavingsAccountService service) :
            base(service)
        {
            _service = service;
        }

        //Implement here new api, if we want.
        [HttpPost("GetByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<SavingsAccountVM>>>> GetByFilter(SavingsAccountFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<SavingsAccountVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<SavingsAccountVM> entity, string message) result = await _service.GetByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<SavingsAccountVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<SavingsAccountVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<PaginationResutl<SavingsAccountVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }
    }
}
