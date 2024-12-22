using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.CipManagement;

namespace PTSL.GENERIC.Api.Controllers.CipManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CipTeamController : BaseController<ICipTeamService, CipTeamVM, CipTeam>
    {

        private readonly ICipTeamService _service;

        public CipTeamController(ICipTeamService service) :
            base(service)
        {
            _service = service;
        }


        [HttpPost("GetByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<CipTeamVM>>>> GetByFilter(ExecutiveCommitteeFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<CipTeamVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<CipTeamVM> entity, string message) result = await _service.GetByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<CipTeamVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<CipTeamVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<PaginationResutl<CipTeamVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }




    }
}