using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Service.Services.Labour;

namespace PTSL.GENERIC.Api.Controllers.Labour
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabourWorkController : BaseController<ILabourWorkService, LabourWorkVM, LabourWork>
    {
        private readonly ILabourWorkService _service;

        public LabourWorkController(ILabourWorkService service) :
            base(service)
        {
            _service = service;
        }

        [HttpPost("ListByFilter")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<LabourWorkVM>>>> ListByFilter([FromBody] LabourWorkFilterVM filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var (executionState, entity, message) = await _service.ListByFilter(filter);

                if (executionState == ExecutionState.Retrieved)
                {
                    return Ok(new WebApiResponse<List<LabourWorkVM>>(
                            (executionState, entity, message)
                        ));
                }
                else
                {
                    return NotFound(new WebApiResponse<List<LabourWorkVM>>(
                            (executionState, entity, message)
                        ));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<LabourWorkVM>>(
                        (ExecutionState.Failure, new List<LabourWorkVM>(), "Unexpected error occurred")
                    ));
            }
        }
    }
}