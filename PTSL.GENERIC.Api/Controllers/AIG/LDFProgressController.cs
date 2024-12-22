using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Api.Helpers.Authorize;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.Services.AIG;

namespace PTSL.GENERIC.Api.Controllers.Capacity;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LDFProgressController : BaseController<ILDFProgressService, LDFProgressVM, LDFProgress>
{
    private readonly ILDFProgressService _service;

    public LDFProgressController(ILDFProgressService service) :
        base(service)
    {
        _service = service;
    }

    [Authorize(Policy = AIGProgressCreatePermission.PermissionNameConst)]
    public async override Task<ActionResult<WebApiResponse<LDFProgressVM>>> CreateAsync([FromBody] LDFProgressVM model)
    {
        var (executionState, entity, message) = await _service.CreateAsync(model);

        return Ok(new WebApiResponse<LDFProgressVM>(
            (executionState, entity, message)
            ));
    }

    [Authorize(Policy = AIGProgressUpdatePermission.PermissionNameConst)]
    public override async Task<ActionResult<WebApiResponse<LDFProgressVM>>> UpdateAsync([FromBody] LDFProgressVM model)
    {
        var (executionState, entity, message) = await _service.UpdateAsync(model);

        return Ok(new WebApiResponse<LDFProgressVM>(
            (executionState, entity, message)
            ));
    }
}

public class AIGProgressCreatePermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG Progress.Create";
    public string PermissionName => "AIG Progress.Create";
    public string PermissionDetails => "Create progress";
}

public class AIGProgressUpdatePermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG Progress.Update";
    public string PermissionName => "AIG Progress.Update";
    public string PermissionDetails => "Update progress";
}

public class AIGProgressByBeneficiaryPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG Progress.ProgressByBeneficiary";
    public string PermissionName => "AIG Progress.ProgressByBeneficiary";
    public string PermissionDetails => "AIG Progress by beneficiary";
}

