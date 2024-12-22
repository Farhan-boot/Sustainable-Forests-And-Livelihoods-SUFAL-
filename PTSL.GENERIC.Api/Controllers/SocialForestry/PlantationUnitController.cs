using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SocialForestry;

namespace PTSL.GENERIC.Api.Controllers.SocialForestry
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlantationUnitController : BaseController<IPlantationUnitService, PlantationUnitVM, PlantationUnit>
    {
        private readonly IPlantationUnitService _service;

        public PlantationUnitController(IPlantationUnitService service) :
            base(service)
        {
            _service = service;
        }

        [HttpGet("ListByType/{unitType}")]
        public async Task<ActionResult<WebApiResponse<List<PlantationUnitVM>>>> ListByType(UnitType unitType)
        {
            try
            {
                var (executionState, entity, message) = await _service.ListByType(unitType);

                return Ok(new WebApiResponse<List<PlantationUnitVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<PlantationUnitVM>>(
                        (ExecutionState.Failure, new List<PlantationUnitVM>(), "Unexpected error occurred")
                    ));
            }
        }
    }
}