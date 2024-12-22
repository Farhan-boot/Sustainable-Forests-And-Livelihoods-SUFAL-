using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
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
public class RealizationController : Controller
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

    private readonly IRealizationService _realizationService;
    private readonly ILotWiseSellingInformationService _lotWiseSellingInformationService;

    private readonly FileHelper _fileHelper;

    public RealizationController(HttpHelper httpHelper, FileHelper fileHelper)
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
        _realizationService = new RealizationService(httpHelper);
        _lotWiseSellingInformationService = new LotWiseSellingInformationService(httpHelper);

        _fileHelper = fileHelper;
    }

    public ActionResult Index(long cuttingId)
    {
        if (cuttingId == default)
        {
            return NotFound();
        }

        var returnResponse = _realizationService.GetDefaultRealizationData(cuttingId);
        ViewBag.LotWiseSellingInformationId = _lotWiseSellingInformationService.GetLotInfoByCuttingId(cuttingId).entity ?? new List<LotWiseSellingInformationVM>();

        return View(returnResponse.entity);
    }

    public ActionResult GetLotInfoByLotNumber(long lotId)
    {
        if (lotId == default)
        {
            return NotFound();
        }

        var data = _lotWiseSellingInformationService.GetById(lotId).entity ?? new LotWiseSellingInformationVM();

        return Json(new { Data = data }, SerializerOption.Default);
    }

    [HttpPost]
    public ActionResult Create(RealizationVM entity)
    {
        var urlRedirect = $"/Realization/Index?cuttingId={entity.CuttingPlantationId}";

        try
        {
            if (!ModelState.IsValid)
            {
                return Redirect(urlRedirect);
            }

            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            var returnResponse = _realizationService.Create(entity);
            if (returnResponse.executionState == ExecutionState.Created)
            {
                HttpContext.Session.SetString("Message", "Realization has been created successfully.");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
            }
            else
            {
                HttpContext.Session.SetString("Message", returnResponse.message);
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
            }

            return Redirect(urlRedirect);
        }
        catch
        {
            return Redirect(urlRedirect);
        }
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

    public JsonResult Delete(int id)
    {
        var result = _realizationService.SoftDelete(id);
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


    //Edit
    public ActionResult Edit(int? id)
    {
        if (id == default)
        {
            return NotFound();
        }
        var returnResponse = _realizationService.GetById(id);
        var urlRedirect = $"/Realization/Index?cuttingId={id}";
        var lotWiseSellingInformationList = _lotWiseSellingInformationService.GetLotInfoByCuttingId(returnResponse.entity.CuttingPlantationId).entity ?? new List<LotWiseSellingInformationVM>();
        if (lotWiseSellingInformationList != null)
        {
            ViewBag.LotWiseSellingInformationId =  new SelectList(lotWiseSellingInformationList, "Id", "LotNumber", (int)returnResponse.entity.LotWiseSellingInformationId);
        }
        return View(returnResponse.entity);
    }

    //Edit
    [HttpPost]
    public ActionResult Edit(RealizationVM entity)
    {
        var urlRedirect = $"/Realization/Index?cuttingId={entity.CuttingPlantationId}";

        try
        {
           // if (!ModelState.IsValid)
           // {
           //     return Redirect(urlRedirect);
           // }

            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            var returnResponse = _realizationService.Update(entity);
            if (returnResponse.executionState == ExecutionState.Created)
            {
                HttpContext.Session.SetString("Message", "Realization has been Updated successfully.");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
            }
            else
            {
                HttpContext.Session.SetString("Message", returnResponse.message);
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
            }

            return Redirect(urlRedirect);
        }
        catch
        {
            return Redirect(urlRedirect);
        }
    }





}
