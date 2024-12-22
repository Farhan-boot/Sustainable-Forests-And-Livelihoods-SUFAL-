using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestryMeeting;

namespace PTSL.GENERIC.Api.Controllers.SocialForestryMeeting
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialForestryMeetingController : BaseController<ISocialForestryMeetingService, SocialForestryMeetingVM, Common.Entity.SocialForestryMeeting.SocialForestryMeeting>
    {
        private readonly ISocialForestryMeetingService _service;
        public SocialForestryMeetingController(ISocialForestryMeetingService service) :
            base(service)
        {
            _service = service;
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


        //[HttpPost("GetByFilterVM")]
        //[Authorize]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public virtual async Task<ActionResult> GetByFilterVM(SocialForestryTrainingFilterVM filter)
        //{
        //    (ExecutionState executionState, IList<SocialForestryTrainingVM> entity, string message) responseResult;

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }

        //        var result = await _service.GetByFilterVM(filter);

        //        responseResult.entity = result.entity;
        //        responseResult.executionState = result.executionState;
        //        responseResult.message = result.message;
        //        var apiResponse = new WebApiResponse<IList<SocialForestryTrainingVM>>(responseResult);

        //        return Ok(apiResponse);
        //    }
        //    catch (Exception e)
        //    {
        //        responseResult.entity = new List<SocialForestryTrainingVM>();
        //        responseResult.executionState = ExecutionState.Failure;
        //        responseResult.message = e.Message;
        //        var apiResponse = new WebApiResponse<IList<SocialForestryTrainingVM>>(responseResult);

        //        return StatusCode(500, apiResponse);
        //    }
        //}




    }
}