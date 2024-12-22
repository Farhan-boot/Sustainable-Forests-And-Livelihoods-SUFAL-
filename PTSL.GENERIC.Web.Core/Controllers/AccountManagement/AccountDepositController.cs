using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.AccountManagement;

[SessionAuthorize]
public class AccountDepositController : Controller
{
    private const string ControllerName = "AccountDeposit";

    private readonly IAccountDepositService _accountDepositService;
    private readonly IAccountService _accountService;
    private readonly IFinancialYearService _financialYearService;
    private readonly ISourceOfFundService _sourceOfFundService;

    private readonly ICommitteeTypeConfigurationService _committeeTypeConfigurationService;
    private readonly ICommitteesConfigurationService _committeesConfigurationService;

    private readonly IForestCircleService _forestCircleService;
    private readonly IForestDivisionService _forestDivisionService;
    private readonly IForestRangeService _forestRangeService;
    private readonly IForestBeatService _forestBeatService;
    private readonly IForestFcvVcfService _forestFcvVcfService;

    private readonly IDivisionService _divisionService;
    private readonly IDistrictService _districtService;
    private readonly IUpazillaService _upazillaService;
    private readonly IUnionService _unionService;
    private readonly IAccountsUserTagLogService _accountsUserTagLogService;
    private readonly IPermissionHeaderSettingsService _permissionHeaderSettingsService;
    private readonly IPermissionRowSettingsService _permissionRowSettingsService;
    private readonly IUserRoleService _userRoleService;

    public AccountDepositController(HttpHelper httpHelper)
    {
        _accountDepositService = new AccountDepositService(httpHelper);
        _accountService = new AccountService(httpHelper);
        _financialYearService = new FinancialYearService(httpHelper);
        _sourceOfFundService = new SourceOfFundService(httpHelper);

        _committeeTypeConfigurationService = new CommitteeTypeConfigurationService(httpHelper);
        _committeesConfigurationService = new CommitteesConfigurationService(httpHelper);

        _forestCircleService = new ForestCircleService(httpHelper);
        _forestDivisionService = new ForestDivisionService(httpHelper);
        _forestRangeService = new ForestRangeService(httpHelper);
        _forestBeatService = new ForestBeatService(httpHelper);
        _forestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _divisionService = new DivisionService(httpHelper);
        _districtService = new DistrictService(httpHelper);
        _upazillaService = new UpazillaService(httpHelper);
        _unionService = new UnionService(httpHelper);
        _accountsUserTagLogService = new AccountsUserTagLogService(httpHelper);
        _permissionRowSettingsService = new PermissionRowSettingsService(httpHelper);
        _userRoleService = new UserRoleService(httpHelper);
        _permissionHeaderSettingsService = new PermissionHeaderSettingsService(httpHelper);
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

        ViewBag.CommitteeTypeId = new SelectList("");
        ViewBag.CommitteeId = new SelectList("");

        return View(_accountDepositService.List().entity ?? new List<AccountDepositVM>());
    }

    public ActionResult CashIn()
    {
        return View(_accountDepositService.ListForCashIn().entity ?? new List<AccountDepositVM>());
    }

    public ActionResult RequestList()
    {
        var result = _permissionRowSettingsService.GetPermissionRowsByControllerName(ControllerName);
        if (result.executionState != ExecutionState.Success)
        {
            return View(new List<AccountDepositVM>());
        }

        var permissionRowsList = result.entity ?? new List<Model.EntityViewModels.PermissionSettings.PermissionRowSettingsVM>();
        if (permissionRowsList.Count == 0)
        {
            return View(new List<AccountDepositVM>());
        }

        _ = long.TryParse(HttpContext.Session.GetString(SessionKey.UserRoleId), out var currentUserRoleId);

        var roleIds = permissionRowsList.Where(x => x.UserRoleId != currentUserRoleId).Select(x => x.UserRoleId);
        var rows = _userRoleService.GetRolesByIds(roleIds).entity ?? new List<Model.EntityViewModels.SystemUser.UserRoleVM>();

        ViewBag.PermissionRowsList = permissionRowsList;
        ViewBag.NextRequestedUserRoleId = new SelectList(rows, "Id", "RoleName");
        ViewBag.NextRequestedUserId = new SelectList("");

        var permissionHeaderSettingsId = permissionRowsList.First().PermissionHeaderSettingsId;

        return View(_accountDepositService.ListForRequestList(permissionHeaderSettingsId).entity ?? new List<AccountDepositVM>());
    }

    [HttpPost]
    public ActionResult ForwardApproval(AccountDepositForwardRequestVM model)
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

            var (executionState, message) = _accountDepositService.ForwardApproval(model);
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

    public ActionResult LastStageApproval(long accountDepositId)
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

            var (executionState, message) = _accountDepositService.LastStageApproval(accountDepositId, result.entity);
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

    /*
    [HttpPost]
    public ActionResult IndexFilter(AccountFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForest(
            HttpContext,
            ViewBag,
            _forestCircleService,
            _forestDivisionService,
            _forestRangeService,
            _forestBeatService,
            _forestFcvVcfService,

            filter.ForestCircleId,
            filter.ForestDivisionId,
            filter.ForestRangeId,
            filter.ForestBeatId,
            filter.ForestFcvVcfId
        );

        ViewBag.CommitteeTypeId = new SelectList(_committeeTypeConfigurationService.List().entity ?? new List<CommitteeTypeConfigurationVM>(), "Id", "CommitteeTypeName", filter?.CommitteeTypeId ?? 0);
        ViewBag.CommitteeId = new SelectList(_committeesConfigurationService.GetCommitteesConfigurationByCommitteeTypeConfigurationId(filter?.CommitteeTypeId ?? 0).entity ?? new List<CommitteesConfigurationVM>(), "Id", "CommitteeName", filter?.CommitteeId ?? 0);
        ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name");
        ViewBag.AccountNumber = filter?.AccountNumber ?? string.Empty;
        ViewBag.BankAccountName = filter?.BankAccountName ?? string.Empty;

        var (_, entity, _) = _accountDepositService.GetByFilter(filter ?? new AccountFilterVM());
        return View("Index", entity);
    }
    */

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var returnResponse = _accountDepositService.GetDetails(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
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
        ViewBag.AccountId = new SelectList("");
        ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
        ViewBag.SourceOfFundId = new SelectList(_sourceOfFundService.List().entity ?? new List<SourceOfFundVM>(), "Id", "Name");

        return View(new AccountDepositVM());
    }

    [HttpPost]
    public ActionResult Create(AccountDepositVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var result = _permissionHeaderSettingsService.GetPermissionHeaderIdByControllerName(ControllerName);
                if (result.executionState != ExecutionState.Success)
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
                    ViewBag.AccountId = new SelectList("");
                    ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
                    ViewBag.SourceOfFundId = new SelectList(_sourceOfFundService.List().entity ?? new List<SourceOfFundVM>(), "Id", "Name");

                    HttpContext.Session.SetString("Message", "Not permission settings found");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }

                var returnResponse = _accountDepositService.Create(entity, result.entity);
                if (returnResponse.executionState != ExecutionState.Created)
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    AuthLocationHelper.GenerateViewBagForForest(
                        HttpContext,
                        ViewBag,
                        _forestCircleService,
                        _forestDivisionService,
                        _forestRangeService,
                        _forestBeatService,
                        _forestFcvVcfService
                    );

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Account deposit has been created successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Create");
        }
        catch
        {
            return RedirectToAction("Create");
        }
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var result = _accountDepositService.GetById(id);
        if (result.entity is null)
        {
            HttpContext.Session.SetString("Message", "Account deposit information not found");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Index");
        }

        var accountForestCircle = result.entity.Account?.ForestCircleId ?? 0;
        var accountForestDivision = result.entity.Account?.ForestDivisionId ?? 0;
        var accountForestRange = result.entity.Account?.ForestRangeId ?? 0;
        var accountForestBeat = result.entity.Account?.ForestBeatId ?? 0;
        var accountForestFcvVcf = result.entity.Account?.ForestFcvVcfId ?? 0;

        var committeeType = result.entity.Account?.CommitteeTypeId is not null ? _committeeTypeConfigurationService.List().entity ?? new List<CommitteeTypeConfigurationVM>() : new List<CommitteeTypeConfigurationVM>();
        var committee = result.entity.Account?.CommitteeId is not null ? _committeesConfigurationService.List().entity ?? new List<CommitteesConfigurationVM>() : new List<CommitteesConfigurationVM>();

        AuthLocationHelper.GenerateViewBagForForest(
            HttpContext,
            ViewBag,
            _forestCircleService,
            _forestDivisionService,
            _forestRangeService,
            _forestBeatService,
            _forestFcvVcfService,

            accountForestCircle,
            accountForestDivision,
            accountForestRange,
            accountForestBeat,
            accountForestFcvVcf
        );

        var accountList = _accountService.GetByFilter(new AccountFilterVM
        {
            ForestCircleId = accountForestCircle,
            ForestDivisionId = accountForestDivision,
            ForestRangeId = accountForestRange,
            ForestBeatId = accountForestBeat,
            ForestFcvVcfId = accountForestFcvVcf,
            CommitteeTypeId = result.entity.Account?.CommitteeTypeId ?? 0,
            CommitteeId = result.entity.Account?.CommitteeId ?? 0
        });

        ViewBag.CommitteeTypeId = new SelectList(committeeType, "Id", "CommitteeTypeName");
        ViewBag.CommitteeId = new SelectList(committee, "Id", "CommitteeName");
        ViewBag.AccountId = new SelectList(accountList.entity.aaData ?? new List<AccountVM>(), "Id", "AccountNumber", result.entity.AccountId);
        ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name", result.entity.FinancialYearId);
        ViewBag.SourceOfFundId = new SelectList(_sourceOfFundService.List().entity ?? new List<SourceOfFundVM>(), "Id", "Name", result.entity.SourceOfFundId);

        return View(result.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, AccountDepositVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var returnResponse = _accountDepositService.Update(entity);
                if (returnResponse.executionState.ToString() != "Updated")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    AuthLocationHelper.GenerateViewBagForForest(
                        HttpContext,
                        ViewBag,
                        _forestCircleService,
                        _forestDivisionService,
                        _forestRangeService,
                        _forestBeatService,
                        _forestFcvVcfService
                    );

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Account deposit information has been updated successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index");
                }
            }

            return View(entity);
        }
        catch
        {
            return View(entity);
        }
    }

    public ActionResult AcceptDeposit(long accountDepositId)
    {
        try
        {
            var (executionState, message) = _accountDepositService.AcceptDeposit(accountDepositId);
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

    public ActionResult CancelDeposit(long accountDepositId)
    {
        try
        {
            var (executionState, message) = _accountDepositService.CancelDeposit(accountDepositId);
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

    public JsonResult Delete(int id)
    {
        var result = _accountDepositService.Delete(id);
        if (result.entity != null)
        {
            result.message = "Item deleted successfully.";
        }
        else
        {
            result.message = "Failed to delete this item.";
        }

        return Json(new { Message = result.message, result.executionState }, SerializerOption.Default);
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

        ViewBag.CommitteeTypeId = new SelectList(_committeeTypeConfigurationService.List().entity ?? new List<CommitteeTypeConfigurationVM>(), "Id", "CommitteeTypeName", filter?.CommitteeTypeId ?? 0);
        ViewBag.CommitteeId = new SelectList(_committeesConfigurationService.GetCommitteesConfigurationByCommitteeTypeConfigurationId(filter?.CommitteeTypeId ?? 0).entity ?? new List<CommitteesConfigurationVM>(), "Id", "CommitteeName", filter?.CommitteeId ?? 0);
        //ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name");
        ViewBag.AccountNumber = filter?.AccountNumber ?? string.Empty;
        ViewBag.BankAccountName = filter?.BankAccountName ?? string.Empty;

        //ViewBag.CommitteeTypeId = new SelectList("");
        //ViewBag.CommitteeId = new SelectList("");
        var (_, entity, _) = _accountDepositService.ListByFilter(filter ?? new AccountFilterVM());
        return View("Index", entity.aaData);
    }



    //DataTable Get List using server site Pagination
    //[HttpPost]
    public ActionResult GetAccountDepositListByPagination(JqueryDatatableParam param)
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

        ViewBag.CommitteeTypeId = new SelectList("");
        ViewBag.CommitteeId = new SelectList("");

        var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext);
        filter.iDisplayStart = param.iDisplayStart;
        filter.iDisplayLength = param.iDisplayLength;
        filter.sSearch = param.sSearch;

        (ExecutionState executionState, PaginationResutlVM<AccountDepositVM> entity, string message) returnResponse = _accountDepositService.ListByFilter(filter);


        foreach (var item in returnResponse.entity.aaData)
        {
            item.DepositAmountBDText = item.DepositAmount.ToBDTCurrency();
            item.AccountDepositStatusText = item.AccountDepositStatus.GetEnumDisplayName();
            item.AccountDepositApprovalProcessText = item.AccountDepositApprovalProcess.GetEnumDisplayName();
        }


        return Json(new
        {
            param.sEcho,
            iTotalRecords = returnResponse.entity.iTotalRecords,
            iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
            aaData = returnResponse.entity.aaData
        }, SerializerOption.Default);

        //return View(new List<CommunityTrainingVM>());
    }


    [HttpPost]
    public ActionResult IndexFilterAccountDepositListByPagination(AccountFilterVM filter)
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

        ViewBag.CommitteeTypeId = new SelectList(_committeeTypeConfigurationService.List().entity ?? new List<CommitteeTypeConfigurationVM>(), "Id", "CommitteeTypeName", filter?.CommitteeTypeId ?? 0);
        ViewBag.CommitteeId = new SelectList(_committeesConfigurationService.GetCommitteesConfigurationByCommitteeTypeConfigurationId(filter?.CommitteeTypeId ?? 0).entity ?? new List<CommitteesConfigurationVM>(), "Id", "CommitteeName", filter?.CommitteeId ?? 0);
        //ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name");
        ViewBag.AccountNumber = filter?.AccountNumber ?? string.Empty;
        ViewBag.BankAccountName = filter?.BankAccountName ?? string.Empty;

        var (_, entity, _) = _accountDepositService.ListByFilter(filter ?? new AccountFilterVM());

        foreach (var item in entity.aaData)
        {
            item.DepositAmountBDText = item.DepositAmount.ToBDTCurrency();
            item.AccountDepositStatusText = item.AccountDepositStatus.GetEnumDisplayName();
            item.AccountDepositApprovalProcessText = item.AccountDepositApprovalProcess.GetEnumDisplayName();
        }


        return Json(new
        {
            //filter.sEcho,
            iTotalRecords = entity.iTotalRecords,
            iTotalDisplayRecords = entity.iTotalDisplayRecords,
            aaData = entity.aaData
        }, SerializerOption.Default);

        // return View("Index", result.entity);
    }



}
