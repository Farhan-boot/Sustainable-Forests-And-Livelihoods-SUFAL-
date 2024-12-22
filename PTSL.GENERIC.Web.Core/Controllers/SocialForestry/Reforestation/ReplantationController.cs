using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Reforestation;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Reforestation;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry.Reforestation;

[SessionAuthorize]
public class ReplantationController : Controller
{
    private readonly IFinancialYearService _financialYearService;
    private readonly IPlantationTypeService _plantationTypeService;
    private readonly INewRaisedPlantationService _newRaisedPlantationService;
    private readonly IReplantationService _replantationService;

    private readonly FileHelper _fileHelper;

    public ReplantationController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _financialYearService = new FinancialYearService(httpHelper);
        _plantationTypeService = new PlantationTypeService(httpHelper);
        _newRaisedPlantationService = new NewRaisedPlantationService(httpHelper);
        _replantationService = new ReplantationService(httpHelper);

        _fileHelper = fileHelper;
    }

    public ActionResult Index()
    {
        var returnResponse = _replantationService.List();

        return View(returnResponse.entity);
    }

    public ActionResult Create(long newRaisedId)
    {
        if (newRaisedId == default)
        {
            return NotFound();
        }

        var newRaisedResult = _newRaisedPlantationService.GetDetails(newRaisedId);

        ViewBag.NewRaisedDetails = newRaisedResult.entity;
        ViewBag.PlantationTypeId = _plantationTypeService.List().entity ?? new List<Model.EntityViewModels.SocialForestry.PlantationTypeVM>();
        ViewBag.FinancialYearId = _financialYearService.List().entity ?? new List<Model.EntityViewModels.GeneralSetup.FinancialYearVM>();

        return View(new ReplantationVM());
    }

    [HttpPost]
    public ActionResult Create(ReplantationVM entity)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                    SerializerOption.Default);
            }

            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            // PBSA Other files
            var socialForestryManagementCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("SocialForestryManagementCommitteeFormedFile");
            var fundManagementSubCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("FundManagementSubCommitteeFormedFile");
            var advisoryCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("AdvisoryCommitteeFormedFile");
            var plantationJournalUploadUrlFile = HttpContext.Request.Form.Files.GetFile("PlantationJournalUploadUrlFile");
            var monitoringReportUrlFile = HttpContext.Request.Form.Files.GetFile("MonitoringReportUrlFile");
            if (socialForestryManagementCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(socialForestryManagementCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.SocialForestryManagementCommitteeFormedFile = fileUrl;
            }
            if (fundManagementSubCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(fundManagementSubCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.FundManagementSubCommitteeFormedFile = fileUrl;
            }
            if (advisoryCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(advisoryCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.AdvisoryCommitteeFormedFile = fileUrl;
            }
            if (plantationJournalUploadUrlFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(plantationJournalUploadUrlFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.PlantationJournalUploadUrl = fileUrl;
            }
            if (monitoringReportUrlFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(monitoringReportUrlFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.MonitoringReportUrl = fileUrl;
            }

            var returnResponse = _replantationService.Create(entity);
            if (returnResponse.executionState == ExecutionState.Created)
            {
                var urlRedirect = Url.Action("Index", "Replantation");

                HttpContext.Session.SetString("Message", "Replantation has been created successfully.");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                return Json(
                    new { Success = true, Message = "Replantation has been created successfully.", RedirectUrl = urlRedirect },
                    SerializerOption.Default);
            }

            return Json(
                new { Success = false, Message = returnResponse.message },
                SerializerOption.Default);
        }
        catch
        {
            return Json(
                new { Success = false, Message = "Unknown error occurred." },
                SerializerOption.Default);
        }
    }

    public ActionResult Edit(long id, long newRaisedId)
    {
        if (id == default || newRaisedId == default)
        {
            return NotFound();
        }

        var newRaisedResult = _newRaisedPlantationService.GetDetails(newRaisedId);

        ViewBag.NewRaisedDetails = newRaisedResult.entity;
        ViewBag.PlantationTypeId = _plantationTypeService.List().entity ?? new List<Model.EntityViewModels.SocialForestry.PlantationTypeVM>();
        ViewBag.FinancialYearId = _financialYearService.List().entity ?? new List<Model.EntityViewModels.GeneralSetup.FinancialYearVM>();

        return View(new ReplantationVM());
    }

    public JsonResult GetById(int id)
    {
        var returnResponse = _replantationService.GetById(id).entity ?? new ReplantationVM();
        return Json(new { Data = returnResponse }, SerializerOption.Default);
    }

    public ActionResult Details(long id)
    {
        if (id == default)
        {
            return NotFound();
        }

        var returnResponse = _replantationService.GetDetails(id);

        return View(returnResponse.entity);
    }

    public JsonResult Delete(int id)
    {
        var result = _replantationService.SoftDelete(id);
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
}
