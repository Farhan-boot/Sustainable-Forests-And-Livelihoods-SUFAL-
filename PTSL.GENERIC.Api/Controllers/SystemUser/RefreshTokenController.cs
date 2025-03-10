﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Service.Services.Interface.SystemUser;

namespace PTSL.GENERIC.Api.Controllers.SystemUser;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RefreshTokenController : ControllerBase
{
    private readonly IRefreshTokenService _refreshTokenService;

    public RefreshTokenController(IRefreshTokenService refreshTokenService, IConfiguration config)
    {
        _refreshTokenService = refreshTokenService;
    }

    [AllowAnonymous]
    [HttpPost("GetNewToken")]
    public async Task<ActionResult<WebApiResponse<LoginResultVM>>> GetNewToken([FromBody] UserTokenRequestResponseVM model)
    {
        (ExecutionState executionState, LoginResultVM entity, string message) result;
        try
        {
            result = await _refreshTokenService.GetNewTokenAsync(model);

            if (result.executionState == ExecutionState.Success)
            {
                return Ok(new WebApiResponse<LoginResultVM>(result!));
            }

            return BadRequest(new WebApiResponse<LoginResultVM>(result!));
        }
        catch (Exception ex)
        {
            result = (executionState: ExecutionState.Failure, null, "Failed to get new token");
            return BadRequest(new WebApiResponse<LoginResultVM>(result!));
        }
    }
}
