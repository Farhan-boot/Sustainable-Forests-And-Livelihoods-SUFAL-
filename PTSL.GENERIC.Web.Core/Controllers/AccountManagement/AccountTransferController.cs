using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.AccountManagement;

[SessionAuthorize]
public class AccountTransferController : Controller
{
    private const string ControllerName = "AccountTransfer"; // If you change controller also change controller name here

    private readonly IFinancialYearService _financialYearService;
    private readonly ISourceOfFundService _sourceOfFundService;

    private readonly IAccountTransferService _accountTransferService;
    private readonly IForestCircleService _forestCircleService;
    private readonly IForestDivisionService _forestDivisionService;
    private readonly IForestRangeService _forestRangeService;
    private readonly IForestBeatService _forestBeatService;
    private readonly IForestFcvVcfService _forestFcvVcfService;

    private readonly IDivisionService _divisionService;
    private readonly IDistrictService _districtService;
    private readonly IUpazillaService _upazillaService;
    private readonly IUnionService _unionService;

    private readonly IBankAccountsInformationService _bankAccountsInformationService;
    private readonly IPermissionHeaderSettingsService _permissionHeaderSettingsService;
    private readonly IPermissionRowSettingsService _permissionRowSettingsService;
    private readonly IUserRoleService _userRoleService;

    public AccountTransferController(HttpHelper httpHelper)
    {
        _financialYearService = new FinancialYearService(httpHelper);
        _sourceOfFundService = new SourceOfFundService(httpHelper);

        _accountTransferService = new AccountTransferService(httpHelper);

        _forestCircleService = new ForestCircleService(httpHelper);
        _forestDivisionService = new ForestDivisionService(httpHelper);
        _forestRangeService = new ForestRangeService(httpHelper);
        _forestBeatService = new ForestBeatService(httpHelper);
        _forestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _divisionService = new DivisionService(httpHelper);
        _districtService = new DistrictService(httpHelper);
        _upazillaService = new UpazillaService(httpHelper);
        _unionService = new UnionService(httpHelper);

        _bankAccountsInformationService = new BankAccountsInformationService(httpHelper);
        _permissionHeaderSettingsService = new PermissionHeaderSettingsService(httpHelper);
        _permissionRowSettingsService = new PermissionRowSettingsService(httpHelper);
        _userRoleService = new UserRoleService(httpHelper);
    }

    public ActionResult Index()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _forestCircleService,
            _forestDivisionService,
            _forestRangeService,
            _forestBeatService,
            _forestFcvVcfService,
            _divisionService,
            _districtService,
            _upazillaService,
            _unionService
        );

        return View(_accountTransferService.List().entity ?? new List<AccountTransferVM>());
    }
    [HttpPost]
    public ActionResult IndexFilter(AccountFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
           HttpContext,
           ViewBag,
           _forestCircleService,
           _forestDivisionService,
           _forestRangeService,
           _forestBeatService,
           _forestFcvVcfService,
           //new
           _divisionService,
           _districtService,
           _upazillaService,
           _unionService,
           filter.ForestCircleId,
           filter.ForestDivisionId,
           filter.ForestRangeId,
           filter.ForestBeatId,
           filter.ForestFcvVcfId,
           //new
           filter.DivisionId,
           filter.DistrictId,
           filter.UpazillaId,
           filter.UnionId
       );


        var (_, entity, _) = _accountTransferService.ListByFilter(filter ?? new AccountFilterVM());
        return View("Index", entity);
    }


    public ActionResult CashIn()
    {
        return View(_accountTransferService.ListForCashIn().entity ?? new List<AccountTransferVM>());
    }

    public ActionResult RequestList()
    {
        var result = _permissionRowSettingsService.GetPermissionRowsByControllerName(ControllerName);
        if (result.executionState != ExecutionState.Success)
        {
            return View(new List<AccountTransferVM>());
        }

        var permissionRowsList = result.entity ?? new List<Model.EntityViewModels.PermissionSettings.PermissionRowSettingsVM>();
        if (permissionRowsList.Count == 0)
        {
            return View(new List<AccountTransferVM>());
        }

        _ = long.TryParse(HttpContext.Session.GetString(SessionKey.UserRoleId), out var currentUserRoleId);

        var roleIds = permissionRowsList.Where(x => x.UserRoleId != currentUserRoleId).Select(x => x.UserRoleId);
        var rows = _userRoleService.GetRolesByIds(roleIds).entity ?? new List<Model.EntityViewModels.SystemUser.UserRoleVM>();

        ViewBag.PermissionRowsList = permissionRowsList;
        ViewBag.NextRequestedUserRoleId = new SelectList(rows, "Id", "RoleName");
        ViewBag.NextRequestedUserId = new SelectList("");

        var permissionHeaderSettingsId = permissionRowsList.First().PermissionHeaderSettingsId;

        return View(_accountTransferService.ListForRequestList(permissionHeaderSettingsId).entity ?? new List<AccountTransferVM>());
    }

    [HttpPost]
    public ActionResult ForwardApproval(AccountForwardRequestVM model)
    {
        try
        {
            var result = _permissionHeaderSettingsService.GetPermissionHeaderIdByControllerName(ControllerName);
            if (result.executionState != ExecutionState.Success)
            {
                HttpContext.Session.SetString("Message", "Not permission settings found");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return RedirectToAction("RequestList");
            }

            model.PermissionHeaderSettingsId = result.entity;

            var (executionState, message) = _accountTransferService.ForwardApproval(model);
            if (executionState == ExecutionState.Success)
            {
                HttpContext.Session.SetString("Message", "Successfully forwarded for approval");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return RedirectToAction("RequestList");
            }

            HttpContext.Session.SetString("Message", message);
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("RequestList");
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("RequestList");
        }
    }

    public ActionResult LastStageApproval(long accountTransferId)
    {
        try
        {
            var result = _permissionHeaderSettingsService.GetPermissionHeaderIdByControllerName(ControllerName);
            if (result.executionState != ExecutionState.Success)
            {
                HttpContext.Session.SetString("Message", "Not permission settings found");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return RedirectToAction("RequestList");
            }

            var (executionState, message) = _accountTransferService.LastStageApproval(accountTransferId, result.entity);
            if (executionState == ExecutionState.Success)
            {
                HttpContext.Session.SetString("Message", "Approved successfully, waiting for user to accept");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return RedirectToAction("RequestList");
            }

            HttpContext.Session.SetString("Message", message);
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("RequestList");
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("RequestList");
        }
    }

    public ActionResult Transfer()
    {
        AuthLocationHelper.GenerateViewBagForForest(
            HttpContext,
            ViewBag,
            _forestCircleService,
            _forestDivisionService,
            _forestRangeService,
            _forestBeatService,
            _forestFcvVcfService
        );

        ViewBag.CommitteeTypeId = new SelectList("");
        ViewBag.CommitteeId = new SelectList("");
        ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
        ViewBag.SourceOfFundId = new SelectList(_sourceOfFundService.List().entity ?? new List<SourceOfFundVM>(), "Id", "Name");

        return View(new AccountTransferVM());
    }

    [HttpPost]
    public ActionResult Transfer(AccountTransferVM model)
    {
        try
        {
            var result = _permissionHeaderSettingsService.GetPermissionHeaderIdByControllerName(ControllerName);
            if (result.executionState != ExecutionState.Success)
            {
                return Json(new { Message = "No approval system is configured", Success = false }, SerializerOption.Default);
            }

            var (executionState, entity, message) = _accountTransferService.Transfer(model, result.entity);
            if (executionState == ExecutionState.Created)
            {
                HttpContext.Session.SetString("Message", "Account transfer request has been created successfully");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return Json(new { Message = "Transfer requested submitted successfully", Success = true }, SerializerOption.Default);
            }
            return Json(new { Message = message, Success = false }, SerializerOption.Default);
        }
        catch
        {
            return Json(new { Message = "Unexpected error occurred", Success = false }, SerializerOption.Default);
        }
    }

    public ActionResult AcceptTransfer(long accountTransferId)
    {
        try
        {
            var (executionState, message) = _accountTransferService.AcceptTransfer(accountTransferId);
            if (executionState == ExecutionState.Success)
            {
                HttpContext.Session.SetString("Message", "Successfully accepted transfer amount, check your account balance");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return Json(new { Message = "Transfer requested submitted successfully", Success = true }, SerializerOption.Default);
            }
            return Json(new { Message = message, Success = false }, SerializerOption.Default);
        }
        catch
        {
            return Json(new { Message = "Unexpected error occurred", Success = false }, SerializerOption.Default);
        }
    }

    public ActionResult CancelTransfer(long accountTransferId)
    {
        try
        {
            var (executionState, message) = _accountTransferService.CancelTransfer(accountTransferId);
            if (executionState == ExecutionState.Success)
            {
                HttpContext.Session.SetString("Message", "Successfully canceled transfer amount");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return Json(new { Message = "Cancelled successfully", Success = true }, SerializerOption.Default);
            }
            return Json(new { Message = message, Success = false }, SerializerOption.Default);
        }
        catch
        {
            return Json(new { Message = "Unexpected error occurred", Success = false }, SerializerOption.Default);
        }
    }

    public ActionResult Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }



        (ExecutionState executionState, AccountTransferVM entity, string message) result = _accountTransferService.GetById(id);
        if (result.executionState == ExecutionState.Retrieved)
        {

            return View(result.entity);
        }
        return BadRequest();
    }
}
