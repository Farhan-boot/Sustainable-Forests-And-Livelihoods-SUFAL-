using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry.Cutting;


[SessionAuthorize]
public class CuttingPlantationController : Controller
{
    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;

    private readonly ICuttingPlantationService _cuttingPlantationService;
    private readonly INewRaisedPlantationService _newRaisedPlantationService;
    private readonly IPlantationUnitService _plantationUnitService;
    private readonly IFinancialYearService _financialYearService;
    private readonly IZoneOrAreaService _ZoneOrAreaService;

    private readonly FileHelper _fileHelper;

    public CuttingPlantationController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);

        _cuttingPlantationService = new CuttingPlantationService(httpHelper);
        _newRaisedPlantationService = new NewRaisedPlantationService(httpHelper);
        _plantationUnitService = new PlantationUnitService(httpHelper);
        _financialYearService = new FinancialYearService(httpHelper);
        _ZoneOrAreaService = new ZoneOrAreaService(httpHelper);

        _fileHelper = fileHelper;
    }

    public ActionResult Index(long newRaisedId)
    {
        //New add filter start

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
        ViewBag.ZoneOrAreaId = new SelectList(_ZoneOrAreaService.List().entity ?? new List<ZoneOrAreaVM>(), "Id", "Name");
        var filter = AuthLocationHelper.GetFilterFromSession<NewRaisedPlantationFilter>(HttpContext, 50);
        var (_, entity, _) = _cuttingPlantationService.ListByFilter(filter);

        //New add filter end


        if (newRaisedId < 1)
        {
            var result = _cuttingPlantationService.List();
            return View(result.entity);
        }
        ViewBag.NewRaisedPlantation = _newRaisedPlantationService.GetById(newRaisedId).entity ?? new NewRaisedPlantationVM();
        var returnResponse = _cuttingPlantationService.ListByNewRaised(newRaisedId);




        return View(returnResponse.entity);
    }


    [HttpPost]
    public ActionResult IndexFilter(NewRaisedPlantationFilter filter)
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

        ViewBag.ZoneOrAreaId = new SelectList(_ZoneOrAreaService.List().entity ?? new List<ZoneOrAreaVM>(), "Id", "Name", filter.ZoneOrAreaId);

        var (_, entity, _) = _cuttingPlantationService.ListByFilter(filter);

        return View("Index", entity ?? new List<CuttingPlantationVM>());
    }


    public ActionResult Create(long newRaisedId)
    {
        if (newRaisedId == default)
        {
            return NotFound();
        }

        var newRaisedResult = _newRaisedPlantationService.GetDetails(newRaisedId);
        var plantationUnits = _plantationUnitService.List().entity ?? new List<PlantationUnitVM>();

        ViewBag.NewRaisedDetails = newRaisedResult.entity;
        ViewBag.PlantationUnit = plantationUnits;
        ViewBag.FinancialYearId = _financialYearService.List().entity ?? new List<Model.EntityViewModels.GeneralSetup.FinancialYearVM>();

        return View(new CuttingPlantationVM());
    }

    [HttpPost]
    public ActionResult Create(CuttingPlantationVM entity)
    {
        try
        {
            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            var markingFile = HttpContext.Request.Form.Files.GetFile("StandingTreeMarkingListUrl");
            if (SaveMarkingFiles(markingFile, ref entity, out var markingFileError) == false)
            {
                return Json(
                    new { Success = true, Message = markingFileError },
                    SerializerOption.Default);
            }



            var returnResponse = _cuttingPlantationService.Create(entity);
            if (returnResponse.executionState == ExecutionState.Created)
            {
                var urlRedirect = Url.Action("Index", "CuttingPlantation");

                HttpContext.Session.SetString("Message", "Cutting plantation has been created successfully.");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                return Json(
                    new { Success = true, Message = "Cutting plantation has been created successfully.", RedirectUrl = urlRedirect },
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
        var plantationUnits = _plantationUnitService.List().entity ?? new List<Model.EntityViewModels.SocialForestry.PlantationUnitVM>();

        ViewBag.NewRaisedDetails = newRaisedResult.entity;
        ViewBag.PlantationUnit = plantationUnits;
        ViewBag.FinancialYearId = _financialYearService.List().entity ?? new List<Model.EntityViewModels.GeneralSetup.FinancialYearVM>();

        return View(new CuttingPlantationVM());
    }

    public JsonResult GetById(int id)
    {
        var returnResponse = _cuttingPlantationService.GetById(id).entity ?? new CuttingPlantationVM();
        return Json(new { Data = returnResponse }, SerializerOption.Default);
    }

    public ActionResult Details(long id)
    {
        if (id == default)
        {
            return NotFound();
        }

        var returnResponse = _cuttingPlantationService.GetById(id);

        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult Edit(CuttingPlantationVM entity)
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

            var returnResponse = _cuttingPlantationService.Update(entity);
            if (returnResponse.executionState == ExecutionState.Updated)
            {
                var urlRedirect = Url.Action("Index", "CuttingPlantation");

                HttpContext.Session.SetString("Message", "Cutting plantation has been updated successfully.");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                return Json(
                    new { Success = true, Message = "Cutting plantation has been updated successfully.", RedirectUrl = urlRedirect },
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

    public JsonResult Delete(int id)
    {
        var result = _cuttingPlantationService.SoftDelete(id);
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


    //File Upload
    private bool SaveMarkingFiles(IFormFile? markingFile, ref CuttingPlantationVM entity, out string error)
    {
        if (markingFile is not null)
        {
            var (isSaved, fileUrl, _) = _fileHelper.SaveFile(markingFile, null, "CuttingPlantation", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            entity.StandingTreeMarkingListUrl = fileUrl;
        }

        error = string.Empty;
        return true;
    }
}
