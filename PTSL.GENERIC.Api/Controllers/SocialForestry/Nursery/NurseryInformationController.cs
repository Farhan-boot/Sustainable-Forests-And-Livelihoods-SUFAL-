using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Service.Services.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Nursery
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NurseryInformationController : BaseController<INurseryInformationService, NurseryInformationVM, NurseryInformation>
    {
        private readonly INurseryInformationService _service;

        public NurseryInformationController(INurseryInformationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<NurseryInformationVM>>>> GetFilterData([FromBody] NurseryFilterVM model)
        {
            (ExecutionState executionState, IList<NurseryInformationVM> entity, string message) result = await _service.GetFilterData(model);

            WebApiResponse<IList<NurseryInformationVM>> apiResponse = new WebApiResponse<IList<NurseryInformationVM>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }
        [HttpPost("GetNurseryReport")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<SocialForestryReport>>>> GetNurseryReport([FromBody] NurseryFilterVM model)
        {
            (ExecutionState executionState, IList<SocialForestryReport> entity, string message) result = await _service.GetNurseryReport(model);

            WebApiResponse<IList<SocialForestryReport>> apiResponse = new WebApiResponse<IList<SocialForestryReport>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }
        [HttpPost("GetNurseryDistributionReport")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<SocialForestryReport>>>> GetNurseryDistributionReport([FromBody] NurseryFilterVM model)
        {
            (ExecutionState executionState, IList<SocialForestryReport> entity, string message) result = await _service.GetNurseryDistributionReport(model);

            WebApiResponse<IList<SocialForestryReport>> apiResponse = new WebApiResponse<IList<SocialForestryReport>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }
        [HttpPost("BeneficiaryWiseDistribution")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<SocialForestryReport>>>> BeneficiaryWiseDistribution([FromBody] NurseryFilterVM model)
        {
            (ExecutionState executionState, IList<SocialForestryReport> entity, string message) result = await _service.GetNurseryDistributionByBeneficiaryReport(model);

            WebApiResponse<IList<SocialForestryReport>> apiResponse = new WebApiResponse<IList<SocialForestryReport>>(result);

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