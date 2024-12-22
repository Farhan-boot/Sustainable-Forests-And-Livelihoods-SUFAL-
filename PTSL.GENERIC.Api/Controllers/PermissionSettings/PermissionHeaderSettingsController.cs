using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.PermissionSettings;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.PermissionSettings;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.Interface;
using PTSL.GENERIC.Service.Services.PermissionSettings;

namespace PTSL.GENERIC.Api.Controllers.PermissionSettings
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionHeaderSettingsController : BaseController<IPermissionHeaderSettingsService, PermissionHeaderSettingsVM, PermissionHeaderSettings>
    {
        private readonly IUserService _serviceUser;
        private readonly IPermissionHeaderSettingsService _servicePermissionHeaderSettings;
        public PermissionHeaderSettingsController(IPermissionHeaderSettingsService service, IUserService serviceUser, IPermissionHeaderSettingsService servicePermissionHeaderSettings) :
            base(service)
        {
            _serviceUser = serviceUser;
            _servicePermissionHeaderSettings = servicePermissionHeaderSettings;
        }


        [HttpGet("GetUserNameByUserRoleId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<UserVM>>>> GetUserNameByUserRoleId(long userRoleId)
        {
            (ExecutionState executionState, List<UserVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<UserVM> entity, string message) result = await _serviceUser.GetUserNameByUserRoleId(userRoleId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }


        [HttpGet("GetPermissionHeaderSettingsByModuleEnumId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<PermissionHeaderSettingsVM>>>> GetPermissionHeaderSettingsByModuleEnumId(long moduleEnumId)
        {
            (ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) result = await _servicePermissionHeaderSettings.GetPermissionHeaderSettingsByModuleEnumId(moduleEnumId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<PermissionHeaderSettingsVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<PermissionHeaderSettingsVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<PermissionHeaderSettingsVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }


        [HttpPost("GetFilterByForestId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<UserVM>>>> GetFilterByForestId(ExecutiveCommitteeFilterVM filterData)
        {
            (ExecutionState executionState, List<UserVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<UserVM> entity, string message) result = await _serviceUser.GetFilterByForestId(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }





        [HttpPost("GetByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<PermissionHeaderSettingsVM>>>> GetMeetingByFilter(ExecutiveCommitteeFilterVM filterData)
        {
            (ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) result = await _servicePermissionHeaderSettings.GetByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<PermissionHeaderSettingsVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<PermissionHeaderSettingsVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<PermissionHeaderSettingsVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("GetPermissionHeaderIdByControllerName/{c}")]
        public async Task<ActionResult<WebApiResponse<long>>> GetPermissionHeaderIdByControllerName(string c)
        {
            try
            {
                var (executionState, entity, message) = await _servicePermissionHeaderSettings.GetPermissionHeaderIdByControllerName(c);

                return Ok(new WebApiResponse<long>(
                        (executionState, entity, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<long>(
                        (ExecutionState.Failure, 0, "Unexpected error occurred")
                    ));
            }
        }
    }
}