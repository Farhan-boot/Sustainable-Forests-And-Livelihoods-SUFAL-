using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Service.Services.SocialForestry.Nursery;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Nursery
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NurseryRaisedSeedlingInformationController : BaseController<INurseryRaisedSeedlingInformationService, NurseryRaisedSeedlingInformationVM, NurseryRaisedSeedlingInformation>
    {
        private readonly INurseryRaisedSeedlingInformationService _service;

        public NurseryRaisedSeedlingInformationController(INurseryRaisedSeedlingInformationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetSeedlingByNurseryId/{id}/{forPlantationOrDistribution}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<NurseryRaisedSeedlingInformationVM>>>> GetSeedlingByNurseryId(long id, bool forPlantationOrDistribution)
        {
            try
            {
                var result = await _service.GetSeedlingByNurseryId(id, forPlantationOrDistribution);
                var apiResponse = new WebApiResponse<List<NurseryRaisedSeedlingInformationVM>>((result.executionState, result.entity, result.message));

                if (result.executionState == ExecutionState.Failure)
                {
                    return NotFound(apiResponse);
                }
                return Ok(apiResponse);
            }
            catch
            {
                return Ok(new WebApiResponse<List<NurseryRaisedSeedlingInformationVM>>((ExecutionState.Failure, null, "Unexpected error occurred")));
            }
        }
        [HttpPut("SeedlingUpdate")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<NurseryRaisedSeedlingInformationVM>>> SeedlingUpdate([FromBody] UpdateSeedlingInfoVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
            _ = long.TryParse(userIdJwt, out var userId);

            (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) result = await _service.SeedlinUpdate(model);
            WebApiResponse<NurseryRaisedSeedlingInformationVM> apiResponse = new WebApiResponse<NurseryRaisedSeedlingInformationVM>(result);

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