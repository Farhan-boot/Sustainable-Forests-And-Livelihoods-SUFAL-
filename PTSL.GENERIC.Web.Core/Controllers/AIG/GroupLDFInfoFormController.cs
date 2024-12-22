using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AIG;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.AIG;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.AIG;

[SessionAuthorize]
public class GroupLDFInfoFormController : Controller
{
    private readonly IGroupLDFInfoFormService _GroupLDFInfoFormService;
    private readonly IIndividualGroupFormSetupService _IndividualGroupFormSetupService;

    private readonly ISurveyService _SurveyService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;

    private readonly INgoService _ngoService;
    private readonly FileHelper _fileHelper;

    public GroupLDFInfoFormController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _GroupLDFInfoFormService = new GroupLDFInfoFormService(httpHelper);
        _IndividualGroupFormSetupService = new IndividualGroupFormSetupService(httpHelper);

        _SurveyService = new SurveyService(httpHelper);

        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);

        _ngoService = new NgoService(httpHelper);
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

        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
        ViewBag.FromDate = null;
        ViewBag.ToDate = null;
        ViewBag.TotalMember = string.Empty;

        ViewBag.GroupDocument = (_IndividualGroupFormSetupService.List().entity ?? new List<IndividualGroupFormSetupVM>()).FirstOrDefault()?.GroupDocument;

        var filter = AuthLocationHelper.GetFilterFromSession<GroupLDFInfoFormFilterVM>(HttpContext, 50);
        (ExecutionState executionState, List<GroupLDFInfoFormVM> entity, string message) returnResponse = _GroupLDFInfoFormService.ListByFilter(filter);

        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult IndexFilter(GroupLDFInfoFormFilterVM filter)
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

        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);
        ViewBag.FromDate = filter.FromDate;
        ViewBag.ToDate = filter.ToDate;
        ViewBag.TotalMember = filter.TotalMember;

        ViewBag.GroupDocument = (_IndividualGroupFormSetupService.List().entity).FirstOrDefault()?.GroupDocument;

        (ExecutionState executionState, List<GroupLDFInfoFormVM> entity, string message) returnResponse = _GroupLDFInfoFormService.ListByFilter(filter);

        return View("Index", returnResponse.entity);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) returnResponse = _GroupLDFInfoFormService.GetDetails(id, true);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
        ViewBag.SurveyId = new SelectList("");

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

        GroupLDFInfoFormVM entity = new GroupLDFInfoFormVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(GroupLDFInfoFormVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var documentFile = HttpContext.Request.Form.Files.GetFile("DocumentNameURL");

                entity.GroupLDFInfoFormMembers = JsonConvert.DeserializeObject<List<GroupLDFInfoFormMemberVM>>(entity.GroupLDFInfoFormMembersJson);

                if (entity.GroupLDFInfoFormMembers?.Count == 0)
                {
                    return Json(
                        new { Success = false, Message = "Please select beneficiaries" },
                        SerializerOption.Default);
                }

                // Save image files
                if (SaveFiles(documentFile, ref entity, FileType.Document, out var imageFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = imageFileError },
                        SerializerOption.Default);
                }

                (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) returnResponse = _GroupLDFInfoFormService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return Json(
                        new { Success = false, Message = returnResponse.message },
                        SerializerOption.Default);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Group LDF Information has been created successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return Json(
                        new { Success = true, Message = returnResponse.message, RedirectUrl = "/GroupLDFInfoForm/Index" },
                        SerializerOption.Default);
                }
            }
            return Json(
                new { Success = false, Message = "One or more validation failed", RedirectUrl = "/GroupLDFInfoForm/Create" },
                SerializerOption.Default);
        }
        catch
        {
            return Json(
                new { Success = false, Message = "Unexpected error occurred" },
                SerializerOption.Default);
        }
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) result = _GroupLDFInfoFormService.GetDetails(id);
        if (result.entity is null)
        {
            HttpContext.Session.SetString("Message", "Group LDF Information not found");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Index");
        }

        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name", result.entity.NgoId);

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

        return View(result.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, GroupLDFInfoFormVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var documentFile = HttpContext.Request.Form.Files.GetFile("DocumentNameURL");

                entity.GroupLDFInfoFormMembers = JsonConvert.DeserializeObject<List<GroupLDFInfoFormMemberVM>>(entity.GroupLDFInfoFormMembersJson);

                if (entity.GroupLDFInfoFormMembers?.Count == 0)
                {
                    return Json(
                        new { Success = false, Message = "Please select beneficiaries" },
                        SerializerOption.Default);
                }

                // Save image files
                if (SaveFiles(documentFile, ref entity, FileType.Document, out var imageFileError, true) == false)
                {
                    return Json(
                        new { Success = false, Message = imageFileError },
                        SerializerOption.Default);
                }

                (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) returnResponse = _GroupLDFInfoFormService.Update(entity);

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return Json(
                        new { Success = false, Message = returnResponse.message },
                        SerializerOption.Default);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Group LDF Information has been updated successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return Json(
                        new { Success = true, Message = returnResponse.message, RedirectUrl = "/GroupLDFInfoForm/Index" },
                        SerializerOption.Default);
                }
            }
            return Json(
                new { Success = false, Message = "One or more validation failed", RedirectUrl = $"/GroupLDFInfoForm/Edit?id={entity.Id}" },
                SerializerOption.Default);
        }
        catch
        {
            return Json(
                new { Success = false, Message = "Unexpected error occurred" },
                SerializerOption.Default);
        }
    }

    public JsonResult Delete(int id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _GroupLDFInfoFormService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) returnResponse = _GroupLDFInfoFormService.Delete(id);
        if (returnResponse.executionState.ToString() == "Updated")
        {
            returnResponse.message = "Item deleted successfully.";
        }
        else
        {
            returnResponse.message = "Failed to delete this item.";
        }

        return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
    }

    [HttpPost]
    public ActionResult Delete(int id, GroupLDFInfoFormVM entity)
    {
        try
        {
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(this.Index), "Category");
            }
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, GroupLDFInfoFormVM entity, string message) returnResponse = _GroupLDFInfoFormService.Update(entity);
            ////                Session["Message"] = returnResponse.message;
            //                Session["executionState"] = returnResponse.executionState;
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    private bool SaveFiles(IFormFile? file, ref GroupLDFInfoFormVM entity, FileType fileType, out string error, bool isEdit = false)
    {
        if (file is null && isEdit == false)
        {
            error = "File is empty";
            return false;
        }

        if (file is not null)
        {
            var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "GroupLDFInfoForm", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            entity.DocumentNameURL = fileName;
        }

        error = string.Empty;
        return true;
    }
}
