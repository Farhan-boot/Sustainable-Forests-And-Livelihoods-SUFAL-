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
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Implementation.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.ForestManagement;


[SessionAuthorize]
public class CommitteeManagementController : Controller
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

    //For new logic
    private readonly ICommitteeTypeConfigurationService _CommitteeTypeConfigurationService;
    private readonly ICommitteesConfigurationService _CommitteesConfigurationService;
    private readonly ICommitteeDesignationsConfigurationService _CommitteeDesignationsConfigurationService;

    //New for Approval
    private readonly IPermissionHeaderSettingsService _PermissionHeaderSettingsService;
    private readonly IPermissionRowSettingsService _PermissionRowSettingsService;
    private readonly IUserService _UserService;
    private readonly IApprovalLogForCfmService _ApprovalLogForCfmService;
    private readonly IAccountService _AccountService;



    public CommitteeManagementController(HttpHelper httpHelper)
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

        _CommitteeTypeConfigurationService = new CommitteeTypeConfigurationService(httpHelper);
        _CommitteesConfigurationService = new CommitteesConfigurationService(httpHelper);
        _CommitteeDesignationsConfigurationService = new CommitteeDesignationsConfigurationService(httpHelper);

        //New multi approval
        _PermissionHeaderSettingsService = new PermissionHeaderSettingsService(httpHelper);
        _PermissionRowSettingsService = new PermissionRowSettingsService(httpHelper);
        _UserService = new UserService(httpHelper);
        _ApprovalLogForCfmService = new ApprovalLogForCfmService(httpHelper);
        _AccountService = new AccountService(httpHelper);
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


        /*
        (ExecutionState executionState, List<CommitteeManagementVM> entity, string message) returnResponseIsActiveData = _CommitteeManagementService.List();

        if (returnResponseIsActiveData.entity == null)
        {
            return View(new List<CommitteeManagementVM>());
        }


        foreach (var isActiveObj in returnResponseIsActiveData.entity)
        {
            if (isActiveObj != null)
            {
                if (isActiveObj.CommitteeEndDate.AddDays(1) < DateTime.Now)
                {
                    isActiveObj.IsInActiveCommittee = true;
                    isActiveObj.CommitteeApprovalStatus = (int) CommitteeApprovalStatus.Expired;
                }
               
               var returnResponseIsActiveUpdate = _CommitteeManagementService.Update(isActiveObj);
            }
        }
        */


        //(ExecutionState executionState, List<CommitteeManagementVM> entity, string message) returnResponse = _CommitteeManagementService.List();

        //foreach (var item in returnResponse.entity ?? new List<CommitteeManagementVM>())
        //{
           // item.CommitteeTypeName = item.CommitteeTypeId.GetEnumDisplayName();
        //}



        //New Logic for mulity approval Start

        var permissionHeader = _PermissionRowSettingsService.List();
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 29).Select(x => x.Id).FirstOrDefault();
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

        //var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x=>x.Id).FirstOrDefault(x => x?.ReceiverRoleId == userRoleId && x.CommitteeManagementId != null);

        var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.Id).Where(x => x.CommitteeManagementId != null).FirstOrDefault()?.ReceiverRoleId == userRoleId;


        ViewBag.CheckIsApprove = false;
        if (checkIsApprove == false)
        {
            ViewBag.CheckIsApprove = false;
        }
        else
        {
            ViewBag.CheckIsApprove = true;
        }

        // ViewBag.CheckIsApprove = checkIsApprove ?? false;

        //returnResponse.entity
        return View(new List<CommitteeManagementVM>());
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


        //(ExecutionState executionState, List<CommitteeManagementVM> entity, string message) returnResponse = _CommitteeManagementService.GetByFilter(filter);

        //if (returnResponse.entity == null)
        //{
        //    return View(new List<CommitteeManagementVM>());
        //}

        //returnResponse.entity
        return View("Index", new List<CommitteeManagementVM>());
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
        (ExecutionState executionState, CommitteeManagementVM entity, string message) returnResponse = _CommitteeManagementService.GetById(id);

        //ViewBag.CommitteeTypeId = new SelectList(EnumHelper.GetEnumDropdowns<CommitteeType>(), "Id", "Name", returnResponse.entity.CommitteeTypeId);
        //ViewBag.ExDesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<ExecutiveDesignationType>(), "Id", "Name", returnResponse.entity.ExDesignatinId);
        //ViewBag.SubExecutiveDesignationId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", returnResponse.entity.SubCommitteeDesignationId);


        //ViewBag.SubDesignationId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", returnResponse.entity.SubCommitteeDesignationId);
        //ViewBag.ExecutiveMemberTypeId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", returnResponse.entity.DesignatinId);

        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        CommitteeManagementVM entity = new CommitteeManagementVM();

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

        //ViewBag.CircleId = new SelectList("");


        ViewBag.DesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name");
        ViewBag.CommitteeTypeId = new SelectList(EnumHelper.GetEnumDropdowns<CommitteeType>(), "Id", "Name");
        ViewBag.GenderId = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.ExDesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<ExecutiveDesignationType>(), "Id", "Name");
        ViewBag.OtherMemberId = new SelectList("");

        //(ExecutionState executionState, List<ForestCircleVM> entity, string message) returnResponseCircle = _ForestCircleService.List();
        //ViewBag.ForestCircleId = new SelectList(returnResponseCircle.entity ?? new List<ForestCircleVM>(), "Id", "Name");

        (ExecutionState executionState, List<EthnicityVM> entity, string message) returnResponseEthnicity = _EthnicityService.List();
        if (returnResponseEthnicity.entity != null)
        {
            ViewBag.EthnicityId = new SelectList(returnResponseEthnicity.entity, "Id", "Name", returnResponseEthnicity.entity);
        }
        (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) returnResponseOtherCommitteeMember = _OtherCommitteeMemberService.List();
        if (returnResponseOtherCommitteeMember.entity != null)
        {
            ViewBag.OtherMemberId = new SelectList(returnResponseOtherCommitteeMember.entity, "Id", "FullName", returnResponseOtherCommitteeMember.entity);
        }

        (ExecutionState executionState, List<NgoVM> entity, string message) returnResponseNgo = _NgoService.List();
        if (returnResponseNgo.entity != null)
        {
            ViewBag.NgoId = new SelectList(returnResponseNgo.entity, "Id", "Name", returnResponseNgo.entity);
        }


        // Civil administration
        (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponseCivilDivision = _DivisionService.List();
        ViewBag.DivisionId = new SelectList(returnResponseCivilDivision.entity ?? new List<DivisionVM>(), "Id", "Name", returnResponseCivilDivision.entity);

        // Executive Under Sub-Designation

        ViewBag.FACTypeId = new SelectList(EnumHelper.GetEnumDropdowns<FACType>(), "Id", "Name");
        ViewBag.PCTypeId = new SelectList(EnumHelper.GetEnumDropdowns<PCType>(), "Id", "Name");
        ViewBag.SACTypeId = new SelectList(EnumHelper.GetEnumDropdowns<SACType>(), "Id", "Name");
        ViewBag.VCSCTypeId = new SelectList(EnumHelper.GetEnumDropdowns<VCSCType>(), "Id", "Name");
        ViewBag.FPCCTypeId = new SelectList(EnumHelper.GetEnumDropdowns<FPCCType>(), "Id", "Name");

        ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name");


        //New Logic 
        ViewBag.CommitteeTypeConfigurationId = new SelectList(new List<CommitteeTypeConfigurationVM>(), "Id", "CommitteeTypeName");
        ViewBag.CommitteesConfigurationId = new SelectList(new List<CommitteesConfigurationVM>(), "Id", "CommitteeName");
        ViewBag.CommitteeDesignationsConfigurationId = new SelectList(new List<CommitteeDesignationsConfigurationVM>(), "Id", "DesignationName");

        return View(entity);
    }


    [HttpPost]
    public ActionResult Create(CommitteeManagementVM entity)
    {
        //entity.Name = "ExecutiveCommittee";
        //entity.NameBn = "ExecutiveCommittee";
        entity.IsInActiveCommittee = true;
        entity.CommitteeApprovalBy = 0;
        entity.CommitteeApprovalDate = DateTime.Now;
        entity.CommitteeApprovalStatus = (int)CommitteeApprovalStatus.InActive; //2
        entity.ApprovalStatus = (long)Helper.Enum.ForestManagement.CommitteeManagementApprovalStatus.Panding;

        try
        {
            //if (ModelState.IsValid)
            //{
            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            entity.CommitteeManagementMembers = JsonConvert.DeserializeObject<List<CommitteeManagementMemberVM>>(entity.CommitteeManagementMembersJson);

            (ExecutionState executionState, CommitteeManagementVM entity, string message) returnResponse = _CommitteeManagementService.Create(entity);
            //                    Session["Message"] = returnResponse.message;
            //                    Session["executionState"] = returnResponse.executionState;

            if (returnResponse.executionState.ToString() != "Created")
            {
                HttpContext.Session.SetString("Message", "Committee has been created successfully");
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
                HttpContext.Session.SetString("Message", "Committee has been created successfully");
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
        (ExecutionState executionState, CommitteeManagementVM entity, string message) returnResponse = _CommitteeManagementService.GetById(id);


        ViewBag.CommitteeTypeId = new SelectList(EnumHelper.GetEnumDropdowns<CommitteeType>(), "Id", "Name", (int)returnResponse.entity.CommitteeTypeId);

        if (returnResponse.entity.SubCommitteeTypeId != null)
        {
            ViewBag.DesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", (int)returnResponse.entity.SubCommitteeTypeId);
        }
        else
        {
            ViewBag.DesignatinId = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", (int)0);
        }

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
        if (returnResponseNgo.entity != null)
        {
            ViewBag.NgoId = new SelectList(returnResponseNgo.entity, "Id", "Name", returnResponse.entity.NgoId);
            ViewBag.NgoUiId = returnResponse.entity.NgoId;
        }

        (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) returnResponseOtherCommitteeMember = _OtherCommitteeMemberService.List();
        if (returnResponseOtherCommitteeMember.entity != null)
        {
            ViewBag.OtherMemberId = new SelectList(returnResponseOtherCommitteeMember.entity, "Id", "FullName");
        }
        else
        {
            ViewBag.OtherMemberId = new SelectList(new List<OtherCommitteeMemberVM>(), "Id", "FullName");
        }



        //(ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) returnResponseForestFcvType = _ForestFcvVcfService.List();

        //if (returnResponseForestFcvType.entity != null)
        //{
        //    List<ForestFcvVcfVM> listOfFcv = new List<ForestFcvVcfVM>();
        //    foreach (var fcvType in returnResponseForestFcvType.entity)
        //    {
        //        if (fcvType.IsFcv == true)
        //        {
        //            listOfFcv.Add(fcvType);
        //        }
        //    }

        //    ViewBag.BeneficiaryId = new SelectList(listOfFcv, "Id", "Name", returnResponse.entity.OfficeBearersId);
        //}


        //new logic add
        (ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message) returnResponseCommitteeTypeConfiguration = _CommitteeTypeConfigurationService.List();
        if (returnResponseCommitteeTypeConfiguration.entity != null)
        {
            ViewBag.CommitteeTypeConfigurationId = new SelectList(returnResponseCommitteeTypeConfiguration.entity, "Id", "CommitteeTypeName", (int)returnResponse.entity.CommitteeTypeConfigurationId);
        }

        (ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message) returnResponseCommitteesConfiguration = _CommitteesConfigurationService.List();
        if (returnResponseCommitteesConfiguration.entity != null)
        {
            ViewBag.CommitteesConfigurationId = new SelectList(returnResponseCommitteesConfiguration.entity, "Id", "CommitteeName", (int)returnResponse.entity.CommitteesConfigurationId);
        }

        (ExecutionState executionState, List<CommitteeDesignationsConfigurationVM> entity, string message) returnResponseCommitteeDesignationsConfiguration = _CommitteeDesignationsConfigurationService.List();
        if (returnResponseCommitteeDesignationsConfiguration.entity != null)
        {
            ViewBag.CommitteeDesignationsConfigurationId = new SelectList(returnResponseCommitteeDesignationsConfiguration.entity.Where(x => x.CommitteesConfigurationId == (int)returnResponse.entity.CommitteesConfigurationId).ToList(), "Id", "DesignationName");
        }






        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, CommitteeManagementVM entity)
    {
        try
        {
            //if (ModelState.IsValid)
            //{

            entity.CommitteeManagementMembers = JsonConvert.DeserializeObject<List<CommitteeManagementMemberVM>>(entity.CommitteeManagementMembersJson);
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(CategoryController.Index), "Category");
            }
            entity.IsActive = true;
            entity.IsDeleted = false;
            entity.UpdatedAt = DateTime.Now;
            entity.IsInActiveCommittee = true;

            entity.CommitteeApprovalStatus = (int)CommitteeApprovalStatus.InActive;
            entity.ApprovalStatus = (int)CommitteeManagementApprovalStatus.Panding;


            if (entity.CommitteeEndDate.Date >= DateTime.Now.Date)
            {
                entity.CommitteeApprovalStatus = (int)CommitteeApprovalStatus.InActive;
                entity.IsInActiveCommittee = true;
            }



            (ExecutionState executionState, CommitteeManagementVM entity, string message) returnResponse = _CommitteeManagementService.Update(entity);
            //                    Session["Message"] = returnResponse.message;
            //                    Session["executionState"] = returnResponse.executionState;
            if (returnResponse.executionState.ToString() != "Updated")
            {
                return View(entity);
            }
            else
            {
                HttpContext.Session.SetString("Message", "Committee has been Updated successfully");
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
        var result = _CommitteeManagementService.SoftDelete(id);
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


    //public JsonResult Delete(int id)
    //{
    //    (ExecutionState executionState, string message) CheckDataExistOrNot = _CommitteeManagementService.DoesExist(id);
    //    string message = "Failed, You can't delete this item.";

    //    if (CheckDataExistOrNot.executionState.ToString() != "Success")
    //    {
    //        return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
    //    }

    //    (ExecutionState executionState, CommitteeManagementVM entity, string message) returnResponse = _CommitteeManagementService.Delete(id);
    //    if (returnResponse.executionState.ToString() == "Updated")
    //    {
    //        returnResponse.message = "Item deleted successfully.";
    //    }
    //    else
    //    {
    //        returnResponse.message = "Failed to delete this item.";
    //    }

    //    return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
    //}




    [HttpGet]
    public ActionResult DeleteMemberById(long id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _CommitteeManagementMemberService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, CommitteeManagementMemberVM entity, string message) returnResponse = _CommitteeManagementMemberService.Delete(id);
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



    //[RequireAuthRole(Roles = RoleNames.GENERAL_DELETE_PERMISSION, RedirectTo = "ExecutiveCommittee/Index")]
    //[HttpPost]
    //public ActionResult Delete(int id, ExecutiveCommitteeVM entity)
    //{
    //    try
    //    {
    //        if (id != entity.Id)
    //        {
    //            return RedirectToAction(nameof(CategoryController.Index), "Category");
    //        }

    //        entity.IsDeleted = true;
    //        entity.IsActive = false;
    //        entity.UpdatedAt = DateTime.Now;

    //        if (entity.DesignatinId == null)
    //        {
    //            entity.DesignatinId = 0;
    //            entity.ExDesignatinId = entity.ExDesignatinId;
    //        }
    //        else if (entity.ExDesignatinId == null)
    //        {
    //            entity.ExDesignatinId = 0;
    //            entity.DesignatinId = entity.DesignatinId;
    //        }



    //        (ExecutionState executionState, ExecutiveCommitteeVM entity, string message) returnResponse = _ExecutiveCommitteeService.Update(entity);
    //        //                Session["Message"] = returnResponse.message;
    //        //                Session["executionState"] = returnResponse.executionState;
    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}


    public ActionResult GetOtherCommitteeMemberById(long Id)
    {
        var result = _OtherCommitteeMemberService.GetById(Id);
        if (result.entity == null)
        {
            return Json(new List<OtherCommitteeMemberVM>(), SerializerOption.Default);
        }

        return Json(result.entity, SerializerOption.Default);
    }


    public ActionResult ActiveInactive(long Id)
    {
        var result = _CommitteeManagementService.GetById(Id);
        result.entity.CommitteeManagementMembers = new List<CommitteeManagementMemberVM>();
        if (result.entity != null)
        {
            if (result.entity.CommitteeApprovalStatus == 1)
            {
                result.entity.IsInActiveCommittee = true;
                result.entity.CommitteeApprovalStatus = (int)CommitteeApprovalStatus.InActive;
                result.entity.CommitteeManagementMembers = null;

                var returnResponse = _CommitteeManagementService.Update(result.entity);
                return RedirectToAction("Index", "CommitteeManagement");
            }
            else
            {
                result.entity.IsInActiveCommittee = true;
                var returnResponse = _CommitteeManagementService.Update(result.entity);
                return RedirectToAction("Index", "CommitteeManagement");
            }
        }
        return RedirectToAction("Index", "CommitteeManagement");
    }


    [HttpPost]
    public JsonResult GetDesignationByDesigOrSubDesigId(CommitteeDesignationFilterVM filter)
    {

        var designationLists = _SubCommitteeDesignationService.ListByFilter(filter);

        return Json(new { Entity = designationLists.entity, Message = designationLists.message, designationLists.executionState }, SerializerOption.Default);
    }


    public ActionResult SendRequest(int id)
    {
        var result = _CommitteeManagementService.GetById(id);

        result.entity.CommitteeApprovalDate = DateTime.Now;
        result.entity.CommitteeApprovalBy = 0;
        result.entity.IsInActiveCommittee = true;
        result.entity.CommitteeManagementMembers = null;

        result.entity.CommitteeApprovalStatus = (int)CommitteeApprovalStatus.SentRequest;


        var returnResponse = _CommitteeManagementService.Update(result.entity);
        return RedirectToAction("Index", "CommitteeManagement");
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

        (ExecutionState executionState, List<CommitteeManagementVM> entity, string message) returnResponse = _CommitteeManagementService.List();

        if (returnResponse.entity == null)
        {
            return View(new List<CommitteeManagementVM>());
        }

        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        //new
        long userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));



        var returnResponseApprovalLogForCfm = _ApprovalLogForCfmService.List().entity?.OrderByDescending(x => x.CreatedAt)?.Where(x => x?.ReceiverRoleId == userRoleId).ToList() ?? new List<ApprovalLogForCfmVM>();


        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 29).Select(x => x.Id).FirstOrDefault();

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


        var returnResponsePermissionHeaderSettings = _PermissionHeaderSettingsService.List().entity.Where(x => x.AccesslistId == 29).FirstOrDefault();
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
            return View(new List<CommitteeManagementVM>());
        }

        if (checkIsLetestReceiver?.UserRoleId == userRoleId)
        {
            return View(returnResponse.entity);
        }
        else
        {
            return View(new List<CommitteeManagementVM>());
        }

        return View(new List<CommitteeManagementVM>());
    }

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

    //    (ExecutionState executionState, List<CommitteeManagementVM> entity, string message) returnResponseIsActiveData = _CommitteeManagementService.List();

    //    if (returnResponseIsActiveData.entity == null)
    //    {
    //        return View(new List<CommitteeManagementVM>());
    //    }

    //    foreach (var isActiveObj in returnResponseIsActiveData.entity)
    //    {
    //        if (isActiveObj != null)
    //        {
    //            if (isActiveObj.CommitteeEndDate.AddDays(1) < DateTime.Now)
    //            {
    //                isActiveObj.IsInActiveCommittee = true;
    //            }

    //            var returnResponseIsActiveUpdate = _CommitteeManagementService.Update(isActiveObj);
    //        }
    //    }

    //    (ExecutionState executionState, List<CommitteeManagementVM> entity, string message) returnResponse = _CommitteeManagementService.List();

    //    foreach (var item in returnResponse.entity)
    //    {
    //        item.CommitteeTypeName = item.CommitteeTypeId.GetEnumDisplayName();
    //    }



    //    return View(returnResponse.entity);
    //}



    //public ActionResult AcceptedById(int id)
    //{
    //    var result = _CommitteeManagementService.GetById(id);
    //    result.entity.CommitteeApprovalStatus = (int) CommitteeApprovalStatus.Active;
    //    result.entity.CommitteeApprovalDate = DateTime.Now;
    //    result.entity.CommitteeApprovalBy = 0;
    //    result.entity.IsInActiveCommittee = false;
    //    result.entity.CommitteeManagementMembers = null;

    //    var returnResponse = _CommitteeManagementService.Update(result.entity);
    //    return RedirectToAction("RequestList", "CommitteeManagement");
    //}

    public ActionResult AcceptedById(int id)
    {
        var result = _CommitteeManagementService.GetById(id);
        result.entity.CommitteeApprovalStatus = (int)CommitteeApprovalStatus.Active;
        result.entity.CommitteeApprovalDate = DateTime.Now;
        result.entity.CommitteeApprovalBy = 0;
        result.entity.IsInActiveCommittee = false;
        result.entity.CommitteeManagementMembers = null;
        result.entity.ApprovalLogForCfms = null;


        result.entity.ApprovalStatus = (long)Helper.Enum.ForestManagement.CommitteeManagementApprovalStatus.Approve;
        result.entity.UpdatedAt = DateTime.Now;
        var returnResponse = _CommitteeManagementService.Update(result.entity);
        return RedirectToAction("RequestList", "CommitteeManagement");
    }





    public ActionResult RejectedById(int id)
    {
        var result = _CommitteeManagementService.GetById(id);
        result.entity.CommitteeApprovalDate = DateTime.Now;
        result.entity.CommitteeApprovalBy = 0;
        result.entity.IsInActiveCommittee = true;
        result.entity.CommitteeApprovalStatus = (int)CommitteeApprovalStatus.Rejectted;
        result.entity.CommitteeManagementMembers = null;


        var returnResponse = _CommitteeManagementService.Update(result.entity);
        return RedirectToAction("RequestList", "CommitteeManagement");
    }



    //new logic

    public ActionResult GetCommitteeTypeConfigurationByFcvOrVcfId(long id)
    {
        try
        {
            var result = _CommitteeTypeConfigurationService.GetCommitteeTypeConfigurationByFcvOrVcfId(id);
            return Json(
                 new
                 {
                     Success = result.executionState == ExecutionState.Retrieved,
                     Data = result.entity,
                     Message = result.message
                 },
                 SerializerOption.Default);
        }
        catch
        {
            return Json(
                  new
                  {
                      Success = "",
                      Data = "",
                      Message = ""
                  },
                  SerializerOption.Default);
        }
    }

    public ActionResult GetCommitteesConfigurationByCommitteeTypeConfigurationId(long id)
    {
        try
        {
            var result = _CommitteesConfigurationService.GetCommitteesConfigurationByCommitteeTypeConfigurationId(id);
            return Json(
                 new
                 {
                     Success = result.executionState == ExecutionState.Retrieved,
                     Data = result.entity,
                     Message = result.message
                 },
                 SerializerOption.Default);
        }
        catch
        {
            return Json(
                  new
                  {
                      Success = "",
                      Data = "",
                      Message = ""
                  },
                  SerializerOption.Default);
        }
    }

    public ActionResult GetCommitteeDesignationsConfigurationByCommitteesConfigurationId(long id)
    {
        try
        {
            var result = _CommitteeDesignationsConfigurationService.GetCommitteeDesignationsConfigurationByCommitteesConfigurationId(id);
            return Json(
                 new
                 {
                     Success = result.executionState == ExecutionState.Retrieved,
                     Data = result.entity,
                     Message = result.message
                 },
                 SerializerOption.Default);
        }
        catch
        {
            return Json(
                  new
                  {
                      Success = "",
                      Data = "",
                      Message = ""
                  },
                  SerializerOption.Default);
        }
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


    [HttpPost]
    public ActionResult GetBankAccountInfo(CommitteeManagementVM entity)
    {
        try
        {
            var obj = new AccountFilterVM()
            {
                ForestCircleId = entity.ForestCircleId,
                ForestDivisionId = entity.ForestDivisionId,
                ForestRangeId = entity.ForestRangeId,
                ForestBeatId = entity.ForestBeatId,
                ForestFcvVcfId = entity.ForestFcvVcfId,
                CommitteeTypeId = entity.CommitteeTypeConfigurationId,
                CommitteeId = entity.CommitteesConfigurationId
            };

            var result = _AccountService.GetByFilterBasic(obj);
            return Json(
                 new
                 {
                     Success = result.executionState == ExecutionState.Retrieved,
                     Data = result.entity,
                     Message = result.message
                 },
                 SerializerOption.Default);
        }
        catch
        {
            return Json(
                  new
                  {
                      Success = "",
                      Data = "",
                      Message = ""
                  },
                  SerializerOption.Default);
        }
    }



    //DataTable Get List using server site Pagination
    //[HttpPost]
    public ActionResult GetCommitteeManagementListByPagination(JqueryDatatableParams param)
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


        (ExecutionState executionState, PaginationResutlVM<CommitteeManagementVM> entity, string message) returnResponse = _CommitteeManagementService.GetByFilter(filter);

        foreach (var item in returnResponse.entity.aaData ?? new List<CommitteeManagementVM>())
        {
            item.CommitteeTypeName = item.CommitteeTypeId.GetEnumDisplayName();
        }

        //New Logic for mulity approval Start

        var permissionHeader = _PermissionRowSettingsService.List();
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 29).Select(x => x.Id).FirstOrDefault();
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

        //var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x=>x.Id).FirstOrDefault(x => x?.ReceiverRoleId == userRoleId && x.CommitteeManagementId != null);

        var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.Id).Where(x => x.CommitteeManagementId != null).FirstOrDefault()?.ReceiverRoleId == userRoleId;


        ViewBag.CheckIsApprove = false;
        if (checkIsApprove == false)
        {
            ViewBag.CheckIsApprove = false;
        }
        else
        {
            ViewBag.CheckIsApprove = true;
        }


        //var displayResult = returnResponse.entity?.Skip(param.iDisplayStart)
        //   .Take(param.iDisplayLength).ToList();
        //var totalRecords = returnResponse.entity.Count();


        foreach (var item in returnResponse.entity.aaData)
        {
            if (item.CommitteeApprovalStatus == null)
            {
                item.CommitteeApprovalStatusNmae = "---";
            }
            if (item.CommitteeApprovalStatus == 1)
            {
                item.CommitteeApprovalStatusNmae = "Active";
            }
            if (item.CommitteeApprovalStatus == 2 || item.CommitteeApprovalStatus == 0)
            {
                item.CommitteeApprovalStatusNmae = "Inactive";
            }
            if (item.CommitteeApprovalStatus == 3)
            {
                item.CommitteeApprovalStatusNmae = "Rejecte";
            }
            if (item.CommitteeApprovalStatus == 4)
            {
                item.CommitteeApprovalStatusNmae = "Expired";
            }
        }

        return Json(new
        {
            param.sEcho,
            iTotalRecords = returnResponse.entity.iTotalRecords,
            iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
            aaData = returnResponse.entity.aaData
        }, SerializerOption.Default);

        //return View(returnResponse.entity); 
    }


    [HttpPost]
    public ActionResult IndexFilterCommitteeManagementListByPagination(ExecutiveCommitteeFilterVM filter)
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

        filter.iDisplayStart = null;
        filter.iDisplayLength = null;


        (ExecutionState executionState, PaginationResutlVM<CommitteeManagementVM> entity, string message) returnResponse = _CommitteeManagementService.GetByFilter(filter);

        if (returnResponse.entity == null)
        {
            return View(new List<CommitteeManagementVM>());
        }

        foreach (var item in returnResponse.entity.aaData)
        {
            if (item.CommitteeApprovalStatus == null)
            {
                item.CommitteeApprovalStatusNmae = "---";
            }
            if (item.CommitteeApprovalStatus == 1)
            {
                item.CommitteeApprovalStatusNmae = "Active";
            }
            if (item.CommitteeApprovalStatus == 2 || item.CommitteeApprovalStatus == 0)
            {
                item.CommitteeApprovalStatusNmae = "Inactive";
            }
            if (item.CommitteeApprovalStatus == 3)
            {
                item.CommitteeApprovalStatusNmae = "Rejecte";
            }
            if (item.CommitteeApprovalStatus == 4)
            {
                item.CommitteeApprovalStatusNmae = "Expired";
            }
        }


        return Json(new
        {
            filter.sEcho,
            iTotalRecords = returnResponse.entity.iTotalRecords,
            iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
            aaData = returnResponse.entity.aaData
        }, SerializerOption.Default);

        //return View("Index", returnResponse.entity);

    }

}

public class JqueryDatatableParams
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