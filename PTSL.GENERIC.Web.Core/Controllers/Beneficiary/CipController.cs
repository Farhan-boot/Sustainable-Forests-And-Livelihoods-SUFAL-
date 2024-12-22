

using System.Data.Common;
using System.Xml.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json.Linq;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Implementation.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Implementation.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Interface.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.AIG;

[SessionAuthorize]
public class CipController : Controller
{
    private readonly ICipService _CipService;
    private readonly ICipFileService _CipFileService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;
    private readonly IEthnicityService _EthnicityService;
    private readonly IApprovalLogForCfmService _ApprovalLogForCfmService;
    private readonly IPermissionHeaderSettingsService _PermissionHeaderSettingsService;
    private readonly IUserService _UserService;
    private readonly IPermissionRowSettingsService _PermissionRowSettingsService;
    private readonly ITypeOfHouseService _typeOfHouseService;

    private readonly FileHelper _fileHelper;

    private readonly IUserRoleService _userRoleService;

    

    public CipController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _CipService = new CipService(httpHelper);
        _CipFileService = new CipFileService(httpHelper);

        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);
        _ApprovalLogForCfmService = new ApprovalLogForCfmService(httpHelper);
        _PermissionHeaderSettingsService = new PermissionHeaderSettingsService(httpHelper);
        _UserService = new UserService(httpHelper);
        _PermissionRowSettingsService = new PermissionRowSettingsService(httpHelper);
        _typeOfHouseService = new TypeOfHouseService(httpHelper);

        _EthnicityService = new EthnicityService(httpHelper);
        _fileHelper = fileHelper;

        _userRoleService = new UserRoleService(httpHelper);
        
    }

    [RequirePermissions(CipListByFilterPermission.PermissionNameConst)]
    public ActionResult Index()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.CipWealth = new SelectList(EnumHelper.GetEnumDropdowns<CipWealth>(), "Id", "Name");
        ViewBag.NID = string.Empty;
        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");

        var filter = AuthLocationHelper.GetFilterFromSession<CipFilterVM>(HttpContext, 50);
        //(ExecutionState executionState, List<CipVM> entity, string message) returnResponse = _CipService.ListByFilter(filter);


        var permissionHeader = _PermissionRowSettingsService.List();
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 63).Select(x => x.Id).FirstOrDefault();
        var exceptMyInfoGetAllUser = permissionHeader.entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x.UserRoleId != userRoleId).ToList();
        //var userList = exceptMyInfoGetAllUser.Select(x => x.User);

        //if (userList != null)
        //{
        //    ViewBag.ReceiverId = new SelectList(userList, "Id", "UserName", userList);
        //}

        ////new
        string roleName = Convert.ToString(HttpContext.Session.GetString(SessionKey.RoleName));
        var exceptMyRoleInfoGetAllRoles = permissionHeader.entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x?.UserRole?.Id != userRoleId).ToList();
        var roleList = exceptMyRoleInfoGetAllRoles.Select(x => x.UserRole);
        if (roleList != null)
        {
            ViewBag.UserRoleId = new SelectList(roleList, "Id", "RoleName", roleList);
        }
        ViewBag.ReceiverId = new SelectList(new List<UserVM>(), "Id", "UserName");
        var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.Any(x => x?.ReceiverRoleId == userRoleId);
        ViewBag.CheckIsApprove = checkIsApprove ?? false;

        //returnResponse.entity 

        return View(new List<CipVM>());
    }

    [HttpPost]
    [RequirePermissions(CipListByFilterPermission.PermissionNameConst)]
    public ActionResult IndexFilter(CipFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.HasGender ? (int)filter.Gender! : null);
        ViewBag.CipWealth = new SelectList(EnumHelper.GetEnumDropdowns<CipWealth>(), "Id", "Name", filter.HasCipWealth ? (int)filter.CipWealth! : null);
        ViewBag.NID = filter.NID;
        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name", filter.EthnicityId);

        (ExecutionState executionState, PaginationResutlVM<CipVM> entity, string message) returnResponse = _CipService.ListByFilter(filter);


        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 63).Select(x => x.Id).FirstOrDefault();
        var exceptMyInfoGetAllUser = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x.UserRoleId != userRoleId).ToList();
        //var userList = exceptMyInfoGetAllUser.Select(x => x.User);

        //if (userList != null)
        //{
        //    ViewBag.ReceiverId = new SelectList(userList, "Id", "UserName", userList);
        //}

        ////new
        string roleName = Convert.ToString(HttpContext.Session.GetString(SessionKey.RoleName));
        var exceptMyRoleInfoGetAllRoles = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x?.UserRole?.Id != userRoleId).ToList();
        var roleList = exceptMyRoleInfoGetAllRoles.Select(x => x.UserRole);
        if (roleList != null)
        {
            ViewBag.UserRoleId = new SelectList(roleList, "Id", "RoleName", roleList);
        }
        ViewBag.ReceiverId = new SelectList(new List<UserVM>(), "Id", "UserName");
        var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.Any(x => x?.ReceiverRoleId == userRoleId);
        ViewBag.CheckIsApprove = checkIsApprove ?? false;



        return View("Index", returnResponse.entity.aaData);
    }

    public ActionResult IndexFilter()
    {
        return RedirectToAction("Index");
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, CipVM entity, string message) returnResponse = _CipService.GetById(id);
        return View(returnResponse.entity);
    }

    [RequirePermissions(CipCreatePermission.PermissionNameConst, RedirectTo = "Cip/Index")]
    public ActionResult Create()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.CipWealth = new SelectList(EnumHelper.GetEnumDropdowns<CipWealth>(), "Id", "Name");
        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
        ViewBag.TypeOfHouseNewId = new SelectList(_typeOfHouseService.List().entity ?? new List<TypeOfHouseVM>(), "Id", "Name");

        var entity = new CipVM();
        return View(entity);
    }

    [HttpPost]
    [RequirePermissions(CipCreatePermission.PermissionNameConst, RedirectTo = "Cip/Index")]
    public ActionResult Create(CipVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                entity.ApprovalStatus = (long)Helper.Enum.Beneficiary.CipApprovalStatus.Panding;

                var imageFiles = HttpContext.Request.Form.Files.GetFiles("CIPImageFiles[]");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("CIPDocumentFiles[]");

                // Save image files
                if (SaveFiles(imageFiles, ref entity, FileType.Image, out var imageFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = imageFileError },
                        SerializerOption.Default);
                }

                // Save document files
                if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = documentFileError },
                        SerializerOption.Default);
                }

                (ExecutionState executionState, CipVM entity, string message) returnResponse = _CipService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Create");
                }
                else
                {
                    HttpContext.Session.SetString("Message", "New CIP Information has been created successfully");
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

    [RequirePermissions(CipUpdatePermission.PermissionNameConst, RedirectTo = "Cip/Index")]
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        (ExecutionState executionState, CipVM entity, string message) result = _CipService.GetById(id);
        if (result.entity is null)
        {
            HttpContext.Session.SetString("Message", "CIP information not found");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Index");
        }

        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,

            result.entity.ForestCircleId,
            result.entity.ForestDivisionId,
            result.entity.ForestRangeId,
            result.entity.ForestBeatId,
            result.entity.ForestFcvVcfId,
            result.entity.DivisionId,
            result.entity.DistrictId,
            result.entity.UpazillaId,
            result.entity.UnionId
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", result.entity == null ? null : (int)(result.entity.Gender ?? 0));
        ViewBag.HouseType = new SelectList(EnumHelper.GetEnumDropdowns<HouseType>(), "Id", "Name", result.entity == null ? null : (int)(result.entity.HouseType ?? 0));
        ViewBag.CipWealth = new SelectList(EnumHelper.GetEnumDropdowns<CipWealth>(), "Id", "Name", result.entity == null ? null : (int)(result.entity.CipWealth ?? 0));
        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name", result.entity?.EthnicityId);
        ViewBag.TypeOfHouseNewId = new SelectList(_typeOfHouseService.List().entity ?? new List<TypeOfHouseVM>(), "Id", "Name", result.entity?.TypeOfHouseNewId);

        return View(result.entity);
    }

    [HttpPost]
    [RequirePermissions(CipUpdatePermission.PermissionNameConst, RedirectTo = "Cip/Index")]
    public ActionResult Edit(int id, CipVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                entity.ApprovalStatus = (long)Helper.Enum.Beneficiary.CipApprovalStatus.Panding;

                var imageFiles = HttpContext.Request.Form.Files.GetFiles("CIPImageFiles[]");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("CIPDocumentFiles[]");

                // Save image files
                if (SaveFiles(imageFiles, ref entity, FileType.Image, out var imageFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = imageFileError },
                        SerializerOption.Default);
                }

                // Save document files
                if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = documentFileError },
                        SerializerOption.Default);
                }

                (ExecutionState executionState, CipVM entity, string message) returnResponse = _CipService.Update(entity);

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "CIP Information has been updated successfully");
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

    [RequirePermissions(CipDeletePermission.PermissionNameConst, RedirectTo = "Cip/Index")]
    public JsonResult Delete(int id)
    {
        var result = _CipService.SoftDelete(id);
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

    public ActionResult DeleteImageOrDocument(long id)
    {
        var result = _CipFileService.SoftDelete(id);
        if (result.isDeleted)
        {
            result.message = "Item deleted successfully.";
        }
        else
        {
            result.message = "Failed to delete this item.";
        }

        return Json(new { Success = result.isDeleted, Message = result.message, result.executionState }, SerializerOption.Default);
    }

    [HttpPost]
    public ActionResult ListByFilterForBeneficiary(CipFilterVM filter)
    {
        var result = _CipService.ListByFilterForBeneficiary(filter);

        return Json(new { Data = result.entity, Message = result.message, result.executionState }, SerializerOption.Default);
    }

    private bool SaveFiles(IReadOnlyList<IFormFile> files, ref CipVM entity, FileType fileType, out string error)
    {
        foreach (var file in files)
        {
            var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "CIP", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            var entityFile = new CipFileVM
            {
                FileName = file.FileName,
                FileType = fileType,
                FileNameUrl = fileName,
            };

            entity?.CipFiles?.Add(entityFile);
        }

        error = string.Empty;
        return true;
    }

    public ActionResult RequestList()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
           HttpContext,
           ViewBag,
           _ForestCircleService,
           _ForestDivisionService,
           _ForestRangeService,
           _ForestBeatService,
           _ForestFcvVcfService,
           _DivisionService,
           _DistrictService,
           _UpazillaService,
           _UnionService
       );


        ViewBag.ReceiverId = new SelectList(new List<UserVM>(), "Id", "UserName");

        (ExecutionState executionState, List<CipVM> entity, string message) returnResponse = _CipService.List();

        if (returnResponse.entity == null)
        {
            return View(new List<CipVM>());
        }

        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        //new
        long userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));



        var returnResponseApprovalLogForCfm = _ApprovalLogForCfmService.List().entity?.OrderByDescending(x => x.CreatedAt)?.Where(x => x?.ReceiverRoleId == userRoleId).ToList() ?? new List<ApprovalLogForCfmVM>();


        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 63).Select(x => x.Id).FirstOrDefault();

        var exceptMyRoleInfoGetAllRoles = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x?.UserRole?.Id != userRoleId).ToList();
        var roleList = exceptMyRoleInfoGetAllRoles.Select(x => x.UserRole);

        if (roleList != null)
        {
            ViewBag.UserRoleId = new SelectList(roleList, "Id", "RoleName", roleList);
        }

        //var checkIsLetestReceiver = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
        //var checkIsLetestReceiver = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.Id).FirstOrDefault();

        var checkIsLetestReceiver = _PermissionRowSettingsService?.List().entity?.OrderByDescending(x => x.Id).FirstOrDefault();
        //?.Any(x => x?.ReceiverId == userId);
        //ViewBag.CheckIsApprove = checkIsLetestReceiver ?? false;


        var returnResponsePermissionHeaderSettings = _PermissionHeaderSettingsService.List().entity.Where(x => x.AccesslistId == 63).FirstOrDefault();
        var returnResponsePermissionRowSettings = returnResponsePermissionHeaderSettings?.PermissionRowSettings?.OrderByDescending(x => x.OrderId).ToList();
        var checkIsVisavaleAcceptButton = false;
        if (returnResponsePermissionRowSettings?.FirstOrDefault()?.UserRoleId == userRoleId)
        {
            checkIsVisavaleAcceptButton = true;
        }
        ViewBag.CheckIsVisavaleAcceptButton = checkIsVisavaleAcceptButton;



        var checkIsApprovalLogForCfm = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.Id).FirstOrDefault();


        if (checkIsApprovalLogForCfm?.ReceiverRoleId == userRoleId)
        {
            return View(returnResponse.entity);
        }
        else
        {
            return View(new List<CipVM>());
        }

        if (checkIsLetestReceiver?.UserRoleId == userRoleId)
        {
            return View(returnResponse.entity);
        }
        else
        {
            return View(new List<CipVM>());
        }

        return View(new List<CipVM>());
    }

    [HttpGet]
    public JsonResult GetModalDataExtra(long id)
    {
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 63).Select(x => x.Id).FirstOrDefault();

        var exceptMyInfoGetAllUser = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x.UserId != userId).ToList().Where(x => x.OrderId > x.OrderId + 1 || x.OrderId < x.OrderId - 1 || x.OrderId == x.OrderId).ToList();
        var userList = exceptMyInfoGetAllUser.Select(x => x.User);

        if (userList != null)
        {
            ViewBag.ReceiverId = new SelectList(userList, "Id", "UserName", userList);
        }

        return Json(new { Data = userList, Message = "" }, SerializerOption.Default);
    }


    [HttpPost]
    public JsonResult SaveMapToUser(ApprovalLogForCfmVM entity)
    {
        entity.IsActive = true;
        entity.CreatedAt = DateTime.Now;
        entity.ApprovalStatusId = Helper.Enum.ApprovalLog.ApprovalLogForCfmStatus.Panding;
        entity.SenderId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        entity.SenderRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

        (ExecutionState executionState, ApprovalLogForCfmVM entity, string message) returnResponse = _ApprovalLogForCfmService.Create(entity);

        return Json(new { Data = returnResponse, Message = "" }, SerializerOption.Default);
    }


    public ActionResult AcceptedById(int id)
    {
        var result = _CipService.GetById(id);
        //result.entity.CipFiles = null;
        //result.entity.ApprovalLogForCfms = null;

        result.entity.ApprovalStatus = (long)Helper.Enum.Beneficiary.CipApprovalStatus.Approve;
        result.entity.UpdatedAt = DateTime.Now;
        var returnResponse = _CipService.Update(result.entity);
        return RedirectToAction("RequestList", "Cip");
    }




    //DataTable Get List using server site Pagination

    //[HttpPost]
    public ActionResult GetCipListByPagination(JqueryDatatableParam param)
    {

        try
        {
            var filter = AuthLocationHelper.GetFilterFromSession<CipFilterVM>(HttpContext);
            filter.iDisplayStart = param.iDisplayStart;
            filter.iDisplayLength = param.iDisplayLength;
            filter.sSearch = param.sSearch;


            var displayResult = new List<CipVM>();
            (ExecutionState executionState, PaginationResutlVM<CipVM> entity, string message) returnResponse = _CipService.ListByFilter(filter);

            displayResult = returnResponse.entity.aaData.ToList();
            var totalRecords = returnResponse.entity.iTotalRecords;

            foreach (var item in displayResult)
            {
                if (item.Gender != null)
                {
                    item.GenderName = Enum.GetName(typeof(Gender), (long)item?.Gender);
                    item.CipWealthName = Enum.GetName(typeof(CipWealth), (long)item?.CipWealth);
                }
               
                //Approval Status
                if (item.ApprovalStatus == null)
                {
                    item.ApprovalStatusName = "---";
                }
                if (item.ApprovalStatus == 0)
                {
                    item.ApprovalStatusName = "Pending";
                }
                if (item.ApprovalStatus == 1)
                {
                    item.ApprovalStatusName = "Pending";
                }
                if (item.ApprovalStatus == 2)
                {
                    item.ApprovalStatusName = "Approve";
                }
                if (item.ApprovalStatus == 3)
                {
                    item.ApprovalStatusName = "Reject";
                }

            }

            var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));
            var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.Any(x => x?.ReceiverRoleId == userRoleId);

            //permissions
            var permissions = _userRoleService.CurrentUserHasPermissions(
                               CipCreatePermission.PermissionNameConst,
                               CipUpdatePermission.PermissionNameConst,
                               CipDeletePermission.PermissionNameConst
                            );

            bool editPermission = false;
            if (permissions.TryGetValue(CipUpdatePermission.PermissionNameConst, out var hasUpdatePermission) && hasUpdatePermission)
            {
                editPermission = true;
            }
            bool deletePermission = false;
            if (permissions.TryGetValue(CipDeletePermission.PermissionNameConst, out var hasDeletePermission) && hasDeletePermission)
            {
                deletePermission = true;
            }


            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult,
                checkIsApprove = checkIsApprove ?? false,
                isEditPermissions = editPermission,
                isDeletePermissions = deletePermission
            }, SerializerOption.Default);
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message });
        }

        //(ExecutionState executionState, List<CipVM> entity, string message) returnResponse = _CipService.ListByFilter(data);
        return Json("", SerializerOption.Default);
    }

    [HttpPost]
    public ActionResult IndexFilterCipListByPagination(CipFilterVM filter)
    {

        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );



        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.HasGender ? (int)filter.Gender! : null);
        ViewBag.CipWealth = new SelectList(EnumHelper.GetEnumDropdowns<CipWealth>(), "Id", "Name", filter.HasCipWealth ? (int)filter.CipWealth! : null);
        ViewBag.NID = filter.NID;
        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name", filter.EthnicityId);

        (ExecutionState executionState, PaginationResutlVM<CipVM> entity, string message) returnResponse = _CipService.ListByFilter(filter);


        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 63).Select(x => x.Id).FirstOrDefault();
        var exceptMyInfoGetAllUser = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x.UserRoleId != userRoleId).ToList();
        //var userList = exceptMyInfoGetAllUser.Select(x => x.User);

        //if (userList != null)
        //{
        //    ViewBag.ReceiverId = new SelectList(userList, "Id", "UserName", userList);
        //}

        ////new
        string roleName = Convert.ToString(HttpContext.Session.GetString(SessionKey.RoleName));
        var exceptMyRoleInfoGetAllRoles = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x?.UserRole?.Id != userRoleId).ToList();
        var roleList = exceptMyRoleInfoGetAllRoles.Select(x => x.UserRole);
        if (roleList != null)
        {
            ViewBag.UserRoleId = new SelectList(roleList, "Id", "RoleName", roleList);
        }
        ViewBag.ReceiverId = new SelectList(new List<UserVM>(), "Id", "UserName");
        var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.Any(x => x?.ReceiverRoleId == userRoleId);
        ViewBag.CheckIsApprove = checkIsApprove ?? false;

        foreach (var item in returnResponse.entity.aaData)
        {
            if (item.Gender != null && item.CipWealth != null)
            {
                item.GenderName = Enum.GetName(typeof(Gender), (long)item?.Gender);
                item.CipWealthName = Enum.GetName(typeof(CipWealth), (long)item?.CipWealth);
                //Approval Status
                if (item.ApprovalStatus == null)
                {
                    item.ApprovalStatusName = "---";
                }
                if (item.ApprovalStatus == 0)
                {
                    item.ApprovalStatusName = "Pending";
                }
                if (item.ApprovalStatus == 1)
                {
                    item.ApprovalStatusName = "Pending";
                }
                if (item.ApprovalStatus == 2)
                {
                    item.ApprovalStatusName = "Approve";
                }
                if (item.ApprovalStatus == 3)
                {
                    item.ApprovalStatusName = "Reject";
                }
            }
        }

        //var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));
        //var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.Any(x => x?.ReceiverRoleId == userRoleId);

        //permissions
        var permissions = _userRoleService.CurrentUserHasPermissions(
                           CipCreatePermission.PermissionNameConst,
                           CipUpdatePermission.PermissionNameConst,
                           CipDeletePermission.PermissionNameConst
                        );

        bool editPermission = false;
        if (permissions.TryGetValue(CipUpdatePermission.PermissionNameConst, out var hasUpdatePermission) && hasUpdatePermission)
        {
            editPermission = true;
        }
        bool deletePermission = false;
        if (permissions.TryGetValue(CipDeletePermission.PermissionNameConst, out var hasDeletePermission) && hasDeletePermission)
        {
            deletePermission = true;
        }



        return Json(new
        {
            filter.sEcho,
            iTotalRecords = returnResponse.entity.iTotalRecords,
            iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
            aaData = returnResponse.entity.aaData,
            checkIsApprove = checkIsApprove ?? false,
            isEditPermissions = editPermission,
            isDeletePermissions = deletePermission
        }, SerializerOption.Default);

  
        //return View("Index", returnResponse.entity);
    }




}

public class CipListByFilterPermission : IAPIPermission
{
    public const string PermissionNameConst = "Cip.ListByFilter";
    public string PermissionName => "Cip.ListByFilter";
    public string PermissionDetails => "CIP List by Filter";
}

public class CipCreatePermission : IAPIPermission
{
    public const string PermissionNameConst = "Cip.Create";
    public string PermissionName => "Cip.Create";
    public string PermissionDetails => "Create CIP";
}

public class CipUpdatePermission : IAPIPermission
{
    public const string PermissionNameConst = "Cip.Update";
    public string PermissionName => "Cip.Update";
    public string PermissionDetails => "Update CIP";
}

public class CipDeletePermission : IAPIPermission
{
    public const string PermissionNameConst = "Cip.Delete";
    public string PermissionName => "Cip.Delete";
    public string PermissionDetails => "Delete CIP";
}



//new
public class JqueryDatatableParam
{
    public string sEcho { get; set; }
    public string sSearch { get; set; }
    public int? iDisplayLength { get; set; }
    public int? iDisplayStart { get; set; }
    public int iColumns { get; set; }
    public int iSortCol_0 { get; set; }
    public string sSortDir_0 { get; set; }
    public int iSortingCols { get; set; }
    public string sColumns { get; set; }
}