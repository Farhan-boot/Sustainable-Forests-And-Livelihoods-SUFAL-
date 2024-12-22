using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.Services.SocialForestry;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialForestryBeneficiaryController : BaseController<ISocialForestryBeneficiaryService, SocialForestryBeneficiaryVM, SocialForestryBeneficiary>
    {
        private readonly ISocialForestryBeneficiaryService _service;

        public SocialForestryBeneficiaryController(ISocialForestryBeneficiaryService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetBeneficiariesByNewRaisedId/{id}/{hasPbsa}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<SocialForestryBeneficiaryVM>>>> GetBeneficiariesByNewRaisedId(long id, bool hasPbsa = false)
        {
            try
            {
                var (executionState, entity, message) = await _service.GetBeneficiariesByNewRaisedId(id, hasPbsa);

                return Ok(new WebApiResponse<List<SocialForestryBeneficiaryVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<SocialForestryBeneficiaryVM>>(
                        (ExecutionState.Failure, null, "Unexpected error occurred")
                    ));
            }
        }
    }
}
