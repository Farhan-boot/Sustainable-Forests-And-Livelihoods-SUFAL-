using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.Services.AIG;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupLDFInfoFormController : BaseController<IGroupLDFInfoFormService, GroupLDFInfoFormVM, GroupLDFInfoForm>
    {
        private readonly IGroupLDFInfoFormService _service;

        public GroupLDFInfoFormController(IGroupLDFInfoFormService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetDetails/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<GroupLDFInfoFormVM>>> GetDetails(long id, bool includeAll = false)
        {
            (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
                _ = long.TryParse(userIdJwt, out var userId);

                (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) result = await _service.GetDetails(id, includeAll);
                if (result.executionState == ExecutionState.Failure)
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<GroupLDFInfoFormVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<GroupLDFInfoFormVM>(responseResult);
                    return Ok(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<GroupLDFInfoFormVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("ListByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<GroupLDFInfoFormVM>>>> ListByFilter(GroupLDFInfoFormFilterVM filter)
        {
            (ExecutionState executionState, List<GroupLDFInfoFormVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<GroupLDFInfoFormVM> entity, string message) result = await _service.ListByFilter(filter);

                if (result.executionState == ExecutionState.Failure)
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<GroupLDFInfoFormVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<GroupLDFInfoFormVM>>(responseResult);
                    return Ok(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<GroupLDFInfoFormVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }
    }
}
