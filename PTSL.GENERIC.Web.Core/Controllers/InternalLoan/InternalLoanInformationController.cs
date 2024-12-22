using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Trades;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AIG;
using PTSL.GENERIC.Web.Core.Services.Implementation.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.InternalLoan;
using PTSL.GENERIC.Web.Core.Services.Implementation.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Implementation.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Implementation.Trades;
using PTSL.GENERIC.Web.Core.Services.Interface.AIG;
using PTSL.GENERIC.Web.Core.Services.Interface.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.InternalLoan;
using PTSL.GENERIC.Web.Core.Services.Interface.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Interface.Trades;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.InternalLoan;

[SessionAuthorize]
public class InternalLoanInformationController : Controller
{
    private readonly IInternalLoanInformationService _InternalLoanInformationService;
    private readonly IRepaymentInternalLoanService _RepaymentInternalLoanService;

    private readonly INgoService _ngoService;
    private readonly ITradeService _tradeService;
    private readonly IFirstSixtyPercentageLDFService _firstSixtyPercentageLDFService;
    private readonly ISecondFourtyPercentageLDFService _secondFourtyPercentageLDFService;
    private readonly IRepaymentLDFService _RepaymentLDFService;
    private readonly ILDFProgressService _lDFProgressService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;
    private readonly IInternalLoanInformationFileService _InternalLoanInformationFileService;
    
    private readonly IUserService _UserService;
    private readonly IPermissionHeaderSettingsService _PermissionHeaderSettingsService;
    private readonly IPermissionRowSettingsService _PermissionRowSettingsService;
    private readonly IApprovalLogForCfmService _ApprovalLogForCfmService;
    

    private readonly FileHelper _fileHelper;

    public InternalLoanInformationController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _InternalLoanInformationService = new InternalLoanInformationService(httpHelper);
        _RepaymentInternalLoanService = new RepaymentInternalLoanService(httpHelper);

        _firstSixtyPercentageLDFService = new FirstSixtyPercentageLDFService(httpHelper);
        _secondFourtyPercentageLDFService = new SecondFourtyPercentageLDFService(httpHelper);
        _RepaymentLDFService = new RepaymentLDFService(httpHelper);
        _lDFProgressService = new LDFProgressService(httpHelper);

        _ngoService = new NgoService(httpHelper);
        _tradeService = new TradeService(httpHelper);

        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);
        _InternalLoanInformationFileService = new InternalLoanInformationFileService(httpHelper);

        _UserService = new UserService(httpHelper);
        _PermissionHeaderSettingsService = new PermissionHeaderSettingsService(httpHelper);
        _PermissionRowSettingsService = new PermissionRowSettingsService(httpHelper);
        _ApprovalLogForCfmService = new ApprovalLogForCfmService(httpHelper);



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

        var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext, 50);
       
        (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) returnResponse = _InternalLoanInformationService.GetInternalLoanInformationByFilter(filter);

        if (returnResponse.entity == null)
        {
            return View(new List<InternalLoanInformationVM>());
        }

        //Extra Filter
        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");



        //New Multi Permition Start
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));


        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 58).Select(x => x.Id).FirstOrDefault();
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


        //New Multi Permition End


        return View(returnResponse.entity.aaData);
    }

    [HttpPost]
    public ActionResult IndexFilter(AIGBasicInformationFilterVM filter)
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

        (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) returnResponse = _InternalLoanInformationService.GetInternalLoanInformationByFilter(filter);

        //Extra Filter
        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender! : null);
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);


        //New Multi Permition Start
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));


        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 58).Select(x => x.Id).FirstOrDefault();
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
        //New Multi Permition End




        return View("Index", returnResponse.entity.aaData ?? new List<InternalLoanInformationVM>());
    }

    public ActionResult IndexFilter()
    {
        return RedirectToAction("Index");
    }

    public ActionResult Details(int? id)
    {
        if (id == null || id < 1)
        {
            return NotFound();
        }
        (ExecutionState executionState, InternalLoanInformationVM entity, string message) returnResponse = _InternalLoanInformationService.GetById(id);

        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {

        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
        ViewBag.SurveyId = new SelectList("");

        var trades = _tradeService.List().entity ?? new List<TradeVM>();
        foreach (var item in trades)
        {
            item.Name = $"{item.Name} ({item.NameBn})";
        }

        ViewBag.TradeId = new SelectList(trades, "Id", "Name");

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

        var entity = new InternalLoanInformationVM();

        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(InternalLoanInformationVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                entity.ApprovalStatus = (long) Helper.Enum.InternalLoan.InternalLoanApprovalStatus.Panding;

                // TODO: Add insert logic here
                var imageFiles = HttpContext.Request.Form.Files.GetFiles("InternalLoanInformationImageFiles[]");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("InternalLoanInformationDocumentFiles[]");

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



                (ExecutionState executionState, InternalLoanInformationVM entity, string message) returnResponse = _InternalLoanInformationService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Internal Loan Information has been created successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    //return RedirectToAction("FirstSixtyPercentage", new { aigId = returnResponse.entity.Id });

                    return RedirectToAction("Index");
                }
            }
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

    //public ActionResult Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }
    //    (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.GetById(id);

    //    return View(returnResponse.entity);
    //}

    //[HttpPost]
    //public ActionResult Edit(int id, AIGBasicInformationVM entity)
    //{
    //    try
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            // TODO: Add update logic here
    //            if (id != entity.Id)
    //            {
    //                return RedirectToAction(nameof(AIGBasicInformationController.Index), "AIGBasicInformation");
    //            }
    //            entity.IsActive = true;
    //            entity.IsDeleted = false;
    //            entity.UpdatedAt = DateTime.Now;
    //            (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.Update(entity);
    //            //                    Session["Message"] = returnResponse.message;
    //            //                    Session["executionState"] = returnResponse.executionState;
    //            if (returnResponse.executionState.ToString() != "Updated")
    //            {
    //                return View(entity);
    //            }
    //            else
    //            {
    //                return RedirectToAction("Index");
    //            }
    //        }

    //        //                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
    //        //                Session["executionState"] = ExecutionState.Failure;
    //        return View(entity);
    //    }
    //    catch
    //    {
    //        //                Session["Message"] = "Form Data Not Valid.";
    //        //                Session["executionState"] = ExecutionState.Failure;
    //        return View(entity);
    //    }
    //}

    //public ActionResult FirstSixtyPercentage(int? aigId)
    //{
    //    if (aigId == null)
    //    {
    //        return NotFound();
    //    }

    //    var result = _AIGBasicInformationService.GetById(aigId);
    //    if (result.executionState != ExecutionState.Retrieved || result.entity is null)
    //    {
    //        HttpContext.Session.SetString("Message", "AIG Information not found");
    //        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //        return RedirectToAction("Index");
    //    }

    //    return View(result.entity);
    //}

    //[HttpPost]
    //public ActionResult FirstSixtyPercentage(FirstSixtyPercentageLDFVM entity)
    //{
    //    try
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            entity.IsActive = true;
    //            entity.CreatedAt = DateTime.Now;

    //            (ExecutionState executionState, FirstSixtyPercentageLDFVM entity, string message) returnResponse = _firstSixtyPercentageLDFService.Create(entity);

    //            if (returnResponse.executionState.ToString() != "Created")
    //            {
    //                HttpContext.Session.SetString("Message", returnResponse.message);
    //                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //                return RedirectToAction("FirstSixtyPercentage", new { aigId = entity.AIGBasicInformationId });
    //            }
    //            else
    //            {
    //                HttpContext.Session.SetString("Message", "Repayments for 60% LDF has been successfully generated");

    //                return RedirectToAction("Repayments", new { aigId = returnResponse.entity.AIGBasicInformationId });
    //            }
    //        }
    //        return View(entity);
    //    }
    //    catch
    //    {
    //        HttpContext.Session.SetString("Message", "Unexpected error occurred");
    //        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //        return View(entity);
    //    }
    //}

    //public ActionResult Progress(long? aigId)
    //{
    //    if (aigId == null || aigId < 1)
    //    {
    //        return NotFound();
    //    }

    //    var aig = _AIGBasicInformationService.GetById(aigId).entity ?? new AIGBasicInformationVM();
    //    aig.RepaymentLDFs = _RepaymentLDFService.GetListWithProgress(aigId ?? 0).entity ?? new List<RepaymentLDFVM>();

    //    return View(aig);
    //}

    //[HttpPost]
    //public ActionResult Progress(LDFProgressVM entity)
    //{
    //    try
    //    {
    //        (ExecutionState executionState, LDFProgressVM entity, string message) returnResponse;

    //        if (ModelState.IsValid)
    //        {
    //            entity.IsActive = true;
    //            entity.CreatedAt = DateTime.Now;

    //            if (entity.Id == 0)
    //            {
    //                returnResponse = _lDFProgressService.Create(entity);
    //            }
    //            else
    //            {
    //                returnResponse = _lDFProgressService.Update(entity);
    //            }

    //            if (returnResponse.entity is null)
    //            {
    //                HttpContext.Session.SetString("Message", returnResponse.message);
    //                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //                return RedirectToAction("Progress", new { aigId = entity.AIGBasicInformationId });
    //            }
    //            else
    //            {
    //                HttpContext.Session.SetString("Message", "Progress amount has been saved successfully");

    //                return RedirectToAction("Progress", new { aigId = entity.AIGBasicInformationId });
    //            }
    //        }
    //        return RedirectToAction("Progress", new { aigId = entity.AIGBasicInformationId });
    //    }
    //    catch
    //    {
    //        HttpContext.Session.SetString("Message", "Unexpected error occurred");
    //        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //        return View(entity);
    //    }
    //}

    public ActionResult Repayments(long? internalLoanId)
    {
        if (internalLoanId == null || internalLoanId < 1)
        {
            return NotFound();
        }

        var internalLoan = _InternalLoanInformationService.GetById(internalLoanId).entity ?? new InternalLoanInformationVM();

        return View(internalLoan);
    }

    [HttpPost]
    public ActionResult CompletePayment(long id)
    {

        try
        {
            (ExecutionState executionState, List<RepaymentInternalLoanVM> entity, string message) check = _RepaymentInternalLoanService.List();
            (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) RepaymentInternalLoan = _RepaymentInternalLoanService.GetById(id);

            var previousPaymentCount = check.entity.Count(x => x.RepaymentSerial < RepaymentInternalLoan.entity.RepaymentSerial && x.IsPaymentCompleted == false && x.InternalLoanInformationId == RepaymentInternalLoan.entity.InternalLoanInformationId);
            if (previousPaymentCount > 0)
            {
               
            HttpContext.Session.SetString("Message", "Previous payment is not completed");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return Json(RepaymentInternalLoan.entity, SerializerOption.Default);
            }
             else   
            
            //var RepaymentInternalLoan = new RepaymentInternalLoanVM();
            RepaymentInternalLoan.entity.Id = id;
            RepaymentInternalLoan.entity.IsPaymentCompleted = true;
            RepaymentInternalLoan.entity.PaymentCompletedDateTime = DateTime.Now;
            RepaymentInternalLoan.entity.IsActive = true;

            (ExecutionState executionState, RepaymentInternalLoanVM entity, string message) returnResponse = _RepaymentInternalLoanService.Update(RepaymentInternalLoan.entity);
            if (returnResponse.executionState == ExecutionState.Failure)
            {
                HttpContext.Session.SetString("Message", returnResponse.message);
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                return Json(returnResponse.entity, SerializerOption.Default);
            }

            HttpContext.Session.SetString("Message", "Payment has been completed");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return Json(returnResponse.entity, SerializerOption.Default);

        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("InternalLoanInformation", "Repayments");
        }

    }

    //public ActionResult RemovePayment(long repaymentId, long aigId)
    //{
    //    try
    //    {
    //        (ExecutionState executionState, RepaymentLDFVM entity, string message) returnResponse = _RepaymentLDFService.RemovePayment(repaymentId);
    //        if (returnResponse.entity == null)
    //        {
    //            HttpContext.Session.SetString("Message", returnResponse.message);
    //            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
    //        }

    //        HttpContext.Session.SetString("Message", "Payment has been removed");
    //        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //        return RedirectToAction("Repayments", new { aigId });

    //    }
    //    catch
    //    {
    //        HttpContext.Session.SetString("Message", "Unexpected error occurred");
    //        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //        return RedirectToAction("Repayments", new { aigId });
    //    }
    //}

    //public ActionResult SecondFourtyPercentage(int? aigId)
    //{
    //    if (aigId == null || aigId < 1)
    //    {
    //        return NotFound();
    //    }

    //    var result = _AIGBasicInformationService.GetById(aigId);
    //    if (result.executionState != ExecutionState.Retrieved || result.entity is null)
    //    {
    //        HttpContext.Session.SetString("Message", "AIG Information not found");
    //        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //        return RedirectToAction("Index");
    //    }

    //    var repaymentResult = _RepaymentLDFService.GetListByAIGId(aigId ?? 0).entity ?? new List<RepaymentLDFVM>();
    //    ViewBag.StartRepaymentLDFId = repaymentResult;

    //    return View(result.entity);
    //}

    //[HttpPost]
    //public ActionResult SecondFourtyPercentage(SecondFourtyPercentageLDFVM entity)
    //{
    //    try
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            entity.IsActive = true;
    //            entity.CreatedAt = DateTime.Now;

    //            (ExecutionState executionState, SecondFourtyPercentageLDFVM entity, string message) returnResponse = _secondFourtyPercentageLDFService.Create(entity);

    //            if (returnResponse.executionState.ToString() != "Created")
    //            {
    //                HttpContext.Session.SetString("Message", returnResponse.message);
    //                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //                return RedirectToAction("SecondFourtyPercentage", new { aigId = entity.AIGBasicInformationId });
    //            }
    //            else
    //            {
    //                HttpContext.Session.SetString("Message", "Repayments for 40% LDF has been successfully generated");

    //                return RedirectToAction("Repayments", new { aigId = entity.AIGBasicInformationId });
    //            }
    //        }
    //        return View(entity);
    //    }
    //    catch
    //    {
    //        HttpContext.Session.SetString("Message", "Unexpected error occurred");
    //        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

    //        return View(entity);
    //    }
    //}

    public JsonResult Delete(int id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _InternalLoanInformationService.DoesExist(id);
        string message = "Failed, You can't delete this item.";
        if (CheckDataExistOrNot.executionState.ToString() == "Failure")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);

        }
        (ExecutionState executionState, InternalLoanInformationVM entity, string message) returnResponse = _InternalLoanInformationService.Delete(id);
        if (returnResponse.executionState.ToString() == "Updated")
        {
            returnResponse.message = "Basic Information for internal loan has been deleted successfully.";
        }
        return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
        //return View();
    }

    //[HttpPost]
    //public ActionResult Delete(int id, AIGBasicInformationVM entity)
    //{
    //    try
    //    {
    //        // TODO: Add update logic here
    //        if (id != entity.Id)
    //        {
    //            return RedirectToAction(nameof(AIGBasicInformationController.Index), "AIGBasicInformation");
    //        }
    //        //entity.IsActive = true;
    //        entity.IsDeleted = true;
    //        entity.UpdatedAt = DateTime.Now;
    //        (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.Update(entity);
    //        //                Session["Message"] = returnResponse.message;
    //        //                Session["executionState"] = returnResponse.executionState;
    //        //return View(returnResponse.entity);
    //        // return RedirectToAction("Edit?id="+id);
    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    public ActionResult GetInternalLoanAvailableAmount(int? fcvVcfId)
    {
        if (fcvVcfId == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, InternalLoanAvailableAmountVM entity, string message) returnResponse = _InternalLoanInformationService.GetInternalLoanAvailableAmount(fcvVcfId);

        //return View(returnResponse.entity);
        return Json(returnResponse.entity, SerializerOption.Default);
    }


    // Approval Status
    public ActionResult SendRequest(int id)
    {
        var result = _InternalLoanInformationService.GetById(id);

        result.entity.UpdatedAt = DateTime.Now;
        result.entity.ApprovalStatus = (long)Helper.Enum.InternalLoan.InternalLoanApprovalStatus.SentRequest;
        var returnResponse = _InternalLoanInformationService.Update(result.entity);
        return RedirectToAction("Index", "InternalLoanInformation");
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

        var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext, 50);
        (ExecutionState executionState, List<InternalLoanInformationVM> entity, string message) returnResponse = _InternalLoanInformationService.List();

        //if (returnResponse.entity == null)
        //{
        //    //Extra Filter
        //    ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        //    ViewBag.PhoneNumber = string.Empty;
        //    ViewBag.NID = string.Empty;
        //    ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
        //    return View(new List<InternalLoanInformationVM>());
        //}


        //Extra Filter
        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");



        //New multi permition Start

        ViewBag.ReceiverId = new SelectList(new List<UserVM>(), "Id", "UserName");

        //if (returnResponse.entity == null)
        //{
        //    return View(new List<InternalLoanInformationVM>());
        //}

        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        //new
        long userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));
        var returnResponseApprovalLogForCfm = _ApprovalLogForCfmService.List().entity?.OrderByDescending(x => x.CreatedAt)?.Where(x => x?.ReceiverRoleId == userRoleId).ToList() ?? new List<ApprovalLogForCfmVM>();

        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 58).Select(x => x.Id).FirstOrDefault();

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


        var returnResponsePermissionHeaderSettings = _PermissionHeaderSettingsService.List().entity.Where(x => x.AccesslistId == 58).FirstOrDefault();
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
            return View(returnResponse.entity ?? new List<InternalLoanInformationVM>());
        }
        else
        {
            return View(new List<InternalLoanInformationVM>() ?? new List<InternalLoanInformationVM>());
        }

        if (checkIsLetestReceiver?.UserRoleId == userRoleId)
        {
            return View(returnResponse.entity ?? new List<InternalLoanInformationVM>());
        }
        else
        {
            return View(new List<InternalLoanInformationVM>());
        }

        //New multi permition End

        return View(returnResponse.entity.Where(x=>x.ApprovalStatus == 1) ?? new List<InternalLoanInformationVM>());
    }
    //public ActionResult AcceptedById(int id)
    //{
    //    var result = _InternalLoanInformationService.GetById(id);
    //    result.entity.ApprovalStatus = (long)Helper.Enum.InternalLoan.InternalLoanApprovalStatus.Approve;
    //    result.entity.UpdatedAt = DateTime.Now;
    //    var returnResponse = _InternalLoanInformationService.Update(result.entity);
    //    return RedirectToAction("RequestList", "InternalLoanInformation");
    //}


    public ActionResult AcceptedById(int id)
    {
        var result = _InternalLoanInformationService.GetById(id);
        result.entity.InternalLoanInformationFiles = null;
        result.entity.RepaymentInternalLoans = null;

        //result.entity.CipFiles = null;
        //result.entity.ApprovalLogForCfms = null;

        result.entity.ApprovalStatus = (long)Helper.Enum.InternalLoan.InternalLoanApprovalStatus.Approve;
        result.entity.UpdatedAt = DateTime.Now;
        var returnResponse = _InternalLoanInformationService.Update(result.entity);
        return RedirectToAction("RequestList", "InternalLoanInformation");
    }


    public ActionResult RejectedById(int id)
    {
        var result = _InternalLoanInformationService.GetById(id);
        result.entity.UpdatedAt = DateTime.Now;
        result.entity.ApprovalStatus = (long)Helper.Enum.InternalLoan.InternalLoanApprovalStatus.Rejectted;
        var returnResponse = _InternalLoanInformationService.Update(result.entity);
        return RedirectToAction("RequestList", "InternalLoanInformation");
    }

    private bool SaveFiles(IReadOnlyList<IFormFile> files, ref InternalLoanInformationVM entity, FileType fileType, out string error)
    {
        foreach (var file in files)
        {
            var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "InternalLoanInformation", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            var entityFile = new InternalLoanInformationFileVM
            {
                FileName = file.FileName,
                FileType = fileType,
                FileNameUrl = fileName,
            };

            entity?.InternalLoanInformationFiles?.Add(entityFile);
        }

        error = string.Empty;
        return true;
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






    //DataTable Get List using server site Pagination
    //[HttpPost]
    public ActionResult GetInternalLoanInformationListByPagination(JqueryDatatableParam param)
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


     var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext);
        filter.iDisplayStart = param.iDisplayStart;
        filter.iDisplayLength = param.iDisplayLength;
        filter.sSearch = param.sSearch;


        (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) returnResponse = _InternalLoanInformationService.GetInternalLoanInformationByFilter(filter);

        if (returnResponse.entity == null)
        {
            return View(new List<InternalLoanInformationVM>());
        }

        //Extra Filter
        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        //New Multi Permition Start
        var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
        var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

        var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

        var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 58).Select(x => x.Id).FirstOrDefault();
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
                item.ApprovalStatusText = "Rejected";
            }
            if (item.ApprovalStatus == null)
            {
                item.ApprovalStatusText = "---";
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
    public ActionResult IndexFilterInternalLoanInformationListByPagination(AIGBasicInformationFilterVM filter)
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

        (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) returnResponse = _InternalLoanInformationService.GetInternalLoanInformationByFilter(filter);

        //Extra Filter
        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender! : null);
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);


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