using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.Services.Interface;

namespace PTSL.GENERIC.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : BaseController<IMeetingService, MeetingVM, Meeting>
    {
        private readonly IMeetingService _service;
        private readonly IMeetingBusiness _business;

        public MeetingController(IMeetingService service, IMeetingBusiness business) :
            base(service)
        {
            _service = service;
            _business = business;
        }

        [HttpPost("GetMeetingByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<MeetingVM>>>> GetMeetingByFilter(MeetingFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<MeetingVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<MeetingVM> entity, string message) result = await _service.GetMeetingByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<MeetingVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<MeetingVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<PaginationResutl<MeetingVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("DeleteParticipant/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult> DeleteParticipant(long id)
        {
            (ExecutionState executionState, bool isDeleted, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, bool isDeleted, string message) result = await _service.DeleteParticipant(id);

                responseResult.isDeleted = result.isDeleted;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                WebApiResponse<bool> apiResponse = new WebApiResponse<bool>(responseResult);

                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                responseResult.isDeleted = false;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<bool> apiResponse = new WebApiResponse<bool>(responseResult);

                return StatusCode(500, apiResponse);
            }
        }

    }
}
