using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityTrainingController : BaseController<ICommunityTrainingService, CommunityTrainingVM, CommunityTraining>
    {
        private readonly ICommunityTrainingService _service;
        private readonly ICommunityTrainingParticipentsMapService _communityTrainingParticipentsMapService;

        public CommunityTrainingController(ICommunityTrainingService service, ICommunityTrainingParticipentsMapService communityTrainingParticipentsMap) :
            base(service)
        {
            _service = service;
            _communityTrainingParticipentsMapService = communityTrainingParticipentsMap;
        }

        [HttpPost("GetTrainingByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<CommunityTrainingVM>>>> GetTrainingByFilter(CommunityTrainingFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<CommunityTrainingVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<CommunityTrainingVM> entity, string message) result = await _service.GetTrainingByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<CommunityTrainingVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null; ;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<CommunityTrainingVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<PaginationResutl<CommunityTrainingVM>>(responseResult);
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



        [HttpPost("GetCommunityTrainingParticipentsMapByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<CommunityTrainingParticipantsByBeneficiaryResultVM>>>> GetCommunityTrainingParticipentsMapByFilter(CommunityTrainingFilterByBeneficiaryVM filterData)
        {
            (ExecutionState executionState, IList<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message) responseResult;

            try
            {
                (ExecutionState executionState, IList<CommunityTrainingParticipantsByBeneficiaryResultVM> entity, string message) result = await _communityTrainingParticipentsMapService.GetCommunityTrainingParticipentsMapByFilter(filterData);

                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<IList<CommunityTrainingParticipantsByBeneficiaryResultVM>>(responseResult);
                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<CommunityTrainingParticipantsByBeneficiaryResultVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }
    }
}
