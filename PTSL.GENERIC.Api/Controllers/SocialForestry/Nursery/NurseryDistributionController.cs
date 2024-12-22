using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Service.Services.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry.Nursery
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NurseryDistributionController : BaseController<INurseryDistributionService, NurseryDistributionVM, NurseryDistribution>
    {
        private readonly INurseryDistributionService _service;

        public NurseryDistributionController(INurseryDistributionService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("Nursery/{id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<DistributionVM>>>> GetByNurseryAsync(long id)// List by NurseryId 
        {
          
            (ExecutionState executionState, List<DistributionVM> entity, string message) result = await _service.ListByNurseryId(id);

            WebApiResponse<List<DistributionVM>> apiResponse = new WebApiResponse<List<DistributionVM>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }
        [HttpGet("Distribution/{id}")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<NurseryDistributionVM>>>> GetListByDistributionId(long id)// List by NurseryId 
        {
          
            (ExecutionState executionState, IList<NurseryDistributionVM> entity, string message) result = await _service.ListByDistributionById(id);

            WebApiResponse<IList<NurseryDistributionVM>> apiResponse = new WebApiResponse<IList<NurseryDistributionVM>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }

        [HttpPost("CreateRangeAsync")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public  async Task<ActionResult<WebApiResponse<NurseryDistributionListVM>>> CreateRangeAsync([FromBody] NurseryDistributionListVM model)
        {
            var result = await _service.CreateRangeAsync(model);

            WebApiResponse<IList<NurseryDistributionVM>> apiResponse = new WebApiResponse<IList<NurseryDistributionVM>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }
        
        [HttpPost("UpdateRangeAsync")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public  async Task<ActionResult<WebApiResponse<NurseryDistributionListVM>>> UpdateRangeAsync([FromBody] NurseryDistributionListVM model)
        {
            var result = await _service.UpdateRangeAsync(model);

            WebApiResponse<IList<NurseryDistributionVM>> apiResponse = new WebApiResponse<IList<NurseryDistributionVM>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }
        
        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public  async Task<ActionResult<WebApiResponse<List<NurseryDistributionVM>>>> GetFilterData([FromBody] DistributionFilter model)
        {
            (ExecutionState executionState, IList<NurseryDistributionVM> entity, string message ) result = await _service.GetFilterData(model);

            WebApiResponse<IList<NurseryDistributionVM>> apiResponse = new WebApiResponse<IList<NurseryDistributionVM>>(result);

            if (result.executionState == ExecutionState.Failure)
            {
                return NotFound(apiResponse);
            }
            else
            {
                return Ok(apiResponse);
            }
        }
        [HttpPost("GetByDate/{nurseryId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public  async Task<ActionResult<WebApiResponse<List<DistributionVM>>>> GetByDate(long nurseryId, [FromBody] NurseryFilterVM model)
        {
            (ExecutionState executionState, IList<DistributionVM> entity, string message ) result = await _service.GetFilterByDate(nurseryId, model);

            WebApiResponse<IList<DistributionVM>> apiResponse = new WebApiResponse<IList<DistributionVM>>(result);

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