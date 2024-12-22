using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Business.Businesses.Implementation.ForestManagement;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
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
    public class CommitteeTypeConfigurationController : BaseController<ICommitteeTypeConfigurationService, CommitteeTypeConfigurationVM, CommitteeTypeConfiguration>
    {
        private readonly ICommitteeTypeConfigurationService _service;
        public CommitteeTypeConfigurationController(ICommitteeTypeConfigurationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetCommitteeTypeConfigurationByFcvOrVcfId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<CommitteeTypeConfigurationVM>>>> GetCommitteeTypeConfigurationByFcvOrVcfId(long id)
        {
            (ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

               var result = await _service.GetCommitteeTypeConfigurationByFcvOrVcfId(id);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity =  result.entity;

                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<CommitteeTypeConfigurationVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<CommitteeTypeConfigurationVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<CommitteeTypeConfigurationVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }



    }
}