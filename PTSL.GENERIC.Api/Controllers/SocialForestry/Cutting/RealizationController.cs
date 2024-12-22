using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.Services.SocialForestry.Cutting;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Cutting
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RealizationController : BaseController<IRealizationService, RealizationVM, Realization>
    {
        private readonly IRealizationService _service;

        public RealizationController(IRealizationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetRealizationsByCuttingId/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<RealizationVM>>>> GetRealizationsByCuttingId(long id)
        {
            try
            {
                var result = await _service.GetRealizationsByCuttingId(id);
                var apiResponse = new WebApiResponse<List<RealizationVM>>((result.executionState, result.data, result.message));

                if (result.executionState == ExecutionState.Failure)
                {
                    return NotFound(apiResponse);
                }
                return Ok(apiResponse);
            }
            catch
            {
                return Ok(new WebApiResponse<List<RealizationVM>>((ExecutionState.Failure, null, "Unexpected error occurred")));
            }
        }

        [HttpGet("GetDefaultRealizationData/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<DefaultRealizationDataVM>>> GetDefaultRealizationData(long id)
        {
            try
            {
                var result = await _service.GetDefaultRealizationData(id);
                var apiResponse = new WebApiResponse<DefaultRealizationDataVM>((result.executionState, result.data, result.message));

                return Ok(apiResponse);
            }
            catch
            {
                return Ok(new WebApiResponse<DefaultRealizationDataVM>((ExecutionState.Failure, null, "Unexpected error occurred")));
            }
        }
    }
}