using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Api.Helpers.Authorize;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.Beneficiary;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CipController : BaseController<ICipService, CipVM, Cip>
    {
        private readonly ICipService _service;

        public CipController(ICipService service) :
            base(service)
        {
            _service = service;
        }

        [HttpPost("ListByFilter")]
        [Authorize(Policy = CipListByFilterPermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<CipVM>>>> ListByFilter(CipFilterVM filter)
        {
            (ExecutionState executionState, PaginationResutl<CipVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<CipVM> entity, string message) result = await _service.ListByFilter(filter);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;


                    var apiResponse = new WebApiResponse<PaginationResutl<CipVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<CipVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<PaginationResutl<CipVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("ListByFilterForBeneficiary")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<CipVM>>>> ListByFilterForBeneficiary(CipFilterVM filter)
        {
            (ExecutionState executionState, IList<CipVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<CipVM> entity, string message) result = await _service.ListByFilterForBeneficiary(filter);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<CipVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<CipVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<CipVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost]
        [Authorize(Policy = CipCreatePermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult<WebApiResponse<CipVM>>> CreateAsync([FromBody] CipVM model)
        {
            return base.CreateAsync(model);
        }

        [HttpPut]
        [Authorize(Policy = CipUpdatePermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult<WebApiResponse<CipVM>>> UpdateAsync([FromBody] CipVM model)
        {
            return base.UpdateAsync(model);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = CipDeletePermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult<WebApiResponse<CipVM>>> RemoveAsync(long id)
        {
            return base.RemoveAsync(id);
        }

        [HttpPut("SoftDelete/{id}")]
        [Authorize(Policy = CipDeletePermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult<WebApiResponse<bool>>> SoftDeleteAsync(long id)
        {
            return base.SoftDeleteAsync(id);
        }
    }
}

public class CipListByFilterPermission : IAPIPermission
{
    public const string PermissionNameConst = "Cip.ListByFilter";
    public string PermissionName => "Cip.ListByFilter";
    public string PermissionDetails => "CIP List by Filter";
}

public class CipCreatePermission : IAPIPermission
{
    public const string PermissionNameConst = "Cip.Create";
    public string PermissionName => "Cip.Create";
    public string PermissionDetails => "Create CIP";
}

public class CipUpdatePermission : IAPIPermission
{
    public const string PermissionNameConst = "Cip.Update";
    public string PermissionName => "Cip.Update";
    public string PermissionDetails => "Update CIP";
}

public class CipDeletePermission : IAPIPermission
{
    public const string PermissionNameConst = "Cip.Delete";
    public string PermissionName => "Cip.Delete";
    public string PermissionDetails => "Delete CIP";
}

