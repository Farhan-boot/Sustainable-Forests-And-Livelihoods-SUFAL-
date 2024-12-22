using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Service.Services.Beneficiary;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyIncidentController : BaseController<ISurveyIncidentService, SurveyIncidentVM, SurveyIncident>
    {
        private readonly ISurveyIncidentService _service;

        public SurveyIncidentController(ISurveyIncidentService service) :
            base(service)
        {
            _service = service;
        }

        [HttpPost("ListByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<SurveyIncidentVM>>>> ListByFilter(SurveyIncidentFilterVM filter)
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
                    return Ok(new WebApiResponse<List<SurveyIncidentVM>>(
                            (executionState, entity, message)
                        ));
                }
                else
                {
                    return NotFound(new WebApiResponse<List<SurveyIncidentVM>>(
                            (executionState, entity, message)
                        ));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<SurveyIncidentVM>>(
                        (ExecutionState.Failure, new List<SurveyIncidentVM>(), "Unexpected error occurred")
                    ));
            }
        }
    }
}