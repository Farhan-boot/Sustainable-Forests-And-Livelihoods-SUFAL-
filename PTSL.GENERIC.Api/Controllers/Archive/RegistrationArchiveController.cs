using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.Archive;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.Archive;

namespace PTSL.GENERIC.Api.Controllers.Archive
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationArchiveController : BaseController<IRegistrationArchiveService, RegistrationArchiveVM, RegistrationArchive>
    {
        private readonly IRegistrationArchiveService _service;
        public RegistrationArchiveController(IRegistrationArchiveService service) :
            base(service)
        {
            _service = service;
        }


        [HttpPost("GetRegistrationArchiveByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<RegistrationArchiveVM>>>> GetRegistrationArchiveByFilter(MeetingFilterVM filterData)
        {
            (ExecutionState executionState, List<RegistrationArchiveVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<RegistrationArchiveVM> entity, string message) result = await _service.GetRegistrationArchiveByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<RegistrationArchiveVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<RegistrationArchiveVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<RegistrationArchiveVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }


    }
}