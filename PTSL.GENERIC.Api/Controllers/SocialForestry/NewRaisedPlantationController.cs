using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewRaisedPlantationController : BaseController<INewRaisedPlantationService, NewRaisedPlantationVM, NewRaisedPlantation>
    {
        private readonly INewRaisedPlantationService _service;

        public NewRaisedPlantationController(INewRaisedPlantationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpPost("ListByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<NewRaisedPlantationVM>>>> ListByFilter([FromBody] NewRaisedPlantationFilter filter)
        {
            try
            {
                var (executionState, entity, message) = await _service.ListByFilter(filter);

                return Ok(new WebApiResponse<List<NewRaisedPlantationVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<NewRaisedPlantationVM>>(
                        (ExecutionState.Failure, new List<NewRaisedPlantationVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("GetDetails/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<NewRaisedPlantationVM>>> GetDetails(long id)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetDetails(id);

                return Ok(new WebApiResponse<NewRaisedPlantationVM>(
                        (executionState, entity, message)
                    ));

            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<NewRaisedPlantationVM>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("GetNextRotationNo/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<string>>> GetNextRotationNo(long id)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetNextRotationNo(id);

                return Ok(new WebApiResponse<string>(
                        (executionState, entity, message)
                    ));

            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<string>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("GetDetailsForEdit/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<NewRaisedPlantationVM>>> GetDetailsForEdit(long id)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetDetailsForEdit(id);

                return Ok(new WebApiResponse<NewRaisedPlantationVM>(
                        (executionState, entity, message)
                    ));

            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<NewRaisedPlantationVM>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }


        [HttpPost("GetInformationAndDataOnNewlyRaisedPlantationReport")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<NewRaisedPlantationVM>>>> GetInformationAndDataOnNewlyRaisedPlantationReport([FromBody] NurseryFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetInformationAndDataOnNewlyRaisedPlantationReport(filter);

                return Ok(new WebApiResponse<List<NewRaisedPlantationVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<NewRaisedPlantationVM>>(
                        (ExecutionState.Failure, new List<NewRaisedPlantationVM>(), "Unexpected error occurred")
                    ));
            }
        }


        [HttpPost("GetInformationAndDataOnPlantationsFelledOrCutReport")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<NewRaisedPlantationVM>>>> GetInformationAndDataOnPlantationsFelledOrCutReport([FromBody] NurseryFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetInformationAndDataOnPlantationsFelledOrCutReport(filter);

                return Ok(new WebApiResponse<List<NewRaisedPlantationVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<NewRaisedPlantationVM>>(
                        (ExecutionState.Failure, new List<NewRaisedPlantationVM>(), "Unexpected error occurred")
                    ));
            }
        }





    }
}