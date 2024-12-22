using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Service.Services.ForestManagement;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.ForestManagement
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OtherCommitteeMemberController : BaseController<IOtherCommitteeMemberService, OtherCommitteeMemberVM, OtherCommitteeMember>
    {
        private readonly IOtherCommitteeMemberService _otherCommitteeMemberService;

        public OtherCommitteeMemberController(IOtherCommitteeMemberService service) :
            base(service)
        {
            _otherCommitteeMemberService = service;
        }

        [HttpGet("ListByForestFcvVcf/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<OtherCommitteeMemberVM>>> ListByForestFcvVcf([FromRoute] long id)
        {
            (ExecutionState executionState, IList<OtherCommitteeMemberVM> entity, string message) result = await _otherCommitteeMemberService.ListByForestFcvVcf(id);
            (ExecutionState executionState, IList<OtherCommitteeMemberVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<OtherCommitteeMemberVM>> apiResponse = new WebApiResponse<IList<OtherCommitteeMemberVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<IList<OtherCommitteeMemberVM>> apiResponse = new WebApiResponse<IList<OtherCommitteeMemberVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
    }
}
