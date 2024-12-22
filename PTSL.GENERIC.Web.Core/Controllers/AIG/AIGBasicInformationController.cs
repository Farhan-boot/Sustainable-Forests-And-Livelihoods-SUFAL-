using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Trades;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AIG;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Trades;
using PTSL.GENERIC.Web.Core.Services.Interface.AIG;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Trades;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.AIG;

[SessionAuthorize]
public class AIGBasicInformationController : Controller
{
    private readonly IAIGBasicInformationService _AIGBasicInformationService;

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
    private readonly IRepaymentLDFFileService _RepaymentLDFFileService;
    private readonly FileHelper _fileHelper;

    public AIGBasicInformationController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _AIGBasicInformationService = new AIGBasicInformationService(httpHelper);
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
        _RepaymentLDFFileService = new RepaymentLDFFileService(httpHelper);

        _fileHelper = fileHelper;
    }

    [RequirePermissions(AIGGetByFilterPermission.PermissionNameConst)]
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
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext, 50);
        (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) returnResponse = _AIGBasicInformationService.GetAIGByFilter(filter);

        return View(returnResponse.entity.aaData);
    }

    [HttpPost]
    [RequirePermissions(AIGGetByFilterPermission.PermissionNameConst)]
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

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.HasGender ? (int)filter.Gender! : null);
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? Enumerable.Empty<NgoVM>(), "Id", "Name", filter.NgoId);

        (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) returnResponse = _AIGBasicInformationService.GetAIGByFilter(filter);
        return View("Index", returnResponse.entity.aaData);
    }

    public ActionResult IndexFilterJson(AIGBasicInformationFilterVM filter)
    {
        var result = _AIGBasicInformationService.GetAIGByFilter(filter);
        if (result.entity == null)
        {
            return Json(new List<AIGBasicInformationVM>(), SerializerOption.Default);
        }

        return Json(result.entity, SerializerOption.Default);
    }

    public ActionResult Details(long? id)
    {
        if (id == null || id < 1)
        {
            return NotFound();
        }
        (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.GetIncludeFirstSecondAndBen(id);

        //if (returnResponse.entity is not null) returnResponse.entity.RepaymentLDFs = _RepaymentLDFService.GetListByAIGId(id ?? 0).entity ?? new List<RepaymentLDFVM>();

        return View(returnResponse.entity);
    }

    [RequirePermissions(AIGCreatePermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public ActionResult Create()
    {
        GenerateViewBagForCreate();

        var entity = new AIGBasicInformationVM();

        return View(entity);
    }

    private void GenerateViewBagForCreate()
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
    }

    [HttpPost]
    [RequirePermissions(AIGCreatePermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public ActionResult Create(AIGBasicInformationVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    GenerateViewBagForCreate();

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Basic information for AIG has been created successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return RedirectToAction("FirstSixtyPercentage", new { aigId = returnResponse.entity.Id });
                }
            }

            HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
        catch
        {
            HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
    }

    [RequirePermissions(AIGEditPermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public ActionResult Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.GetById(id);

        return View(returnResponse.entity);
    }

    [HttpPost]
    [RequirePermissions(AIGEditPermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public ActionResult Edit(int id, AIGBasicInformationVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(Index), "AIGBasicInformation");
                }
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;

                (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.Update(entity);

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Basic information for AIG has been updated successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return RedirectToAction("Index");
                }
            }

            HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
    }

    public ActionResult FirstSixtyPercentage(int? aigId)
    {
        if (aigId == null)
        {
            return NotFound();
        }

        var result = _AIGBasicInformationService.GetById(aigId);
        if (result.executionState != ExecutionState.Retrieved || result.entity is null)
        {
            HttpContext.Session.SetString("Message", "AIG Information not found");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Index");
        }

        return View(result.entity);
    }

    [HttpPost]
    public ActionResult FirstSixtyPercentage(FirstSixtyPercentageLDFVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                (ExecutionState executionState, FirstSixtyPercentageLDFVM entity, string message) returnResponse = _firstSixtyPercentageLDFService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("FirstSixtyPercentage", new { aigId = entity.AIGBasicInformationId });
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Repayments for 60% LDF has been successfully generated");

                    return RedirectToAction("Repayments", new { aigId = returnResponse.entity.AIGBasicInformationId });
                }
            }
            return View(entity);
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
    }

    [RequirePermissions(AIGProgressByBeneficiaryPermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public ActionResult Progress(long? aigId)
    {
        if (aigId == null || aigId < 1)
        {
            return NotFound();
        }

        var aig = _AIGBasicInformationService.GetById(aigId).entity ?? new AIGBasicInformationVM();
        aig.RepaymentLDFs = _RepaymentLDFService.GetListWithProgress(aigId ?? 0).entity ?? new List<RepaymentLDFVM>();

        return View(aig);
    }

    [HttpPost]
    [RequirePermissions(AIGProgressCreatePermission.PermissionNameConst, AIGProgressUpdatePermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public ActionResult Progress(LDFProgressVM entity)
    {
        try
        {
            (ExecutionState executionState, LDFProgressVM entity, string message) returnResponse;

            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                returnResponse = entity.Id == 0
                    ? _lDFProgressService.Create(entity)
                    : _lDFProgressService.Update(entity);

                if (returnResponse.executionState == ExecutionState.Failure)
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Progress", new { aigId = entity.AIGBasicInformationId });
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Progress amount has been saved successfully");

                    return RedirectToAction("Progress", new { aigId = entity.AIGBasicInformationId });
                }
            }
            return RedirectToAction("Progress", new { aigId = entity.AIGBasicInformationId });
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
    }

    [RequirePermissions(AIGRepaymentGetListByAIGIdPermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public ActionResult Repayments(long? aigId)
    {
        if (aigId == null || aigId < 1)
        {
            return NotFound();
        }

        var result = _RepaymentLDFService.GetListByAIGId(aigId ?? 0);

        if (result.entity is not null)
        {
            var aig = _AIGBasicInformationService.GetById(aigId).entity ?? new AIGBasicInformationVM();

            ViewBag.AIGBasicInformation = aig;

            return View(result.entity);
        }

        HttpContext.Session.SetString("Message", "Repayments not found");
        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

        return RedirectToAction("Index");
    }

    [RequirePermissions(AIGRepaymentCompletePaymentPermission.PermissionNameConst)]
    [HttpPost]
    public ActionResult CompletePayment(CompleteRepaymentVM completeRepayment)
    {
        try
        {
            (ExecutionState executionState, RepaymentLDFVM entity, string message) returnResponse = _RepaymentLDFService.CompletePayment(completeRepayment);
            if (returnResponse.executionState == ExecutionState.Failure)
            {
                HttpContext.Session.SetString("Message", returnResponse.message);
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return RedirectToAction("Repayments", new { completeRepayment.AigId });
            }

            HttpContext.Session.SetString("Message", "Payment has been completed");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Repayments", new { completeRepayment.AigId });
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Repayments", new { completeRepayment.AigId });
        }
    }

    [RequirePermissions(AIGRepaymentRemovePaymentPermission.PermissionNameConst)]
    public ActionResult RemovePayment(long repaymentId, long aigId)
    {
        try
        {
            (ExecutionState executionState, RepaymentLDFVM entity, string message) returnResponse = _RepaymentLDFService.RemovePayment(repaymentId);
            if (returnResponse.executionState == ExecutionState.Failure)
            {
                HttpContext.Session.SetString("Message", returnResponse.message);
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
            }
            else
            {
                HttpContext.Session.SetString("Message", "Payment has been removed");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
            }
            return RedirectToAction("Repayments", new { aigId });
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Repayments", new { aigId });
        }
    }

    public ActionResult SecondFourtyPercentage(long? aigId)
    {
        if (aigId == null || aigId < 1)
        {
            return NotFound();
        }

        var result = _AIGBasicInformationService.GetById(aigId);
        if (result.executionState != ExecutionState.Retrieved || result.entity is null)
        {
            HttpContext.Session.SetString("Message", "AIG Information not found");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Index");
        }

        var repaymentResult = _RepaymentLDFService.GetListByAIGId(aigId ?? 0).entity ?? new List<RepaymentLDFVM>();
        ViewBag.StartRepaymentLDFId = repaymentResult;

        return View(result.entity);
    }

    [HttpPost]
    public ActionResult SecondFourtyPercentage(SecondFourtyPercentageLDFVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                (ExecutionState executionState, SecondFourtyPercentageLDFVM entity, string message) returnResponse = _secondFourtyPercentageLDFService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("SecondFourtyPercentage", new { aigId = entity.AIGBasicInformationId });
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Repayments for 40% LDF has been successfully generated");

                    return RedirectToAction("Repayments", new { aigId = entity.AIGBasicInformationId });
                }
            }
            return View(entity);
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
    }

    [RequirePermissions(AIGRepaymentLockUnlockPaymentPermission.PermissionNameConst, IsJson = true)]
    public ActionResult LockUnlockPayment(long repaymentId, bool shouldLock, long aigId)
    {
        try
        {
            (ExecutionState executionState, RepaymentLDFVM entity, string message) returnResponse = _RepaymentLDFService.LockUnlockPayment(repaymentId, shouldLock);
            if (returnResponse.executionState == ExecutionState.Failure)
            {
                HttpContext.Session.SetString("Message", returnResponse.message);
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return Json(
                    new { Success = false, Message = returnResponse.message },
                    SerializerOption.Default);
            }
            else
            {
                HttpContext.Session.SetString("Message", shouldLock ? "Payment locked successfully" : "Payment unlocked successfully");
                HttpContext.Session.SetString("executionState", ExecutionState.Success.ToString());

                return Json(
                    new { Success = true, Message = returnResponse.message },
                    SerializerOption.Default);
            }
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return Json(
                new { Success = false, Message = "" },
                SerializerOption.Default);
        }
    }

    public ActionResult ListHistory(long repaymentId)
    {
        try
        {
            (ExecutionState executionState, List<RepaymentLDFHistoryVM> entity, string message) returnResponse = _RepaymentLDFService.ListHistory(repaymentId);
            if (returnResponse.entity == null)
            {
                return Json(
                    new { Success = false, Message = "No history found", Data = Enumerable.Empty<RepaymentLDFHistoryVM>() },
                    SerializerOption.Default);
            }

            return Json(
                new { Success = true, Message = "Data found", Data = returnResponse.entity },
                SerializerOption.Default);
        }
        catch
        {
            return Json(
                new { Success = false, Message = "Unexpected error occurred", Data = Enumerable.Empty<RepaymentLDFHistoryVM>() },
                SerializerOption.Default);
        }
    }

    [RequirePermissions(AIGDeletePermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public JsonResult Delete(int id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _AIGBasicInformationService.DoesExist(id);
        string message = "Failed, You can't delete this item.";
        if (CheckDataExistOrNot.executionState.ToString() == "Failure")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);

        }
        (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.Delete(id);
        if (returnResponse.executionState.ToString() == "Updated")
        {
            returnResponse.message = "Basic Information for AIG has been deleted successfully.";
        }
        return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
        //return View();
    }

    [HttpPost]
    [RequirePermissions(AIGDeletePermission.PermissionNameConst, RedirectTo = "AIGBasicInformation/Index")]
    public ActionResult Delete(int id, AIGBasicInformationVM entity)
    {
        try
        {
            // TODO: Add update logic here
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(AIGBasicInformationController.Index), "AIGBasicInformation");
            }
            //entity.IsActive = true;
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.Update(entity);
            //                Session["Message"] = returnResponse.message;
            //                Session["executionState"] = returnResponse.executionState;
            //return View(returnResponse.entity);
            // return RedirectToAction("Edit?id="+id);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }


    [HttpPost]
    public ActionResult UploadRepaymentLDFFile(long aigFileId, long repaymentFileId)
    {
        try
        {
            var documentFiles = HttpContext.Request.Form.Files.GetFiles("RepaymentLDFFiles[]");
            var entity = new RepaymentLDFFileVM();
            var entityList = new List<RepaymentLDFFileVM>();

            foreach (var item in documentFiles)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFile(item, FileType.Document, "RepaymentLDFFile", out var errorMessage);
                entity.RepaymentLDFId = repaymentFileId;
                entity.FileName = item.FileName;
                entity.FileType = FileType.Document;
                entity.FileNameUrl = fileName;
                entityList.Add(entity);
            }

            // Save document files
            if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
            {
                return Json(
                    new { Success = false, Message = documentFileError },
                    SerializerOption.Default);
            }

            foreach (var data in entityList)
            {
                (ExecutionState executionState, RepaymentLDFFileVM entity, string message) returnResponse = _RepaymentLDFFileService.Create(data);
            }

                HttpContext.Session.SetString("Message", "Repayment ldf file has been created successfully");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                return RedirectToAction("Repayments", "AIGBasicInformation", new { aigId = Convert.ToInt32(aigFileId) });
        }
        catch
        {

            return RedirectToAction("Repayments", "AIGBasicInformation", new { aigId = Convert.ToInt32(aigFileId) });
        }
    }

    public JsonResult GetRepaymentLDFFileBy(int repaymentId)
    {
        (ExecutionState executionState, List<RepaymentLDFFileVM> entity, string message) returnResponse = _RepaymentLDFFileService.GetRepaymentLDFFileByRepaymentId(repaymentId);
        return Json(returnResponse.entity, SerializerOption.Default);
    }

    public JsonResult AIGBeneficiaryCheckEligibility(int surveyId)
    {
        var returnResponse = _AIGBasicInformationService.AIGBeneficiaryCheckEligibility(surveyId);
        return Json(returnResponse.entity, SerializerOption.Default);
    }

    public ActionResult DeleteImageOrDocument(long id)
    {
        var result = _RepaymentLDFFileService.Delete(id);
        if (result.entity != null)
        {
            result.message = "Item deleted successfully.";
        }
        else
        {
            result.message = "Failed to delete this item.";
        }

        return Json(new { Success = result.entity, Message = result.message, result.executionState }, SerializerOption.Default);
    }

    private bool SaveFiles(IReadOnlyList<IFormFile> files, ref RepaymentLDFFileVM entity, FileType fileType, out string error)
    {
        foreach (var file in files)
        {
            var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "RepaymentLDFFile", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }
            var repaymentLDFFileList = new List<RepaymentLDFFileVM>();

            var entityFile = new RepaymentLDFFileVM
            {
                FileName = file.FileName,
                FileType = fileType,
                FileNameUrl = fileName,
            };

            repaymentLDFFileList.Add(entityFile);
        }

        error = string.Empty;
        return true;
    }




    //DataTable Get List using server site Pagination
    //[HttpPost]
    public ActionResult GetAIGBasicInformationListByPagination(JqueryDatatableParam param)
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
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext);
        filter.iDisplayStart = param.iDisplayStart;
        filter.iDisplayLength = param.iDisplayLength;
        filter.sSearch = param.sSearch;

        (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) returnResponse = _AIGBasicInformationService.GetAIGByFilter(filter);


        foreach (var item in returnResponse.entity.aaData)
        {
            item.TotalAllocatedLoanAmountTextBD = item.TotalAllocatedLoanAmount.ToBDTCurrency();
            item.BadLoanTypeText = item.BadLoanType.GetEnumDisplayName();
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
    public ActionResult IndexFilterAIGBasicInformationListByPagination(AIGBasicInformationFilterVM filter)
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
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? Enumerable.Empty<NgoVM>(), "Id", "Name", filter.NgoId);

        (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) returnResponse = _AIGBasicInformationService.GetAIGByFilter(filter);

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









// AIG
public class AIGGetByFilterPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG.GetByFilter";
    public string PermissionName => "AIG.GetByFilter";
    public string PermissionDetails => "AIG List";
}

public class AIGCreatePermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG.Create";
    public string PermissionName => "AIG.Create";
    public string PermissionDetails => "Create AIG";
}

public class AIGEditPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG.Edit";
    public string PermissionName => "AIG.Edit";
    public string PermissionDetails => "Edit AIG";
}

public class AIGDeletePermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG.Delete";
    public string PermissionName => "AIG.Delete";
    public string PermissionDetails => "Delete AIG";
}

// AIG Repayment
public class AIGRepaymentGetListByAIGIdPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIGRepayment.GetListByAIGId";
    public string PermissionName => "AIGRepayment.GetListByAIGId";
    public string PermissionDetails => "Repayments by AIG";
}

public class AIGRepaymentCompletePaymentPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIGRepayment.CompletePayment";
    public string PermissionName => "AIGRepayment.CompletePayment";
    public string PermissionDetails => "Complete repayment";
}

public class AIGRepaymentRemovePaymentPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIGRepayment.RemovePayment";
    public string PermissionName => "AIGRepayment.RemovePayment";
    public string PermissionDetails => "Remove repayment";
}

public class AIGRepaymentLockUnlockPaymentPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIGRepayment.LockUnlock";
    public string PermissionName => "AIGRepayment.LockUnlock";
    public string PermissionDetails => "Lock/Unlock repayment";
}

// AIG Progress
public class AIGProgressCreatePermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG Progress.Create";
    public string PermissionName => "AIG Progress.Create";
    public string PermissionDetails => "Create repayment";
}

public class AIGProgressUpdatePermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG Progress.Update";
    public string PermissionName => "AIG Progress.Update";
    public string PermissionDetails => "Update progress";
}

public class AIGProgressByBeneficiaryPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG Progress.ProgressByBeneficiary";
    public string PermissionName => "AIG Progress.ProgressByBeneficiary";
    public string PermissionDetails => "AIG Progress by beneficiary";
}


