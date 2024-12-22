using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.ForestManagement;

namespace PTSL.GENERIC.Api.Controllers.ForestManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommitteesConfigurationController : BaseController<ICommitteesConfigurationService, CommitteesConfigurationVM, CommitteesConfiguration>
    {
        private readonly ICommitteesConfigurationService _service;
        public CommitteesConfigurationController(ICommitteesConfigurationService service) :
            base(service)
        {
            _service = service;
        }


        [HttpGet("GetCommitteesConfigurationByCommitteeTypeConfigurationId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<CommitteesConfigurationVM>>>> GetCommitteesConfigurationByCommitteeTypeConfigurationId(long id)
        {
            (ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _service.GetCommitteesConfigurationByCommitteeTypeConfigurationId(id);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;

                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<CommitteesConfigurationVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<CommitteesConfigurationVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<CommitteesConfigurationVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

    }
}