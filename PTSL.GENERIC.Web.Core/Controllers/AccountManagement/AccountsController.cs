using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.AccountManagement;

[SessionAuthorize]
public class AccountsController : Controller
{
    private readonly IAccountService _accountService;

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
    private readonly IBankAccountsInformationService _bankAccountsInformationService;

    public AccountsController(HttpHelper httpHelper)
    {
        _accountService = new AccountService(httpHelper);

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

        _bankAccountsInformationService = new BankAccountsInformationService(httpHelper);
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
        ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name");
        ViewBag.AccountNumber = string.Empty;
        ViewBag.BankAccountName = string.Empty;

        return View(_accountService.List().entity ?? new List<AccountVM>());
    }

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

        var (_, entity, _) = _accountService.GetByFilter(filter ?? new AccountFilterVM());
        return View("Index", entity.aaData);
    }

    [HttpPost]
    public ActionResult IndexFilterJson(AccountFilterVM filter)
    {
        var (_, data, message) = _accountService.GetByFilterBasic(filter ?? new AccountFilterVM());
        return Json(new { Message = message, Data = data }, SerializerOption.Default);
    }

    [HttpGet]
    public ActionResult GetCurrentBalance(long id)
    {
        var (_, data, message) = _accountService.GetCurrentBalance(id);
        return Json(new { Message = message, Data = data }, SerializerOption.Default);
    }

    [HttpGet]
    public ActionResult GetCurrentUserAccounts(AccountAllowedFundExpense? accountAllowedFundExpense)
    {
        var userIdString = HttpContext.Session.GetString(SessionKey.UserId);
        _ = long.TryParse(userIdString, out var userId);

        var data = _bankAccountsInformationService.GetBankAccountsInformationByUserId(userId, accountAllowedFundExpense).entity ?? new List<BankAccountsInformationVM>();
        return Json(new { Data = data }, SerializerOption.Default);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var returnResponse = _accountService.GetById(id);
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
        ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name");

        return View(new AccountVM());
    }

    [HttpPost]
    public ActionResult Create(AccountVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var returnResponse = _accountService.Create(entity);
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
                        _forestFcvVcfService,

                        entity.ForestCircleId,
                        entity.ForestDivisionId,
                        entity.ForestRangeId,
                        entity.ForestBeatId,
                        entity.ForestFcvVcfId
                    );

                    ViewBag.CommitteeTypeId = new SelectList(_committeeTypeConfigurationService.List().entity ?? new List<CommitteeTypeConfigurationVM>(), "Id", "CommitteeTypeName", entity?.CommitteeTypeId ?? 0);
                    ViewBag.CommitteeId = new SelectList(_committeesConfigurationService.GetCommitteesConfigurationByCommitteeTypeConfigurationId(entity?.CommitteeTypeId ?? 0).entity ?? new List<CommitteesConfigurationVM>(), "Id", "CommitteeName", entity?.CommitteeId ?? 0);
                    ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name", entity?.AccountType is null ? null : (int)entity.AccountType);

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Account information has been created successfully");
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

        var result = _accountService.GetById(id);
        if (result.entity is null)
        {
            HttpContext.Session.SetString("Message", "Account information not found");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Index");
        }

        AuthLocationHelper.GenerateViewBagForForest(
            HttpContext,
            ViewBag,
            _forestCircleService,
            _forestDivisionService,
            _forestRangeService,
            _forestBeatService,
            _forestFcvVcfService,

            result.entity.ForestCircleId,
            result.entity.ForestDivisionId,
            result.entity.ForestRangeId,
            result.entity.ForestBeatId,
            result.entity.ForestFcvVcfId
        );

        ViewBag.AccountAllowedFundExpenses = EnumHelper.GetEnumDropdowns<AccountAllowedFundExpense>();
        ViewBag.CommitteeTypeId = new SelectList(_committeeTypeConfigurationService.List().entity ?? new List<CommitteeTypeConfigurationVM>(), "Id", "CommitteeTypeName", result.entity?.CommitteeTypeId ?? 0);
        ViewBag.CommitteeId = new SelectList(_committeesConfigurationService.GetCommitteesConfigurationByCommitteeTypeConfigurationId(result.entity?.CommitteeTypeId ?? 0).entity ?? new List<CommitteesConfigurationVM>(), "Id", "CommitteeName", result.entity?.CommitteeId ?? 0);
        ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name", result.entity?.AccountType is null ? null : (int)result.entity.AccountType);

        return View(result.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, AccountVM entity)
    {
        try
        {
            //if (ModelState.IsValid)
            //{
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var returnResponse = _accountService.Update(entity);
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
                        _forestFcvVcfService,

                        entity.ForestCircleId,
                        entity.ForestDivisionId,
                        entity.ForestRangeId,
                        entity.ForestBeatId,
                        entity.ForestFcvVcfId
                    );

                    ViewBag.CommitteeTypeId = new SelectList(_committeeTypeConfigurationService.List().entity ?? new List<CommitteeTypeConfigurationVM>(), "Id", "CommitteeTypeName", entity?.CommitteeTypeId ?? 0);
                    ViewBag.CommitteeId = new SelectList(_committeesConfigurationService.GetCommitteesConfigurationByCommitteeTypeConfigurationId(entity?.CommitteeTypeId ?? 0).entity ?? new List<CommitteesConfigurationVM>(), "Id", "CommitteeName", entity?.CommitteeId ?? 0);
                    ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name", entity?.AccountType is null ? null : (int)entity.AccountType);

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Account information has been updated successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index");
                }
           // }

            return View(entity);
        }
        catch
        {
            return View(entity);
        }
    }

    public JsonResult Delete(int id)
    {
        var result = _accountService.SoftDelete(id);
        if (result.isDeleted)
        {
            result.message = "Item deleted successfully.";
        }
        else
        {
            result.message = "Failed to delete this item.";
        }

        return Json(new { Message = result.message, result.executionState }, SerializerOption.Default);
    }


    public ActionResult AccountsUserTagLog(long accountId)
    {
        if (accountId == default)
        {
            return NotFound();
        }

        var returnResponse = _accountsUserTagLogService.GetAccountsUserTagLogsByAccountId(accountId);
        return View(returnResponse.entity);
    }



    //DataTable Get List using server site Pagination
    //[HttpPost]
    public ActionResult GetAccountsListByPagination(JqueryDatatableParam param)
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
        ViewBag.AccountType = new SelectList(EnumHelper.GetEnumDropdowns<AccountTypeForAccount>(), "Id", "Name");
        ViewBag.AccountNumber = string.Empty;
        ViewBag.BankAccountName = string.Empty;

        var filter = AuthLocationHelper.GetFilterFromSession<AccountFilterVM>(HttpContext);
        filter.iDisplayStart = param.iDisplayStart;
        filter.iDisplayLength = param.iDisplayLength;
        filter.sSearch = param.sSearch;

        (ExecutionState executionState, PaginationResutlVM<AccountVM> entity, string message) returnResponse = _accountService.GetByFilter(filter);
        foreach (var item in returnResponse.entity.aaData)
        {
            item.AccountTypeText = item.AccountType.GetEnumDisplayName().ToString();
            item.CurrentAvailableBalanceBdtText = item.CurrentAvailableBalance.ToBDTCurrency().ToString();
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
    public ActionResult IndexFilterAccountsListByPagination(AccountFilterVM filter)
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

                (ExecutionState executionState, PaginationResutlVM<AccountVM> entity, string message) returnResponse = _accountService.GetByFilter(filter ?? new AccountFilterVM());

                foreach (var item in returnResponse.entity.aaData)
                {
                    item.AccountTypeText = item.AccountType.GetEnumDisplayName().ToString();
                    item.CurrentAvailableBalanceBdtText = item.CurrentAvailableBalance.ToBDTCurrency().ToString();
                }


        return Json(new
                {
                    //filter.sEcho,
                    iTotalRecords = returnResponse.entity.iTotalRecords,
                    iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
                    aaData = returnResponse.entity.aaData
                }, SerializerOption.Default);

        // return View("Index", result.entity);
    }






}
public class JqueryDatatableParam
{
    public string sEcho { get; set; }
    public string sSearch { get; set; }
    public int iDisplayLength { get; set; }
    public int iDisplayStart { get; set; }
    public int iColumns { get; set; }
    public int iSortCol_0 { get; set; }
    public string sSortDir_0 { get; set; }
    public int iSortingCols { get; set; }
    public string sColumns { get; set; }

}