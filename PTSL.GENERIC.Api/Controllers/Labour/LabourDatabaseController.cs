using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.Services.Interface.Labour;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;

namespace PTSL.GENERIC.Api.Controllers.Labour
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabourDatabaseController : BaseController<ILabourDatabaseService,LabourDatabaseVM,LabourDatabase>
    {

        private readonly ILabourDatabaseService _service;
        public LabourDatabaseController(ILabourDatabaseService service) :
        base(service)
        {
            _service = service;
        }

        [HttpPost("GetByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<LabourDatabaseVM>>>> GetLabourDatabaseByFilter(LabourDatabaseFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<LabourDatabaseVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<LabourDatabaseVM> entity, string message) result =await _service.GetByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<LabourDatabaseVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<LabourDatabaseVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<PaginationResutl<LabourDatabaseVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }


    }
}
