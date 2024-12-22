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
    public class LotWiseSellingInformationController : BaseController<ILotWiseSellingInformationService, LotWiseSellingInformationVM, LotWiseSellingInformation>
    {
        private readonly ILotWiseSellingInformationService _service;

        public LotWiseSellingInformationController(ILotWiseSellingInformationService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("GetLotInfoByCuttingId/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<LotWiseSellingInformationVM>>>> GetLotInfoByCuttingId(long id)
        {
            try
            {
                var result = await _service.GetLotInfoByCuttingId(id);
                var apiResponse = new WebApiResponse<List<LotWiseSellingInformationVM>>((result.executionState, result.data, result.message));

                return Ok(apiResponse);
            }
            catch
            {
                return Ok(new WebApiResponse<List<LotWiseSellingInformationVM>>((ExecutionState.Failure, null, "Unexpected error occurred")));
            }
        }

        [HttpGet("GetLotInfoByLotNumber/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<LotWiseSellingInformationVM>>> GetLotInfoByLotNumber(string lotNumber)
        {
            try
            {
                var result = await _service.GetLotInfoByLotNumber(lotNumber);
                var apiResponse = new WebApiResponse<LotWiseSellingInformationVM>((result.executionState, result.data, result.message));

                return Ok(apiResponse);
            }
            catch
            {
                return Ok(new WebApiResponse<LotWiseSellingInformationVM>((ExecutionState.Failure, null, "Unexpected error occurred")));
            }
        }
    }
}