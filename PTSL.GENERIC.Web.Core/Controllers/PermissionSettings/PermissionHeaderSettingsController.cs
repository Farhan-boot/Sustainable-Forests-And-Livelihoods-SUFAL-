using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum.PermissionSettings;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PermissionSettings;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Implementation.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.PermissionSettings;


[SessionAuthorize]
public class PermissionHeaderSettingsController : Controller
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
    private readonly IPermissionHeaderSettingsService _PermissionHeaderSettingsService;
    private readonly IPermissionRowSettingsService _PermissionRowSettingsService;
    private readonly IAccesslistService _AccesslistService;


    //For new logic
    private readonly ICommitteeTypeConfigurationService _CommitteeTypeConfigurationService;
    private readonly ICommitteesConfigurationService _CommitteesConfigurationService;
    private readonly ICommitteeDesignationsConfigurationService _CommitteeDesignationsConfigurationService;

    //For New
    private readonly IUserRoleService _UserRoleService;
    private readonly IUserService _UserService;


    public PermissionHeaderSettingsController(HttpHelper httpHelper)
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
        _PermissionHeaderSettingsService = new PermissionHeaderSettingsService(httpHelper);
        _PermissionRowSettingsService = new PermissionRowSettingsService(httpHelper);
        _AccesslistService = new AccesslistService(httpHelper);



        _CommitteeTypeConfigurationService = new CommitteeTypeConfigurationService(httpHelper);
        _CommitteesConfigurationService = new CommitteesConfigurationService(httpHelper);
        _CommitteeDesignationsConfigurationService = new CommitteeDesignationsConfigurationService(httpHelper);

        //For New
        _UserRoleService = new UserRoleService(httpHelper);
        _UserService = new UserService(httpHelper);

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


        (ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) returnResponseIsActiveData = _PermissionHeaderSettingsService.List();

        if (returnResponseIsActiveData.entity == null)
        {
            return View(new List<PermissionHeaderSettingsVM>());
        }

        return View(returnResponseIsActiveData.entity);
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


        (ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) returnResponse = _PermissionHeaderSettingsService.GetByFilter(filter);

        if (returnResponse.entity == null)
        {
            return View(new List<PermissionHeaderSettingsVM>());
        }


        return View("Index", returnResponse.entity);
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
        (ExecutionState executionState, PermissionHeaderSettingsVM entity, string message) returnResponse = _PermissionHeaderSettingsService.GetById(id);

        //ViewBag.CommitteeTypeId = new SelectList(EnumHelper.GetEnumDropdowns<CommitteeType>(), "Id", "Name", returnResponse.entity.CommitteeTypeId);
        //ViewBag.ExDesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<ExecutiveDesignationType>(), "Id", "Name", returnResponse.entity.ExDesignatinId);
        //ViewBag.SubExecutiveDesignationId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", returnResponse.entity.SubCommitteeDesignationId);


        //ViewBag.SubDesignationId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", returnResponse.entity.SubCommitteeDesignationId);
        //ViewBag.ExecutiveMemberTypeId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", returnResponse.entity.DesignatinId);

        return View(returnResponse.entity);
    }


    public ActionResult Create()
    {
        PermissionHeaderSettingsVM entity = new PermissionHeaderSettingsVM();

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


        ViewBag.ModuleEnumId = new SelectList(EnumHelper.GetEnumDropdowns<ModuleEnum>(), "Id", "Name");
        //ViewBag.OtherMemberId = new SelectList("");

        (ExecutionState executionState, List<UserRoleVM> entity, string message) returnResponseUserRole = _UserRoleService.List();
        if (returnResponseUserRole.entity != null)
        {
            ViewBag.UserRoleId = new SelectList(returnResponseUserRole.entity ?? new List<UserRoleVM>(), "Id", "RoleName");
        }
        (ExecutionState executionState, List<UserVM> entity, string message) returnResponseUser = _UserService.List();
        if (returnResponseUser.entity != null)
        {
            ViewBag.UserId = new SelectList(returnResponseUser.entity, "Id", "UserName");
        }

        //Authority
        (ExecutionState executionState, List<UserRoleVM> entity, string message) returnResponseUserRoleAuthority = _UserRoleService.List();
        if (returnResponseUserRoleAuthority.entity != null)
        {
            ViewBag.AuthorityUserRoleId = new SelectList(returnResponseUserRoleAuthority.entity ?? new List<UserRoleVM>(), "Id", "RoleName");
        }
        (ExecutionState executionState, List<UserVM> entity, string message) returnResponseUserAuthority = _UserService.List();
        if (returnResponseUserAuthority.entity != null)
        {
            ViewBag.AuthorityUserId = new SelectList(returnResponseUserAuthority.entity, "Id", "UserName");
        }

        //Access list
        (ExecutionState executionState, List<AccesslistVM> entity, string message) returnResponseAccesslist = _AccesslistService.List();
        if (returnResponseAccesslist.entity != null)
        {
            ViewBag.AccesslistId = new SelectList(returnResponseAccesslist.entity.Where(x=>x.IsAvailableForApproval == true), "Id", "Mask");
        }


        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(PermissionHeaderSettingsVM entity)
    {
        //entity.Name = "ExecutiveCommittee";
        //entity.NameBn = "ExecutiveCommittee";
        try
        {
            //if (ModelState.IsValid)
            //{

            //(ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) returnResponseCheckModule = _PermissionHeaderSettingsService.GetPermissionHeaderSettingsByModuleEnumId(Convert.ToInt64(entity.AccesslistId));
            //if (returnResponseCheckModule.entity.Count > 0)
            //{
            //    HttpContext.Session.SetString("Message", "Module already exists!");
            //    //HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
            //    return Json(
            //    new
            //    {
            //        Success =  ExecutionState.Failure,
            //        Data = new List<PermissionHeaderSettingsVM>(),
            //        Message = "Module already exists!"
            //    },
            //    SerializerOption.Default);
            //}


            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            entity.PermissionRowSettings = JsonConvert.DeserializeObject<List<PermissionRowSettingsVM>>(entity.PermissionRowSettingsJson);

            (ExecutionState executionState, PermissionHeaderSettingsVM entity, string message) returnResponse = _PermissionHeaderSettingsService.Create(entity);
            //                    Session["Message"] = returnResponse.message;
            //                    Session["executionState"] = returnResponse.executionState;

            if (returnResponse.executionState.ToString() != "Created")
            {
                HttpContext.Session.SetString("Message", "Permission Settings has been created successfully");
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
                HttpContext.Session.SetString("Message", "Permission Settings has been created successfully");
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

        (ExecutionState executionState, PermissionHeaderSettingsVM entity, string message) returnResponse = _PermissionHeaderSettingsService.GetById(id);

        (ExecutionState executionState, List<UserRoleVM> entity, string message) returnResponseUserRole = _UserRoleService.List();
        if (returnResponseUserRole.entity != null)
        {
            ViewBag.UserRoleId = new SelectList(returnResponseUserRole.entity ?? new List<UserRoleVM>(), "Id", "RoleName", returnResponse.entity.UserRoleId);
        }

        (ExecutionState executionState, List<UserVM> entity, string message) returnResponseUser = _UserService.List();
        if (returnResponseUser.entity != null)
        {
            ViewBag.UserId = new SelectList(returnResponseUser.entity ?? new List<UserVM>(), "Id", "UserName", returnResponse.entity.UserId);
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


        //ViewBag.ModuleEnumId = new SelectList(EnumHelper.GetEnumDropdowns<ModuleEnum>(), "Id", "Name", (int)returnResponse.entity.ModuleEnumId);

        //Access list
        (ExecutionState executionState, List<AccesslistVM> entity, string message) returnResponseAccesslist = _AccesslistService.List();
        if (returnResponseAccesslist.entity != null)
        {
            ViewBag.AccesslistId = new SelectList(returnResponseAccesslist.entity.Where(x => x.IsAvailableForApproval == true), "Id", "Mask", returnResponse.entity.AccesslistId);
        }


        //Authority
        (ExecutionState executionState, List<UserRoleVM> entity, string message) returnResponseUserRoleAuthority = _UserRoleService.List();
        if (returnResponseUserRoleAuthority.entity != null)
        {
            ViewBag.AuthorityUserRoleId = new SelectList(returnResponseUserRoleAuthority.entity ?? new List<UserRoleVM>(), "Id", "RoleName");
        }
        (ExecutionState executionState, List<UserVM> entity, string message) returnResponseUserAuthority = _UserService.List();
        if (returnResponseUserAuthority.entity != null)
        {
            ViewBag.AuthorityUserId = new SelectList(returnResponseUserAuthority.entity, "Id", "UserName");
        }



        return View(returnResponse.entity);
    }


    [HttpPost]
    public ActionResult Edit(int id, PermissionHeaderSettingsVM entity)
    {
        try
        {
            //if (ModelState.IsValid)
            //{

            entity.PermissionRowSettings = JsonConvert.DeserializeObject<List<PermissionRowSettingsVM>>(entity.PermissionRowSettingsJson);
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(CategoryController.Index), "Category");
            }
            entity.IsActive = true;
            entity.IsDeleted = false;
            entity.UpdatedAt = DateTime.Now;

           
            (ExecutionState executionState, PermissionHeaderSettingsVM entity, string message) returnResponse = _PermissionHeaderSettingsService.Update(entity);
            //                    Session["Message"] = returnResponse.message;
            //                    Session["executionState"] = returnResponse.executionState;
            if (returnResponse.executionState.ToString() != "Updated")
            {
                return View(entity);
            }
            else
            {
                HttpContext.Session.SetString("Message", "Permission Settings has been Updated successfully");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                return Json(
          new
          {
              Success = returnResponse.executionState == ExecutionState.Retrieved,
              Data = returnResponse.entity,
              Message = returnResponse.message
          },
          SerializerOption.Default);

                // return RedirectToAction("Index", "PermissionHeaderSettings");
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
        var result = _PermissionHeaderSettingsService.SoftDelete(id);
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


    [HttpGet]
    public ActionResult DeleteMemberById(long id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _PermissionRowSettingsService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, PermissionRowSettingsVM entity, string message) returnResponse = _PermissionRowSettingsService.Delete(id);
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





    //public ActionResult ActiveInactive(long Id)
    //{
    //    var result = _PermissionHeaderSettingsService.GetById(Id);
    //    result.entity.PermissionHeaderSettingsMembers = new List<PermissionHeaderSettingsMemberVM>();
    //    if (result.entity != null)
    //    {
    //        if (result.entity.CommitteeApprovalStatus == 1)
    //        {
    //            result.entity.IsInActiveCommittee = true;
    //            result.entity.CommitteeApprovalStatus = (int)CommitteeApprovalStatus.InActive;
    //            result.entity.PermissionHeaderSettingsMembers = null;

    //            var returnResponse = _PermissionHeaderSettingsService.Update(result.entity);
    //            return RedirectToAction("Index", "PermissionHeaderSettings");
    //        }
    //        else
    //        {
    //            result.entity.IsInActiveCommittee = true;
    //            var returnResponse = _PermissionHeaderSettingsService.Update(result.entity);
    //            return RedirectToAction("Index", "PermissionHeaderSettings");
    //        }
    //    }
    //    return RedirectToAction("Index", "PermissionHeaderSettings");
    //}


    //[HttpPost]
    //public JsonResult GetDesignationByDesigOrSubDesigId(CommitteeDesignationFilterVM filter)
    //{

    //    var designationLists = _SubCommitteeDesignationService.ListByFilter(filter);

    //    return Json(new { Entity = designationLists.entity, Message = designationLists.message, designationLists.executionState }, SerializerOption.Default);
    //}


    //public ActionResult SendRequest(int id)
    //{
    //    var result = _PermissionHeaderSettingsService.GetById(id);

    //    result.entity.CommitteeApprovalDate = DateTime.Now;
    //    result.entity.CommitteeApprovalBy = 0;
    //    result.entity.IsInActiveCommittee = true;
    //    result.entity.PermissionHeaderSettingsMembers = null;

    //    result.entity.CommitteeApprovalStatus = (int) CommitteeApprovalStatus.SentRequest;


    //    var returnResponse = _PermissionHeaderSettingsService.Update(result.entity);
    //    return RedirectToAction("Index", "PermissionHeaderSettings");
    //}

    //public ActionResult RequestList()
    //{
    //    AuthLocationHelper.GenerateViewBagForForestAndCivil(
    //        HttpContext,
    //        ViewBag,
    //        _ForestCircleService,
    //        _ForestDivisionService,
    //        _ForestRangeService,
    //        _ForestBeatService,
    //        _ForestFcvVcfService,
    //        _DivisionService,
    //        _DistrictService,
    //        _UpazillaService,
    //        _UnionService
    //    );

    //    (ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) returnResponseIsActiveData = _PermissionHeaderSettingsService.List();

    //    if (returnResponseIsActiveData.entity == null)
    //    {
    //        return View(new List<PermissionHeaderSettingsVM>());
    //    }

    //    foreach (var isActiveObj in returnResponseIsActiveData.entity)
    //    {
    //        if (isActiveObj != null)
    //        {
    //            if (isActiveObj.CommitteeEndDate.AddDays(1) < DateTime.Now)
    //            {
    //                isActiveObj.IsInActiveCommittee = true;
    //            }

    //            var returnResponseIsActiveUpdate = _PermissionHeaderSettingsService.Update(isActiveObj);
    //        }
    //    }

    //    (ExecutionState executionState, List<PermissionHeaderSettingsVM> entity, string message) returnResponse = _PermissionHeaderSettingsService.List();

    //    foreach (var item in returnResponse.entity)
    //    {
    //        item.CommitteeTypeName = item.CommitteeTypeId.GetEnumDisplayName();
    //    }



    //    return View(returnResponse.entity);
    //}


    public ActionResult GetUserNameByUserRoleId(long userRoleId)
    {
        var result = _PermissionHeaderSettingsService.GetUserNameByUserRoleId(userRoleId);
       
        return Json(result.entity, SerializerOption.Default);
    }

    [HttpPost]
    public ActionResult GetFilterByForestId(ExecutiveCommitteeFilterVM filter)
    {
        var result = _PermissionHeaderSettingsService.GetFilterByForestId(filter);
        return Json(result.entity, SerializerOption.Default);
    }

    

}
