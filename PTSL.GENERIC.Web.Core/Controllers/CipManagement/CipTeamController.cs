

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Implementation.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.CipManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Implementation.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Interface.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.CipManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.CipManagement;


[SessionAuthorize]
public class CipTeamController : Controller
{
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IEthnicityService _EthnicityService;
    private readonly IOtherCommitteeMemberService _OtherCommitteeMemberService;
    private readonly ISurveyService _SurveyService;
    private readonly INgoService _NgoService;

    // Civil administration
    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;
    private readonly ICommitteeDesignationService _SubCommitteeDesignationService;
    private readonly ICommitteeManagementService _CommitteeManagementService;
    private readonly ICommitteeManagementMemberService _CommitteeManagementMemberService;
    private readonly ICipService _CipService;
    private readonly ICipTeamService _CipTeamService;
    private readonly ICipTeamMemberService _CipTeamMemberService;
    private readonly IUserService _UserService;
    private readonly IPermissionHeaderSettingsService _PermissionHeaderSettingsService;
    private readonly IPermissionRowSettingsService _PermissionRowSettingsService;
    private readonly IApprovalLogForCfmService _ApprovalLogForCfmService;
    private readonly IAccesslistService _AccesslistService;

    private readonly FileHelper _fileHelper;


    public CipTeamController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _EthnicityService = new EthnicityService(httpHelper);
        _OtherCommitteeMemberService = new OtherCommitteeMemberService(httpHelper);
        _SurveyService = new SurveyService(httpHelper);
        _NgoService = new NgoService(httpHelper);
        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);
        _CommitteeManagementService = new CommitteeManagementService(httpHelper);
        _CommitteeManagementMemberService = new CommitteeManagementMemberService(httpHelper);
        _SubCommitteeDesignationService = new CommitteeDesignationService(httpHelper);
        _CipService = new CipService(httpHelper);
        _CipTeamService = new CipTeamService(httpHelper);
        _CipTeamMemberService = new CipTeamMemberService(httpHelper);
        _UserService = new UserService(httpHelper);
        _PermissionHeaderSettingsService = new PermissionHeaderSettingsService(httpHelper);
        _PermissionRowSettingsService = new PermissionRowSettingsService(httpHelper);
        _ApprovalLogForCfmService = new ApprovalLogForCfmService(httpHelper);
        _AccesslistService = new AccesslistService(httpHelper);

        _fileHelper = fileHelper;
    }

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

        (ExecutionState executionState, List<CipTeamVM> entity, string message) returnResponse = _CipTeamService.List();
        

        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);
        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 73).Select(x => x.Id).FirstOrDefault();
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
        var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.Any(x=>x?.ReceiverRoleId == userRoleId);
        ViewBag.CheckIsApprove = checkIsApprove ?? false;



        //if (returnResponse.entity == null)
        //{
        //    return View(new List<CipTeamVM>());
        //}


        return View(returnResponse.entity ?? new List<CipTeamVM>());
    }


    [HttpPost]
    public ActionResult IndexFilter(ExecutiveCommitteeFilterVM filter)
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


        (ExecutionState executionState, PaginationResutlVM<CipTeamVM> entity, string message) returnResponse = _CipTeamService.GetByFilter(filter);

        //if (returnResponse.entity == null)
        //{
        //    return View(new List<CipTeamVM>());
        //}


        return View("Index", returnResponse.entity.aaData ?? new List<CipTeamVM>());
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
        (ExecutionState executionState, CipTeamVM entity, string message) returnResponse = _CipTeamService.GetById(id);

        //ViewBag.CommitteeTypeId = new SelectList(EnumHelper.GetEnumDropdowns<CommitteeType>(), "Id", "Name", returnResponse.entity.CommitteeTypeId);
        //ViewBag.ExDesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<ExecutiveDesignationType>(), "Id", "Name", returnResponse.entity.ExDesignatinId);
        //ViewBag.SubExecutiveDesignationId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", returnResponse.entity.SubCommitteeDesignationId);

        return View(returnResponse.entity);
    }





    //public ActionResult GetByFilter(ExecutiveCommitteeFilterVM filter)
    //{
    //    if (filter is null) return Json(null);

    //    var result = _ExecutiveCommitteeService.GetByFilter(filter);
    //    return Json(
    //        new
    //        {
    //            Success = result.executionState == ExecutionState.Retrieved,
    //            Data = result.entity,
    //            Message = result.message
    //        },
    //        SerializerOption.Default);
    //}






    public ActionResult Create()
    {
        CipTeamVM entity = new CipTeamVM();

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

        (ExecutionState executionState, List<NgoVM> entity, string message) returnResponseNgo = _NgoService.List();
        //if (returnResponseNgo.entity != null)
        //{
        ViewBag.NgoId = new SelectList(returnResponseNgo.entity ?? new List<NgoVM>(), "Id", "Name", returnResponseNgo.entity);
        //}

        (ExecutionState executionState, List<CipVM> entity, string message) returnResponseCip = _CipService.List();
        //if (returnResponseCip.entity != null)
        //{
        ViewBag.CipId = new SelectList(returnResponseCip.entity ?? new List<CipVM>(), "Id", "BeneficiaryName", returnResponseCip.entity);
        //}

        (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) returnResponseOtherCommitteeMember = _OtherCommitteeMemberService.List();
        //if (returnResponseOtherCommitteeMember.entity != null)
        //{
        ViewBag.OtherCommitteeMemberId = new SelectList(returnResponseOtherCommitteeMember.entity ?? new List<OtherCommitteeMemberVM>(), "Id", "FullName", returnResponseOtherCommitteeMember.entity);
        //}



        return View(entity);
    }


    [HttpPost]
    public ActionResult Create(CipTeamVM entity)
    {
        try
        {
            //if (ModelState.IsValid)
            //{
            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;
            entity.ApprovalStatus = (long)Helper.Enum.CipTeam.CipTeamApprovalStatus.Panding;

            entity.CipTeamMembers = JsonConvert.DeserializeObject<List<CipTeamMemberVM>>(entity.CipTeamMembersJson);
            var documentFile = HttpContext.Request.Form.Files.GetFile("DocumentFileUrl");

            if (documentFile is not null)
            {
                if (SaveFiles(documentFile, ref entity, FileType.Document, out var imageFileError) == false)
                {

                }
            }




            (ExecutionState executionState, CipTeamVM entity, string message) returnResponse = _CipTeamService.Create(entity);
            //                    Session["Message"] = returnResponse.message;
            //                    Session["executionState"] = returnResponse.executionState;

            if (returnResponse.executionState.ToString() != "Created")
            {
                HttpContext.Session.SetString("Message", "Cip Team has been created successfully");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                //return RedirectToAction("Index");

                return Json(
                 new
                 {
                     Success = returnResponse.executionState == ExecutionState.Retrieved,
                     Data = returnResponse.entity,
                     Message = returnResponse.message
                 },
                 SerializerOption.Default);

            }
            else
            {
                HttpContext.Session.SetString("Message", "Cip Team has been created successfully");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                return Json(
                new
                {
                    Success = returnResponse.executionState == ExecutionState.Retrieved,
                    Data = returnResponse.entity,
                    Message = returnResponse.message
                },
                SerializerOption.Default);

                //return RedirectToAction("Index");
            }
            //}
            //                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
            //                Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
        catch
        {
            //                Session["Message"] = "Form Data Not Valid.";
            //                Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
    }



    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, CipTeamVM entity, string message) returnResponse = _CipTeamService.GetById(id);


        //ViewBag.CommitteeTypeId = new SelectList(EnumHelper.GetEnumDropdowns<CommitteeType>(), "Id", "Name", (int)returnResponse.entity.CommitteeTypeId);

        //if (returnResponse.entity.SubCommitteeTypeId != null)
        //{
        //    ViewBag.DesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", (int)returnResponse.entity.SubCommitteeTypeId);
        //}

        //ViewBag.GenderId = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", returnResponse.entity.GenderId);
        //ViewBag.ExDesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<ExecutiveDesignationType>(), "Id", "Name", returnResponse.entity.ExDesignatinId);

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

            returnResponse.entity.ForestCircleId,
            returnResponse.entity.ForestDivisionId,
            returnResponse.entity.ForestRangeId,
            returnResponse.entity.ForestBeatId,
            returnResponse.entity.ForestFcvVcfId,
            returnResponse.entity.DivisionId,
            returnResponse.entity.DistrictId,
            returnResponse.entity.UpazillaId,
            returnResponse.entity.UnionId
        );


        (ExecutionState executionState, List<NgoVM> entity, string message) returnResponseNgo = _NgoService.List();
        //if (returnResponseNgo.entity != null)
        //{
        ViewBag.NgoId = new SelectList(returnResponseNgo.entity ?? new List<NgoVM>(), "Id", "Name", returnResponse.entity.NgoId);
        //}

        (ExecutionState executionState, List<CipVM> entity, string message) returnResponseCip = _CipService.List();
        //if (returnResponseCip.entity != null)
        //{
        ViewBag.CipId = new SelectList(returnResponseCip.entity ?? new List<CipVM>(), "Id", "BeneficiaryName", returnResponseCip.entity);
        //}

        (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) returnResponseOtherCommitteeMember = _OtherCommitteeMemberService.List();
        //if (returnResponseOtherCommitteeMember.entity != null)
        //{
        ViewBag.OtherCommitteeMemberId = new SelectList(returnResponseOtherCommitteeMember.entity ?? new List<OtherCommitteeMemberVM>(), "Id", "FullName", returnResponseOtherCommitteeMember.entity);
        //}

        return View(returnResponse.entity);
    }




    [HttpPost]
    public ActionResult Edit(int id, CipTeamVM entity)
    {
        try
        {
            //if (ModelState.IsValid)
            //{

            entity.CipTeamMembers = JsonConvert.DeserializeObject<List<CipTeamMemberVM>>(entity.CipTeamMembersJson);

            var documentFile = HttpContext.Request.Form.Files.GetFile("DocumentFileUrl");

            if (documentFile is not null)
            {
                if (SaveFiles(documentFile, ref entity, FileType.Document, out var imageFileError) == false)
                {

                }
            }

            if (id != entity.Id)
            {
                return RedirectToAction(nameof(CategoryController.Index), "Category");
            }
            entity.IsActive = true;
            entity.IsDeleted = false;
            entity.UpdatedAt = DateTime.Now;
            entity.ApprovalStatus = (long)Helper.Enum.CipTeam.CipTeamApprovalStatus.Panding;

            (ExecutionState executionState, CipTeamVM entity, string message) returnResponse = _CipTeamService.Update(entity);
            //                    Session["Message"] = returnResponse.message;
            //                    Session["executionState"] = returnResponse.executionState;
            if (returnResponse.executionState.ToString() != "Updated")
            {
                return View(entity);
            }
            else
            {
                HttpContext.Session.SetString("Message", "Cip Team has been Updated successfully");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                return Json(
          new
          {
              Success = returnResponse.executionState == ExecutionState.Retrieved,
              Data = returnResponse.entity,
              Message = returnResponse.message
          },
          SerializerOption.Default);

                // return RedirectToAction("Index", "CommitteeManagement");
            }
            //}

            //                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
            //                Session["executionState"] = ExecutionState.Failure;
            return Json(
           new
           {
               Success = returnResponse.executionState == ExecutionState.Retrieved,
               Data = returnResponse.entity,
               Message = returnResponse.message
           },
           SerializerOption.Default);

        }
        catch
        {
            //                Session["Message"] = "Form Data Not Valid.";
            //                Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
    }



    public JsonResult Delete(int id)
    {
        var result = _CipTeamService.SoftDelete(id);
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




    ////public JsonResult Delete(int id)
    ////{
    ////    (ExecutionState executionState, string message) CheckDataExistOrNot = _CommitteeManagementService.DoesExist(id);
    ////    string message = "Failed, You can't delete this item.";

    ////    if (CheckDataExistOrNot.executionState.ToString() != "Success")
    ////    {
    ////        return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
    ////    }

    ////    (ExecutionState executionState, CommitteeManagementVM entity, string message) returnResponse = _CommitteeManagementService.Delete(id);
    ////    if (returnResponse.executionState.ToString() == "Updated")
    ////    {
    ////        returnResponse.message = "Item deleted successfully.";
    ////    }
    ////    else
    ////    {
    ////        returnResponse.message = "Failed to delete this item.";
    ////    }

    ////    return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
    ////}




    [HttpGet]
    public ActionResult DeleteMemberById(long id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _CipTeamMemberService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, CipTeamMemberVM entity, string message) returnResponse = _CipTeamMemberService.Delete(id);
        if (returnResponse.executionState.ToString() == "Updated")
        {
            returnResponse.message = "Item deleted successfully.";
        }
        else
        {
            returnResponse.message = "Failed to delete this item.";
        }

        return Json(new { Data = returnResponse.entity, Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
    }

    public JsonResult GetCipById(int id)
    {
        var result = _CipService.List().entity.Where(x => x.ForestFcvVcfId == id).ToList();

        return Json(
            new
            {
                Data = result,
                Message = result
            },
            SerializerOption.Default);
    }


    // Approval Status
    public ActionResult SendRequest(int id)
    {
        var result = _CipTeamService.GetById(id);
        result.entity.CipTeamMembers = null;

        result.entity.UpdatedAt = DateTime.Now;
        result.entity.ApprovalStatus = (long)Helper.Enum.CipTeam.CipTeamApprovalStatus.SentRequest;
        var returnResponse = _CipTeamService.Update(result.entity);
        return RedirectToAction("Index", "CipTeam");
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

        (ExecutionState executionState, List<CipTeamVM> entity, string message) returnResponse = _CipTeamService.List();

        //if (returnResponse.entity == null)
        //{
        //    return View(new List<CipTeamVM>());
        //}

        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        //new
        long userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));
        


        var returnResponseApprovalLogForCfm = _ApprovalLogForCfmService.List().entity?.OrderByDescending(x=>x.CreatedAt)?.Where(x=>x?.ReceiverRoleId == userRoleId).ToList() ?? new List<ApprovalLogForCfmVM>();


        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 73).Select(x => x.Id).FirstOrDefault();

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


        var returnResponsePermissionHeaderSettings = _PermissionHeaderSettingsService.List().entity.Where(x=>x.AccesslistId == 73).FirstOrDefault();
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
            return View(returnResponse.entity ?? new List<CipTeamVM>());
        }
        else
        {
            return View(new List<CipTeamVM>() ?? new List<CipTeamVM>());
        }

        if (checkIsLetestReceiver?.UserRoleId == userRoleId)
        {
            return View(returnResponse.entity ?? new List<CipTeamVM>());
        }
        else
        {
            return View(new List<CipTeamVM>() ?? new List<CipTeamVM>());
        }

        return View(new List<CipTeamVM>() ?? new List<CipTeamVM>());
    }




    public ActionResult AcceptedById(int id)
    {
        var result = _CipTeamService.GetById(id);
        result.entity.CipTeamMembers = null;
        result.entity.ApprovalLogForCfms = null;

        result.entity.ApprovalStatus = (long)Helper.Enum.CipTeam.CipTeamApprovalStatus.Approve;
        result.entity.UpdatedAt = DateTime.Now;
        var returnResponse = _CipTeamService.Update(result.entity);
        return RedirectToAction("RequestList", "CipTeam");
    }

    public ActionResult RejectedById(int id)
    {
        var result = _CipTeamService.GetById(id);
        result.entity.CipTeamMembers = null;

        result.entity.UpdatedAt = DateTime.Now;
        result.entity.ApprovalStatus = (long)Helper.Enum.CipTeam.CipTeamApprovalStatus.Rejectted;
        var returnResponse = _CipTeamService.Update(result.entity);
        return RedirectToAction("RequestList", "CipTeam");
    }

    [HttpGet]
    public JsonResult GetOtherMemberById(long id)
    {
        var returnResponseOtherCommitteeMember = _OtherCommitteeMemberService.GetById(id);
        return Json(new { Data = returnResponseOtherCommitteeMember.entity, Message = returnResponseOtherCommitteeMember.message, returnResponseOtherCommitteeMember.executionState }, SerializerOption.Default);
    }


    [HttpGet]
    public JsonResult GetModalDataExtra(long id)
    {
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x=>x.AccesslistId == 73).Select(x=>x.Id).FirstOrDefault();

        var exceptMyInfoGetAllUser = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x.UserId != userId).ToList().Where(x=>x.OrderId > x.OrderId +1 || x.OrderId < x.OrderId -1 || x.OrderId == x.OrderId).ToList();
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

    [HttpGet]
    public JsonResult GetUserInfoByRoleId(long id)
    {
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
       

        var exceptMyInfoGetAllUser = _UserService.List().entity.Where(x=>x.Id != userId && x.UserRoleId == id).ToList();
        var userList = exceptMyInfoGetAllUser;

        if (userList != null)
        {
            ViewBag.ReceiverId = new SelectList(userList, "Id", "UserName", userList);
        }

        return Json(new { Data = userList, Message = "" }, SerializerOption.Default);
    }

    private bool SaveFiles(IFormFile? file, ref CipTeamVM entity, FileType fileType, out string error)
    {
        if (file is null)
        {
            error = "File is empty";
            return false;
        }

        var (isSaved, fileUrl, fileName) = _fileHelper.SaveFile(file, fileType, "CipTeam", out var errorMessage);
        if (isSaved == false)
        {
            error = errorMessage;
            return false;
        }

        entity.DocumentUrl = fileUrl;

        error = string.Empty;
        return true;
    }


    //DataTable Get List using server site Pagination
    //[HttpPost]
    public ActionResult GetCipTeamListByPagination(JqueryDatatableParam param)
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
        var filter = AuthLocationHelper.GetFilterFromSession<ExecutiveCommitteeFilterVM>(HttpContext);
        filter.iDisplayStart = param.iDisplayStart;
        filter.iDisplayLength = param.iDisplayLength;
        filter.sSearch = param.sSearch;

        (ExecutionState executionState, PaginationResutlVM<CipTeamVM> entity, string message) returnResponse = _CipTeamService.GetByFilter(filter);
            if (returnResponse.entity.aaData == null)
            {
                return View(new List<CipTeamVM>());
            }

            var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
            var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));
            var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

            var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 73).Select(x => x.Id).FirstOrDefault();
            var exceptMyInfoGetAllUser = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x.UserRoleId != userRoleId).ToList();
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
            if (item.ApprovalStatus == null)
            {
                item.ApprovalStatusText = "---";
            }
            if (item.ApprovalStatus == 0)
            {
                item.ApprovalStatusText = "Pending";
            }
            if (item.ApprovalStatus == 1)
            {
                item.ApprovalStatusText = "Pending";
            }
            if (item.ApprovalStatus == 2)
            {
                item.ApprovalStatusText = "Approve";
            }
            if (item.ApprovalStatus == 3)
            {
                item.ApprovalStatusText = "Reject";
            }

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
    public ActionResult IndexFilterCipTeamListByPagination(ExecutiveCommitteeFilterVM filter)
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

        (ExecutionState executionState, PaginationResutlVM<CipTeamVM> entity, string message) returnResponse = _CipTeamService.GetByFilter(filter);

            if (returnResponse.entity == null)
            {
                return View(new List<CipTeamVM>());
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


