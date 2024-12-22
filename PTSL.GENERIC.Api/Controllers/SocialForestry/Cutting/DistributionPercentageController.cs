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
    public class DistributionPercentageController : BaseController<IDistributionPercentageService, DistributionPercentageVM, DistributionPercentage>
    {
        private readonly IDistributionPercentageService _service;

        public DistributionPercentageController(IDistributionPercentageService service) :
            base(service)
        {
            _service = service;
        }
        [HttpPost("CreateRangeAsync")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<DistributionPercentageVM>>>> CreateRangeAsync([FromBody] DistributionPercentageCustomVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            foreach (var item in model.DistributionPercentageListVM)
            {

                item.CreatedBy = HttpContext.GetCurrentUserId();
                item.CreatedAt = DateTime.Now;
            }

            (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) result = await _service.CreateRangeAsync(model);

            WebApiResponse<List<DistributionPercentageVM>> apiResponse = new WebApiResponse<List<DistributionPercentageVM>>(result);

            return Ok(apiResponse);
        }
        [HttpPost("UpdateRangeAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<List<DistributionPercentageVM>>>> UpdateRangeAsync(long id, [FromBody] DistributionPercentageCustomVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            foreach (var item in model.DistributionPercentageListVM)
            {

                item.ModifiedBy = HttpContext.GetCurrentUserId();
                item.UpdatedAt = DateTime.Now;
            }

            (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) result = await _service.UpdateRangeAsync(id,model);

            WebApiResponse<List<DistributionPercentageVM>> apiResponse = new WebApiResponse<List<DistributionPercentageVM>>(result);

            return Ok(apiResponse);
        }

        [HttpGet("GetByPlantationType/{id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<DistributionPercentageVM>>>> GetByPlantationTypeIdAsync(long id)
        {

            (ExecutionState executionState, IList<DistributionPercentageVM> entity, string message) result = await _service.GetByPlantationTypeId(id);

            WebApiResponse<IList<DistributionPercentageVM>> apiResponse = new WebApiResponse<IList<DistributionPercentageVM>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }
    }
}