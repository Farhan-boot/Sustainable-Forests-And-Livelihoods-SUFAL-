using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentalTrainingController : BaseController<IDepartmentalTrainingService, DepartmentalTrainingVM, DepartmentalTraining>
    {
        private readonly IDepartmentalTrainingService _service;
        public DepartmentalTrainingController(IDepartmentalTrainingService service) :
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

        [HttpGet("GetByFilter/{finalYearId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult> GetByFilter(long finalYearId)
        {
            (ExecutionState executionState, IList<DepartmentalTrainingVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _service.GetByFilter(finalYearId);

                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<IList<DepartmentalTrainingVM>>(responseResult);

                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                responseResult.entity = new List<DepartmentalTrainingVM>();
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<DepartmentalTrainingVM>>(responseResult);

                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("GetByFilterVM")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult> GetByFilterVM(DepartmentalTrainingFilterVM filter)
        {
            (ExecutionState executionState, PaginationResutl<DepartmentalTrainingVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _service.GetByFilterVM(filter);

                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<PaginationResutl<DepartmentalTrainingVM>>(responseResult);

                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                responseResult.entity = new PaginationResutl<DepartmentalTrainingVM>();
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<PaginationResutl<DepartmentalTrainingVM>>(responseResult);

                return StatusCode(500, apiResponse);
            }
        }
    }
}
