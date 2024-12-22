using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Reforestation
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplantationController : BaseController<IReplantationService, ReplantationVM, Replantation>
    {
        private readonly IReplantationService _service;

        public ReplantationController(IReplantationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetDetails/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<ReplantationVM>>> GetDetails(long id)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetDetails(id);

                return Ok(new WebApiResponse<ReplantationVM>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<ReplantationVM>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }
    }
}