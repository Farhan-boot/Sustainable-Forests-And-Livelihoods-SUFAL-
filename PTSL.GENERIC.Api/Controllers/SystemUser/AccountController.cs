using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.TokenHelper;
//using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Service.Services.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.SystemUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<IUserService, UserVM, User>
    {
        private readonly IUserService _userService;
        private readonly IUserBusiness _business;
        private IConfiguration _config;
        private readonly IGenerateJSONWebToken _generateJSONWebToken;

        public AccountController(IUserService userService, IUserBusiness business, IConfiguration config, IGenerateJSONWebToken generateJSONWebToken) :
            base(userService)
        {
            _config = config;
            _generateJSONWebToken = generateJSONWebToken;
            _userService = userService;
            _business = business;
        }

        //Implement here new api, if we want.

        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<LoginResultVM>>> Login([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var (executionState, entity, refreshToken, message) = await _userService.UserLogin(model);

            (ExecutionState executionState, LoginResultVM entity, string message) responseResult;

            if (executionState == ExecutionState.Retrieved)
            {
                var accessToken = _generateJSONWebToken.GetToken(entity, model.RememberMe);
                var loginResult = new LoginResultVM
                {
                    UserId = entity.Id,
                    UserEmail = entity.UserEmail,
                    UserName = entity.UserName,
                    RoleName = entity.RoleName,
                    SurveyId = entity.SurveyId,

                    ForestCircleId = entity.ForestCircleId,
                    ForestDivisionId = entity.ForestDivisionId,
                    ForestRangeId = entity.ForestRangeId,
                    ForestBeatId = entity.ForestBeatId,
                    ForestFcvVcfId = entity.ForestFcvVcfId,

                    DistrictId = entity.DistrictId,
                    DivisionId = entity.DivisionId,
                    UpazillaId = entity.UpazillaId,
                    UnionId = entity.UnionId,

                    Token = accessToken,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,

                    UserRoleId = entity.UserRoleId
                };
                //HttpContext.Session.SetString("UserId", loginResult.UserId.ToString());
                responseResult.entity = loginResult;
                responseResult.message = message;
                responseResult.executionState = executionState;
                WebApiResponse<LoginResultVM> apiResponse = new WebApiResponse<LoginResultVM>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = message;
                responseResult.executionState = executionState;

                WebApiResponse<LoginResultVM> apiResponse = new WebApiResponse<LoginResultVM>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpGet("UserLists")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<UserDropdownVM>>> UserLists()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<UserVM> entity, string message) result = await _userService.List();

            (ExecutionState executionState, List<UserDropdownVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {
                List<UserDropdownVM> users = new List<UserDropdownVM>();
                foreach (var data in result.entity)
                {
                    UserDropdownVM userDropdownVM = new UserDropdownVM();
                    userDropdownVM.Id = data.Id;
                    userDropdownVM.UserEmail = data.UserEmail;
                    userDropdownVM.UserName = data.UserName;
                    users.Add(userDropdownVM);

                }
                responseResult.entity = users;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<UserDropdownVM>> apiResponse = new WebApiResponse<List<UserDropdownVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<UserDropdownVM>> apiResponse = new WebApiResponse<List<UserDropdownVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        [HttpPost("GetBeneficiaryByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<UserVM>>>> GetBeneficiaryByFilter(BeneficiaryUserFilterVM filterData)
        {
            (ExecutionState executionState, List<UserVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<UserVM> entity, string message) result = await _userService.GetBeneficiaryByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity.ToList();
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<UserVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("GenerateSurveyAccounts")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<long>>> GenerateSurveyAccounts(ForestCivilLocationFilter filterData)
        {
            try
            {
                var (executionState, entity, message) = await _business.GenerateSurveyAccounts(filterData);

                return Ok(new WebApiResponse<long>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception e)
            {
                return StatusCode(500, new WebApiResponse<long>(
                        (ExecutionState.Failure, 0, "Unexpected error occurred")
                    ));
            }
        }

        [HttpGet("ListSurveyAccounts/{takeLatest}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<IList<UserVM>>>>> ListSurveyAccounts(int takeLatest = 50)
        {
            (ExecutionState executionState, IList<UserVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<UserVM> entity, string message) result = await _userService.ListSurveyAccounts(takeLatest);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<UserVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<UserVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<UserVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        public override async Task<ActionResult<WebApiResponse<UserVM>>> UpdateAsync([FromBody] UserVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
            _ = long.TryParse(userIdJwt, out var userId);

            model.ModifiedBy = userId;
            model.UpdatedAt = DateTime.Now;

            var result = await _userService.UpdateAsync(model);
            var apiResponse = new WebApiResponse<UserVM>(result);

            return Ok(apiResponse);
        }

        [HttpGet("GetUserInfoByUserRoleId/{userRoleId}")]
        public async Task<ActionResult<WebApiResponse<List<UserVM>>>> GetUserInfoByUserRoleId(long userRoleId)
        {
            try
            {
                var (executionState, entity, message) = await _userService.GetUserInfoByUserRoleId(userRoleId);

                return Ok(new WebApiResponse<List<UserVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch
            {
                return StatusCode(500, new WebApiResponse<List<UserVM>>(
                        (ExecutionState.Failure, "Unexpected error occurred")
                    ));
            }
        }
    }
}
