using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PTSL.GENERIC.Api.Controllers.DashBoard;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BeneficiaryDashboardController : ControllerBase
{

    [HttpGet("GetDashboardData")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDashboardData()
    {
        return Ok("");
    }
}
