using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Service.Services.Patrolling;

namespace PTSL.GENERIC.Api.Controllers.Patrolling
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatrollingScheduleInformetionController : BaseController<IPatrollingScheduleInformetionService, PatrollingScheduleInformetionVM, PatrollingScheduleInformetion>
    {
        private readonly IPatrollingScheduleInformetionService _service;
        public PatrollingScheduleInformetionController(IPatrollingScheduleInformetionService service) :
            base(service)
        {
            _service = service;
        }

        //Implement here new api, if we want.
        [HttpPost("GetPatrollingScheduleInformetionByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<PatrollingScheduleInformetionVM>>>> GetPatrollingScheduleInformetionByFilter(PatrollingScheduleFilterVM filterData)
        {
            (ExecutionState executionState, List<PatrollingScheduleInformetionVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<PatrollingScheduleInformetionVM> entity, string message) result = await _service.GetPatrollingScheduleInformetionByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<PatrollingScheduleInformetionVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null; ;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<PatrollingScheduleInformetionVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<PatrollingScheduleInformetionVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }
    }
}
