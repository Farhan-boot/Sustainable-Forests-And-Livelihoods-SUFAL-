using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommitteeDesignationController : BaseController<ICommitteeDesignationService, CommitteeDesignationVM, CommitteeDesignation>
    {
        private ICommitteeDesignationService _SubCommitteeDesignationService { get; }

        public CommitteeDesignationController(ICommitteeDesignationService service) :
            base(service)
        {
            _SubCommitteeDesignationService = service;
        }

        [HttpPost("ListByFilter")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<CommitteeDesignationVM>>>> ListByFilter([FromBody] CommitteeDesignationFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _SubCommitteeDesignationService.ListByFilter(filter);

                if (executionState == ExecutionState.Retrieved)
                {
                    return Ok(new WebApiResponse<List<CommitteeDesignationVM>>(
                            (executionState, entity, message)
                        ));
                }
                else
                {
                    return NotFound(new WebApiResponse<List<CommitteeDesignationVM>>(
                            (executionState, entity, message)
                        ));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<CommitteeDesignationVM>>(
                        (ExecutionState.Failure, new List<CommitteeDesignationVM>(), "Unexpected error occurred")
                    ));
            }
        }
    }
}
