using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.Services.SocialForestry.Cutting;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Cutting
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CuttingPlantationController : BaseController<ICuttingPlantationService, CuttingPlantationVM, CuttingPlantation>
    {
        private readonly ICuttingPlantationService _service;

        public CuttingPlantationController(ICuttingPlantationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("ListByNewRaised/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<CuttingPlantationVM>>>> ListByNewRaised(long id)
        {
            try
            {
                var (executionState, entity, message) = await _service.ListByNewRaised(id);

                return Ok(new WebApiResponse<IList<CuttingPlantationVM>>(
                        (executionState, entity, message)
                    ));

            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<IList<CuttingPlantationVM>>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }


        //New filter add
        [HttpPost("ListByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<CuttingPlantationVM>>>> ListByFilter([FromBody] NewRaisedPlantationFilter filter)
        {
            try
            {
                var (executionState, entity, message) = await _service.ListByFilter(filter);

                return Ok(new WebApiResponse<List<CuttingPlantationVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<CuttingPlantationVM>>(
                        (ExecutionState.Failure, new List<CuttingPlantationVM>(), "Unexpected error occurred")
                    ));
            }
        }


    }
}