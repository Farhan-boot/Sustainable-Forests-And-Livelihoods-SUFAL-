using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestry.Cutting;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Cutting
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShareDistributionController : BaseController<IShareDistributionService, ShareDistributionVM, ShareDistribution>
    {
        private readonly IShareDistributionService _service;

        public ShareDistributionController(IShareDistributionService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("ListByCuttingPlantation/{cuttingPlantationId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<ShareDistributionVM>>>> ListByCuttingPlantation(long cuttingPlantationId)
        {
            try
            {
                var (executionState, entity, message) = await _service.ListByCuttingPlantation(cuttingPlantationId);

                return Ok(new WebApiResponse<List<ShareDistributionVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<ShareDistributionVM>>(
                        (ExecutionState.Failure, new List<ShareDistributionVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("GetDefaultDistributionData/{cuttingPlantationId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<DefaultDistributionDataVM>>> GetDefaultDistributionData(long cuttingPlantationId)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetDefaultDistributionData(cuttingPlantationId);

                return Ok(new WebApiResponse<DefaultDistributionDataVM>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<DefaultDistributionDataVM>(
                        (ExecutionState.Failure, new DefaultDistributionDataVM(), "Unexpected error occurred")
                    ));
            }
        }

        public override async Task<ActionResult<WebApiResponse<ShareDistributionVM>>> CreateAsync([FromBody] ShareDistributionVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            model.CreatedBy = HttpContext.GetCurrentUserId();
            model.CreatedAt = DateTime.Now;

            (ExecutionState executionState, ShareDistributionVM entity, string message) result = await _service.CreateAsync(model);

            WebApiResponse<ShareDistributionVM> apiResponse = new WebApiResponse<ShareDistributionVM>(result);

            return Ok(apiResponse);
        }
    }
}