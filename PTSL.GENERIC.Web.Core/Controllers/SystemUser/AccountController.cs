using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Common;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.SystemUser
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IPmsGroupService _PmsGroupService;
        private readonly IUserService _UserService;
        private readonly ISurveyService _SurveyService;
        private readonly IUserRoleService _userRoleService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;
        // Map To Account into User
        private readonly IAccountService _AccountService;
        private readonly IAccountsUserTagLogService _AccountsUserTagLogService;
        private readonly IBankAccountsInformationService _BankAccountsInformationService;
        

        public AccountController(HttpHelper httpHelper)
        {
            _PmsGroupService = new PmsGroupService(httpHelper);
            _UserService = new UserService(httpHelper);
            _SurveyService = new SurveyService(httpHelper);
            _userRoleService = new UserRoleService(httpHelper);

            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
            // Map To Account into User
            _AccountService = new AccountService(httpHelper);
            _AccountsUserTagLogService = new AccountsUserTagLogService(httpHelper);
            _BankAccountsInformationService = new BankAccountsInformationService(httpHelper);
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            LoginVM model = new LoginVM();
            return View(model);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            (ExecutionState executionState, LoginResultVM entity, string message) result = _UserService.UserLogin(model);

            if (result.entity != null)
            {
                var surveyIsValid = result.entity.SurveyId.HasValue && result.entity.SurveyId > 0;

                HttpContext.Session.SetString(SessionKey.UserRoleId, result.entity?.UserRoleId?.ToString() ?? string.Empty);
                HttpContext.Session.SetString("Token", result.entity?.Token ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.UserEmail, result.entity?.UserEmail ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.RoleName, result.entity?.RoleName ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.UserId, result.entity?.UserId.ToString() ?? string.Empty);

                HttpContext.Session.SetString(SessionKey.SurveyId, surveyIsValid ? result.entity?.SurveyId.ToString() ?? string.Empty : string.Empty);

                HttpContext.Session.SetString(SessionKey.ForestCircleId, result.entity?.ForestCircleId.ToString() ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.ForestDivisionId, result.entity?.ForestDivisionId.ToString() ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.ForestRangeId, result.entity?.ForestRangeId.ToString() ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.ForestBeatId, result.entity?.ForestBeatId.ToString() ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.ForestFcvVcfId, result.entity?.ForestFcvVcfId.ToString() ?? string.Empty);

                HttpContext.Session.SetString(SessionKey.DivisionId, result.entity?.DivisionId.ToString() ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.DistrictId, result.entity?.DistrictId.ToString() ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.UpazillaId, result.entity?.UpazillaId.ToString() ?? string.Empty);
                HttpContext.Session.SetString(SessionKey.UnionId, result.entity?.UnionId.ToString() ?? string.Empty);

                var token = HttpContext.Session.GetString("Token");

                if (surveyIsValid)
                {
                    return RedirectToAction(nameof(HomeController.BeneficiaryIndex), "Home");
                }
                else
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            ViewBag.ErrorMsg = "Username or Password Invalid !";

            return View(model);
        }

        //
        // GET: /Account/VerifyCode
        //[AllowAnonymous]
        //public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        //{
        //	// Require that the user has already logged in via username/password or external login
        //	if (!await SignInManager.HasBeenVerifiedAsync())
        //	{
        //		return View("Error");
        //	}
        //	return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}

        //
        // POST: /Account/VerifyCode
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return View(model);
        //	}

        //	// The following code protects for brute force attacks against the two factor codes.
        //	// If a user enters incorrect codes for a specified amount of time then the user account
        //	// will be locked out for a specified amount of time.
        //	// You can configure the account lockout settings in IdentityConfig
        //	var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
        //	switch (result)
        //	{
        //		case SignInStatus.Success:
        //			return RedirectToLocal(model.ReturnUrl);
        //		case SignInStatus.LockedOut:
        //			return View("Lockout");
        //		case SignInStatus.Failure:
        //		default:
        //			ModelState.AddModelError("", "Invalid code.");
        //			return View(model);
        //	}
        //}

        // GET: UrerList
        public ActionResult UserLists()
        {
            (ExecutionState executionState, List<UserVM> entity, string message) returnResponse = _UserService.List();
            return View(returnResponse.entity);
        }

        //
        // GET: /Account/Register
        public ActionResult Register()
        {
            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name");
            ViewBag.ForestDivisionId = new SelectList("");
            ViewBag.ForestRangeId = new SelectList("");
            ViewBag.ForestBeatId = new SelectList("");
            ViewBag.ForestFcvVcfId = new SelectList("");
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name");

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
            ViewBag.DistrictId = new SelectList("");
            ViewBag.UpazillaId = new SelectList("");
            ViewBag.UnionId = new SelectList("");
            ViewBag.UserRoleId = new SelectList(_userRoleService.List().entity ?? new List<UserRoleVM>(), "Id", "RoleName");

            return View(new UserVM());
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserVM model)
        {
            try
            {
                var hasSurveyId = model.SurveyId is not null && model.SurveyId > 0;
                model.UserType = hasSurveyId ? UserType.Beneficiary : UserType.Admin;

                var (executionState, entity, message) = _UserService.Create(model);

                HttpContext.Session.SetString("Message", message);
                HttpContext.Session.SetString("executionState", executionState.ToString());

                return executionState == ExecutionState.Failure
                    ? View(model)
                    : hasSurveyId ? RedirectToAction("BeneficiaryUser") : RedirectToAction("UserLists");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult UserEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, UserVM entity, string message) result = _UserService.GetById(id);

            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", result.entity.ForestCircleId ?? 0);
            ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(result.entity.ForestCircleId ?? 0).entity ?? new List<ForestDivisionVM>(), "Id", "Name", result.entity.ForestDivisionId ?? 0);
            ViewBag.ForestRangeId = new SelectList(_ForestRangeService.ListByForestDivision(result.entity.ForestDivisionId ?? 0).entity ?? new List<ForestRangeVM>(), "Id", "Name", result.entity.ForestRangeId ?? 0);
            ViewBag.ForestBeatId = new SelectList(_ForestBeatService.ListByForestRange(result.entity.ForestRangeId ?? 0).entity ?? new List<ForestBeatVM>(), "Id", "Name", result.entity.ForestBeatId ?? 0);

            var fcvVcfList = _ForestFcvVcfService.ListByForestBeat(result.entity.ForestBeatId ?? 0).entity ?? new List<ForestFcvVcfVM>();
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcvVcfList, result.entity.ForestFcvVcfId));
            ViewBag.ForestFcvVcfId = new SelectList(fcvVcfList, "Id", "Name", result.entity.ForestFcvVcfId ?? 0);

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name", result.entity.DivisionId);
            ViewBag.DistrictId = new SelectList(_DistrictService.ListByDivision(result.entity.DivisionId ?? 0).entity ?? new List<DistrictVM>(), "Id", "Name", result.entity.DistrictId ?? 0);
            ViewBag.UpazillaId = new SelectList(_UpazillaService.ListByDistrict(result.entity.DistrictId ?? 0).entity ?? new List<UpazillaVM>(), "Id", "Name", result.entity.UpazillaId ?? 0);
            ViewBag.UnionId = new SelectList(_UnionService.ListByUpazilla(result.entity.UpazillaId ?? 0).entity ?? new List<UnionVM>(), "Id", "Name", result.entity.UnionId ?? 0);

            ViewBag.UserRoleId = new SelectList(_userRoleService.List().entity ?? new List<UserRoleVM>(), "Id", "RoleName", result.entity.UserRoleId);
            return View(result.entity);
        }

        // POST: Account/UserEdit/5
        [HttpPost]
        public ActionResult UserEdit(int id, UserVM entity)
        {
            try
            {
                List<PmsGroupViewModel> group = new List<PmsGroupViewModel>();
                group = GroupList();
                ViewBag.GroupList = new SelectList(GroupList(), "Id", "GroupName", entity.PmsGroupID);

                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(AccountController.UserLists), "Account");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;

                    (ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.Update(entity);
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        if (entity.SurveyId > 0)
                            return RedirectToAction("UserLists");
                        else
                            return RedirectToAction("BeneficiaryUser");
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: Account/UserDelete/5
        public JsonResult UserDelete(int id)
        {
            (ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "User deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
            //return View();
        }


        public List<PmsGroupViewModel> GroupList()
        {


            (ExecutionState executionState, List<PmsGroupVM> entity, string message) returnPmsGroupResponse = _PmsGroupService.List();

            List<PmsGroupViewModel> result = returnPmsGroupResponse.entity.Where(c => c.IsActive == true && c.IsVisible != 1).Select(c => new PmsGroupViewModel
            {
                Id = c.Id,
                GroupName = c.GroupName
            }).ToList();
            //var accessList = _PmsGroupService.GetAll()
            //.Select(g => new PmsGroupViewModel
            //{
            //    GroupID = g.GroupID,
            //    GroupName = g.GroupName

            //}).ToList();

            return result;
        }

        //
        // GET: /Account/ConfirmEmail
        //[AllowAnonymous]
        //public async Task<ActionResult> ConfirmEmail(string userId, string code)
        //{
        //	if (userId == null || code == null)
        //	{
        //		return View("Error");
        //	}
        //	var result = await UserManager.ConfirmEmailAsync(userId, code);
        //	return View(result.Succeeded ? "ConfirmEmail" : "Error");
        //}

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //	if (ModelState.IsValid)
        //	{
        //		var user = await UserManager.FindByNameAsync(model.Email);
        //		if (user == null || !await UserManager.IsEmailConfirmedAsync(user.Id))
        //		{
        //			// Don't reveal that the user does not exist or is not confirmed
        //			return View("ForgotPasswordConfirmation");
        //		}

        //		// For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
        //		// Send an email with this link
        //		// string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
        //		// var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //		// await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
        //		// return RedirectToAction("ForgotPasswordConfirmation", "Account");
        //	}

        //	// If we got this far, something failed, redisplay form
        //	return View(model);
        //}

        //
        // GET: /Account/ForgotPasswordConfirmation
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return View(model);
        //	}
        //	var user = await UserManager.FindByNameAsync(model.Email);
        //	if (user == null)
        //	{
        //		// Don't reveal that the user does not exist
        //		return RedirectToAction("ResetPasswordConfirmation", "Account");
        //	}
        //	var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
        //	if (result.Succeeded)
        //	{
        //		return RedirectToAction("ResetPasswordConfirmation", "Account");
        //	}
        //	AddErrors(result);
        //	return View();
        //}

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //	// Request a redirect to the external login provider
        //	return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        //}

        //
        // GET: /Account/SendCode
        //[AllowAnonymous]
        //public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        //{
        //	var userId = await SignInManager.GetVerifiedUserIdAsync();
        //	if (userId == null)
        //	{
        //		return View("Error");
        //	}
        //	var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
        //	var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
        //	return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}

        //
        // POST: /Account/SendCode
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SendCode(SendCodeViewModel model)
        //{
        //	if (!ModelState.IsValid)
        //	{
        //		return View();
        //	}

        //	// Generate the token and send it
        //	if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
        //	{
        //		return View("Error");
        //	}
        //	return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, model.ReturnUrl, model.RememberMe });
        //}

        //
        // GET: /Account/ExternalLoginCallback
        //[AllowAnonymous]
        //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //	var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        //	if (loginInfo == null)
        //	{
        //		return RedirectToAction("Login");
        //	}

        //	// Sign in the user with this external login provider if the user already has a login
        //	var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
        //	switch (result)
        //	{
        //		case SignInStatus.Success:
        //			return RedirectToLocal(returnUrl);
        //		case SignInStatus.LockedOut:
        //			return View("Lockout");
        //		case SignInStatus.RequiresVerification:
        //			return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
        //		case SignInStatus.Failure:
        //		default:
        //			// If the user does not have an account, then prompt the user to create an account
        //			ViewBag.ReturnUrl = returnUrl;
        //			ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
        //			return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        //	}
        //}

        //
        // POST: /Account/ExternalLoginConfirmation
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        //{
        //	if (User.Identity.IsAuthenticated)
        //	{
        //		return RedirectToAction("Index", "Manage");
        //	}

        //	if (ModelState.IsValid)
        //	{
        //		// Get the information about the user from the external login provider
        //		var info = await AuthenticationManager.GetExternalLoginInfoAsync();
        //		if (info == null)
        //		{
        //			return View("ExternalLoginFailure");
        //		}
        //		var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //		var result = await UserManager.CreateAsync(user);
        //		if (result.Succeeded)
        //		{
        //			result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //			if (result.Succeeded)
        //			{
        //				await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //				return RedirectToLocal(returnUrl);
        //			}
        //		}
        //		AddErrors(result);
        //	}

        //	ViewBag.ReturnUrl = returnUrl;
        //	return View(model);
        //}

        public ActionResult LogOff()
        {
            //Session["UserEmail"] = string.Empty;
            //MySession.Current.Token = string.Empty;
            //Session.Abandon();
            //Session.Clear();
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            ////return Json(true,SerializerOption.Default);
            //return RedirectToAction("Login", "Account");

            //Session["UserEmail"] = string.Empty;
            HttpContext.Session.Clear();

            //MySession.Current.Token = string.Empty;
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        ////
        //// POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    //Session["UserEmail"] = string.Empty;
        //	HttpContext.Session.Clear();

        //    //MySession.Current.Token = string.Empty;
        //    //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return RedirectToAction("Login", "Account");
        //}

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        //protected override void Dispose(bool disposing)
        //{
        //	if (disposing)
        //	{
        //		if (_userManager != null)
        //		{
        //			_userManager.Dispose();
        //			_userManager = null;
        //		}

        //		if (_signInManager != null)
        //		{
        //			_signInManager.Dispose();
        //			_signInManager = null;
        //		}
        //	}

        //	base.Dispose(disposing);
        //}

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        //private IAuthenticationManager AuthenticationManager
        //{
        //	get
        //	{
        //		return HttpContext.GetOwinContext().Authentication;
        //	}
        //}

        //private void AddErrors(IdentityResult result)
        //{
        //	foreach (var error in result.Errors)
        //	{
        //		ModelState.AddModelError("", error);
        //	}
        //}

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //	if (Url.IsLocalUrl(returnUrl))
        //	{
        //		return Redirect(returnUrl);
        //	}
        //	return RedirectToAction("Index", "Home");
        //}

        //internal class ChallengeResult : HttpUnauthorizedResult
        //{
        //	public ChallengeResult(string provider, string redirectUri)
        //		: this(provider, redirectUri, null)
        //	{
        //	}

        //	public ChallengeResult(string provider, string redirectUri, string userId)
        //	{
        //		LoginProvider = provider;
        //		RedirectUri = redirectUri;
        //		UserId = userId;
        //	}

        //	public string LoginProvider { get; set; }
        //	public string RedirectUri { get; set; }
        //	public string UserId { get; set; }

        //	public override void ExecuteResult(ControllerContext context)
        //	{
        //		var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
        //		if (UserId != null)
        //		{
        //			properties.Dictionary[XsrfKey] = UserId;
        //		}
        //		context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        //	}
        //}
        #endregion

        public ActionResult BeneficiaryUser()
        {
            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name");
            ViewBag.ForestDivisionId = new SelectList("");
            ViewBag.ForestRangeId = new SelectList("");
            ViewBag.ForestBeatId = new SelectList("");
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name");
            ViewBag.ForestFcvVcfId = new SelectList("");

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
            ViewBag.DistrictId = new SelectList("");
            ViewBag.UpazillaId = new SelectList("");
            ViewBag.UnionId = new SelectList("");

            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.PhoneNumber = string.Empty;
            ViewBag.NID = string.Empty;

            var result = _UserService.ListSurveyAccounts(50);

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult BeneficiaryUserFilter(BeneficiaryUserFilterVM filter)
        {
            filter.IsBeneficiaryUser = true;

            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", filter.ForestCircleId ?? 0);
            ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(filter.ForestCircleId ?? 0).entity ?? new List<ForestDivisionVM>(), "Id", "Name", filter.ForestCircleId ?? 0);
            ViewBag.ForestRangeId = new SelectList(_ForestRangeService.ListByForestDivision(filter.ForestDivisionId ?? 0).entity ?? new List<ForestRangeVM>(), "Id", "Name", filter.ForestDivisionId ?? 0);
            ViewBag.ForestBeatId = new SelectList(_ForestBeatService.ListByForestRange(filter.ForestRangeId ?? 0).entity ?? new List<ForestBeatVM>(), "Id", "Name", filter.ForestRangeId ?? 0);

            var fcvVcfList = _ForestFcvVcfService.ListByForestBeat(filter.ForestBeatId ?? 0).entity ?? new List<ForestFcvVcfVM>();
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcvVcfList, filter.ForestFcvVcfId));
            ViewBag.ForestFcvVcfId = new SelectList(fcvVcfList, "Id", "Name", filter.ForestBeatId ?? 0);

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name", filter.DivisionId ?? 0);
            ViewBag.DistrictId = new SelectList(_DistrictService.ListByDivision(filter.DivisionId ?? 0).entity ?? new List<DistrictVM>(), "Id", "Name", filter.DivisionId ?? 0);
            ViewBag.UpazillaId = new SelectList(_UpazillaService.ListByDistrict(filter.DistrictId ?? 0).entity ?? new List<UpazillaVM>(), "Id", "Name", filter.DistrictId ?? 0);
            ViewBag.UnionId = new SelectList(_UnionService.ListByUpazilla(filter.UpazillaId ?? 0).entity ?? new List<UnionVM>(), "Id", "Name", filter.UnionId ?? 0);

            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.HasGender ? (int)filter.Gender! : -1);
            ViewBag.PhoneNumber = filter.PhoneNumber;
            ViewBag.NID = filter.NID;

            (ExecutionState executionState, List<UserVM> entity, string message) returnResponse = _UserService.GetBeneficiaryByFilter(filter);

            return View("BeneficiaryUser", returnResponse.entity);
        }

        [HttpPost]
        public ActionResult GenerateSurveyAccounts(ForestCivilLocationFilter filter)
        {
            var result = _UserService.GenerateSurveyAccounts(filter);

            return Json(
                new { Success = result.executionState == ExecutionState.Created, Message = result.message, Data = result.entity },
                SerializerOption.Default);
        }

        public ActionResult BeneficiaryUserEdit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, UserVM entity, string message) result = _UserService.GetById(id);

            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", result.entity.ForestCircleId ?? 0);
            ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(result.entity.ForestCircleId ?? 0).entity ?? new List<ForestDivisionVM>(), "Id", "Name", result.entity.ForestDivisionId ?? 0);
            ViewBag.ForestRangeId = new SelectList(_ForestRangeService.ListByForestDivision(result.entity.ForestDivisionId ?? 0).entity ?? new List<ForestRangeVM>(), "Id", "Name", result.entity.ForestRangeId ?? 0);
            ViewBag.ForestBeatId = new SelectList(_ForestBeatService.ListByForestRange(result.entity.ForestRangeId ?? 0).entity ?? new List<ForestBeatVM>(), "Id", "Name", result.entity.ForestBeatId ?? 0);

            var fcvVcfList = _ForestFcvVcfService.ListByForestBeat(result.entity.ForestBeatId ?? 0).entity ?? new List<ForestFcvVcfVM>();
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcvVcfList, result.entity.ForestFcvVcfId));
            ViewBag.ForestFcvVcfId = new SelectList(fcvVcfList, "Id", "Name", result.entity.ForestFcvVcfId ?? 0);

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name", result.entity.DivisionId);
            ViewBag.DistrictId = new SelectList(_DistrictService.ListByDivision(result.entity.DivisionId ?? 0).entity ?? new List<DistrictVM>(), "Id", "Name", result.entity.DistrictId ?? 0);
            ViewBag.UpazillaId = new SelectList(_UpazillaService.ListByDistrict(result.entity.DistrictId ?? 0).entity ?? new List<UpazillaVM>(), "Id", "Name", result.entity.UpazillaId ?? 0);
            ViewBag.UnionId = new SelectList(_UnionService.ListByUpazilla(result.entity.UpazillaId ?? 0).entity ?? new List<UnionVM>(), "Id", "Name", result.entity.UnionId ?? 0);

            ViewBag.GroupList = new SelectList(GroupList(), "Id", "GroupName", result.entity.PmsGroupID);

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult ListNotHasAccountIncluding(ForestCivilLocationFilter filter)
        {
            var result = _SurveyService.ListNotHasAccountIncluding(filter);

            return Json(
                new { Success = result.executionState == ExecutionState.Retrieved, Message = result.message, Data = result.entity },
                SerializerOption.Default);
        }

        public ActionResult BeneficiaryUserRegister()
        {
            ViewBag.SurveyId = new SelectList("");

            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name");
            ViewBag.ForestDivisionId = new SelectList("");
            ViewBag.ForestRangeId = new SelectList("");
            ViewBag.ForestBeatId = new SelectList("");

            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name");
            ViewBag.ForestFcvVcfId = new SelectList("");

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
            ViewBag.DistrictId = new SelectList("");
            ViewBag.UpazillaId = new SelectList("");
            ViewBag.UnionId = new SelectList("");

            ViewBag.PmsGroupID = new SelectList(GroupList(), "Id", "GroupName", (int)PmsGroupID.BeneficiaryGroup);

            return View(new UserVM());
        }



        // Map To Account into User
        public ActionResult UserMapToAccount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, UserVM entity, string message) result = _UserService.GetById(id);

            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", result.entity.ForestCircleId ?? 0);
            ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(result.entity.ForestCircleId ?? 0).entity ?? new List<ForestDivisionVM>(), "Id", "Name", result.entity.ForestDivisionId ?? 0);
            ViewBag.ForestRangeId = new SelectList(_ForestRangeService.ListByForestDivision(result.entity.ForestDivisionId ?? 0).entity ?? new List<ForestRangeVM>(), "Id", "Name", result.entity.ForestRangeId ?? 0);
            ViewBag.ForestBeatId = new SelectList(_ForestBeatService.ListByForestRange(result.entity.ForestRangeId ?? 0).entity ?? new List<ForestBeatVM>(), "Id", "Name", result.entity.ForestBeatId ?? 0);

            var fcvVcfList = _ForestFcvVcfService.ListByForestBeat(result.entity.ForestBeatId ?? 0).entity ?? new List<ForestFcvVcfVM>();
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcvVcfList, result.entity.ForestFcvVcfId));
            ViewBag.ForestFcvVcfId = new SelectList(fcvVcfList, "Id", "Name", result.entity.ForestFcvVcfId ?? 0);

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name", result.entity.DivisionId);
            ViewBag.DistrictId = new SelectList(_DistrictService.ListByDivision(result.entity.DivisionId ?? 0).entity ?? new List<DistrictVM>(), "Id", "Name", result.entity.DistrictId ?? 0);
            ViewBag.UpazillaId = new SelectList(_UpazillaService.ListByDistrict(result.entity.DistrictId ?? 0).entity ?? new List<UpazillaVM>(), "Id", "Name", result.entity.UpazillaId ?? 0);
            ViewBag.UnionId = new SelectList(_UnionService.ListByUpazilla(result.entity.UpazillaId ?? 0).entity ?? new List<UnionVM>(), "Id", "Name", result.entity.UnionId ?? 0);

            ViewBag.UserRoleId = new SelectList(_userRoleService.List().entity ?? new List<UserRoleVM>(), "Id", "RoleName", result.entity.UserRoleId);

            //New Info
            var filter = new AccountFilterVM();
            filter.ForestCircleId = result.entity.ForestCircleId ?? 0;
            filter.ForestDivisionId = result.entity.ForestDivisionId ?? 0;
            filter.ForestRangeId = result.entity.ForestRangeId ?? 0;
            filter.ForestBeatId = result.entity.ForestBeatId ?? 0;
            filter.ForestFcvVcfId = result.entity.ForestFcvVcfId ?? 0;

            (ExecutionState executionState, PaginationResutlVM<AccountVM> entity, string message) returnResponseAccount = _AccountService.GetByFilter(filter);
            foreach (var accountInfo in returnResponseAccount.entity.aaData)
            {
                accountInfo.AccountFullInformation = accountInfo.BankName + ", " + accountInfo.BankAccountName + ", " + accountInfo.AccountNumber + ", " + accountInfo?.CommitteeType?.CommitteeTypeName + ", " + accountInfo?.Committee?.CommitteeName;
            }

            ViewBag.AccountsId = new SelectList(new List<AccountVM>(), "Id", "AccountFullInformation");

            //if (returnResponseAccount.entity != null)
            //{
            //    ViewBag.AccountsId = new SelectList(returnResponseAccount.entity ?? new List<AccountVM>(), "Id", "AccountFullInformation", result.entity.AccountsId ?? 0);
            //}

            return View(result.entity);
        }



        // POST: Account/UserMapToAccount/5
        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult UserMapToAccount(UserVM entity)
        {
            try
            {
                List<PmsGroupViewModel> group = new List<PmsGroupViewModel>();
                group = GroupList();
                ViewBag.GroupList = new SelectList(GroupList(), "Id", "GroupName", entity.PmsGroupID);

                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;

                    entity.BankAccountsInformations = JsonConvert.DeserializeObject<List<BankAccountsInformationVM>>(entity.AccountsInformationsJson);

                    (ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.Update(entity);

                    if (returnResponse.executionState == ExecutionState.Updated)
                    {
                        foreach (var item in entity.BankAccountsInformations ?? new List<BankAccountsInformationVM>())
                        {
                            var logInfo = new AccountsUserTagLogVM
                            {
                                AccountsId = item.AccountId,
                                UserId = entity.Id,
                                CreatedDate = DateTime.Now,
                            };

                            (ExecutionState executionState, AccountsUserTagLogVM entity, string message) returnResponseLog = _AccountsUserTagLogService.Create(logInfo);
                        }
                    }

                    return Json(new
                    {
                        Success = returnResponse.executionState == ExecutionState.Updated,
                        Data = returnResponse.entity,
                        Message = returnResponse.message
                    }, SerializerOption.Default);
                }

                return Json(new
                {
                    Success = ExecutionState.Failure,
                    Data = new {},
                    Message = ModelState.FirstErrorMessage()
                }, SerializerOption.Default);
            }
            catch
            {
                return Json(new
                {
                    Success = ExecutionState.Failure,
                    Data = new {},
                    Message = "Unexpected error occurred"
                }, SerializerOption.Default);
            }
        }

        public ActionResult GetAccountInfoByAccountId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, AccountVM entity, string message) returnResponseAccount = _AccountService.GetById(id);

            //return View(returnResponseAccount.entity);

            return Json(
                 new
                 {
                     Success = "",
                     Data = returnResponseAccount.entity,
                     Message = ""
                 },
                 SerializerOption.Default);
        }


        public ActionResult GetAccountInformationByFilter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, UserVM entity, string message) result = _UserService.GetById(id);

            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", result.entity.ForestCircleId ?? 0);
            ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(result.entity.ForestCircleId ?? 0).entity ?? new List<ForestDivisionVM>(), "Id", "Name", result.entity.ForestDivisionId ?? 0);
            ViewBag.ForestRangeId = new SelectList(_ForestRangeService.ListByForestDivision(result.entity.ForestDivisionId ?? 0).entity ?? new List<ForestRangeVM>(), "Id", "Name", result.entity.ForestRangeId ?? 0);
            ViewBag.ForestBeatId = new SelectList(_ForestBeatService.ListByForestRange(result.entity.ForestRangeId ?? 0).entity ?? new List<ForestBeatVM>(), "Id", "Name", result.entity.ForestBeatId ?? 0);

            var fcvVcfList = _ForestFcvVcfService.ListByForestBeat(result.entity.ForestBeatId ?? 0).entity ?? new List<ForestFcvVcfVM>();
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcvVcfList, result.entity.ForestFcvVcfId));
            ViewBag.ForestFcvVcfId = new SelectList(fcvVcfList, "Id", "Name", result.entity.ForestFcvVcfId ?? 0);

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name", result.entity.DivisionId);
            ViewBag.DistrictId = new SelectList(_DistrictService.ListByDivision(result.entity.DivisionId ?? 0).entity ?? new List<DistrictVM>(), "Id", "Name", result.entity.DistrictId ?? 0);
            ViewBag.UpazillaId = new SelectList(_UpazillaService.ListByDistrict(result.entity.DistrictId ?? 0).entity ?? new List<UpazillaVM>(), "Id", "Name", result.entity.UpazillaId ?? 0);
            ViewBag.UnionId = new SelectList(_UnionService.ListByUpazilla(result.entity.UpazillaId ?? 0).entity ?? new List<UnionVM>(), "Id", "Name", result.entity.UnionId ?? 0);

            ViewBag.UserRoleId = new SelectList(_userRoleService.List().entity ?? new List<UserRoleVM>(), "Id", "RoleName", result.entity.UserRoleId);

            //New Info
            var filter = new AccountFilterVM();
            filter.ForestCircleId = result.entity.ForestCircleId ?? 0;
            filter.ForestDivisionId = result.entity.ForestDivisionId ?? 0;
            filter.ForestRangeId = result.entity.ForestRangeId ?? 0;
            filter.ForestBeatId = result.entity.ForestBeatId ?? 0;
            filter.ForestFcvVcfId = result.entity.ForestFcvVcfId ?? 0;

            (ExecutionState executionState, PaginationResutlVM<AccountVM> entity, string message) returnResponseAccount = _AccountService.GetByFilter(filter);
            foreach (var accountInfo in returnResponseAccount.entity.aaData)
            {
                accountInfo.AccountFullInformation = accountInfo.BankName + ", " + accountInfo.BankAccountName + ", " + accountInfo.AccountNumber + ", " + accountInfo?.CommitteeType?.CommitteeTypeName + ", " + accountInfo?.Committee?.CommitteeName;
            }

            //if (returnResponseAccount.entity != null)
            //{
            //    ViewBag.AccountsId = new SelectList(returnResponseAccount.entity ?? new List<AccountVM>(), "Id", "AccountFullInformation", result.entity.AccountsId ?? 0);
            //}

            //return View(result.entity);

            return Json(
                 new
                 {
                     Success = "",
                     Data = returnResponseAccount.entity.aaData,
                     Message = ""
                 },
                 SerializerOption.Default);
        }

        // Bank Accounts Information
        public ActionResult GetBankAccountsInformationByUserId(long? userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, List<BankAccountsInformationVM> entity, string message) result = _BankAccountsInformationService.GetBankAccountsInformationByUserId(userId, null);

            return Json(
                 new
                 {
                     Success = result.executionState == ExecutionState.Retrieved,
                     Data = result.entity ?? new List<BankAccountsInformationVM>(),
                     Message = result.message
                 },
                 SerializerOption.Default);
        }


        public ActionResult DeleteByBankAccountsInformationId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, BankAccountsInformationVM entity, string message) result = _BankAccountsInformationService.Delete(id);
            //return View();

            return Json(
                 new
                 {
                     Success = result.executionState == ExecutionState.Retrieved,
                     Data = result.entity ?? new BankAccountsInformationVM(),
                     Message = result.message
                 },
                 SerializerOption.Default);
        }



        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, UserVM entity, string message) result = _UserService.GetById(id);

            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", result.entity.ForestCircleId ?? 0);
            ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(result.entity.ForestCircleId ?? 0).entity ?? new List<ForestDivisionVM>(), "Id", "Name", result.entity.ForestDivisionId ?? 0);
            ViewBag.ForestRangeId = new SelectList(_ForestRangeService.ListByForestDivision(result.entity.ForestDivisionId ?? 0).entity ?? new List<ForestRangeVM>(), "Id", "Name", result.entity.ForestRangeId ?? 0);
            ViewBag.ForestBeatId = new SelectList(_ForestBeatService.ListByForestRange(result.entity.ForestRangeId ?? 0).entity ?? new List<ForestBeatVM>(), "Id", "Name", result.entity.ForestBeatId ?? 0);

            var fcvVcfList = _ForestFcvVcfService.ListByForestBeat(result.entity.ForestBeatId ?? 0).entity ?? new List<ForestFcvVcfVM>();
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcvVcfList, result.entity.ForestFcvVcfId));
            ViewBag.ForestFcvVcfId = new SelectList(fcvVcfList, "Id", "Name", result.entity.ForestFcvVcfId ?? 0);

            ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name", result.entity.DivisionId);
            ViewBag.DistrictId = new SelectList(_DistrictService.ListByDivision(result.entity.DivisionId ?? 0).entity ?? new List<DistrictVM>(), "Id", "Name", result.entity.DistrictId ?? 0);
            ViewBag.UpazillaId = new SelectList(_UpazillaService.ListByDistrict(result.entity.DistrictId ?? 0).entity ?? new List<UpazillaVM>(), "Id", "Name", result.entity.UpazillaId ?? 0);
            ViewBag.UnionId = new SelectList(_UnionService.ListByUpazilla(result.entity.UpazillaId ?? 0).entity ?? new List<UnionVM>(), "Id", "Name", result.entity.UnionId ?? 0);

            ViewBag.UserRoleId = new SelectList(_userRoleService.List().entity ?? new List<UserRoleVM>(), "Id", "RoleName", result.entity.UserRoleId);
            return View(result.entity);
        }

        public ActionResult GetUserInfoByUserRoleId(long userRoleId)
        {
            if (userRoleId == default)
            {
                return Json(
                     new
                     {
                         Success = false,
                         Message = "Invalid user role id"
                     },
                     SerializerOption.Default);
            }

            var result = _AccountService.GetUserInfoByUserRoleId(userRoleId);

            return Json(
                 new
                 {
                     Success = result.executionState == ExecutionState.Success,
                     Data = result.entity ?? new List<UserVM>(),
                     Message = result.message
                 },
                 SerializerOption.Default);
        }
    }
}
