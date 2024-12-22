using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry.Cutting;

[SessionAuthorize]
public class DistributionController : Controller
{
    private readonly ICuttingPlantationService _cuttingPlantationService;
    private readonly INewRaisedPlantationService _newRaisedPlantationService;
    private readonly IPlantationUnitService _plantationUnitService;
    private readonly IShareDistributionService _shareDistributionService;

    private readonly FileHelper _fileHelper;

    public DistributionController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _cuttingPlantationService = new CuttingPlantationService(httpHelper);
        _newRaisedPlantationService = new NewRaisedPlantationService(httpHelper);
        _plantationUnitService = new PlantationUnitService(httpHelper);
        _shareDistributionService = new ShareDistributionService(httpHelper);

        _fileHelper = fileHelper;
    }

    public ActionResult Index(long cuttingId)
    {
        if (cuttingId == default)
        {
            return NotFound();
        }

        var returnResponse = _shareDistributionService.GetDefaultDistributionData(cuttingId);
        if (returnResponse.entity is not null)
        {
            returnResponse.entity.ShareDistributions = _shareDistributionService.ListByCuttingPlantation(cuttingId).entity ?? new List<ShareDistributionVM>();
        }

        return View(returnResponse.entity);
    }

    public ActionResult Create(long newRaisedId)
    {
        if (newRaisedId == default)
        {
            return NotFound();
        }

        var newRaisedResult = _newRaisedPlantationService.GetDetails(newRaisedId);
        var plantationUnits = _plantationUnitService.List().entity ?? new List<Model.EntityViewModels.SocialForestry.PlantationUnitVM>();

        ViewBag.NewRaisedDetails = newRaisedResult.entity;
        ViewBag.PlantationUnit = plantationUnits;

        return View(new CuttingPlantationVM());
    }

    [HttpPost]
    public ActionResult Create(ShareDistributionVM entity)
    {
        var urlRedirect = $"/Distribution?cuttingId={entity.CuttingPlantationId}";

        try
        {
            if (!ModelState.IsValid)
            {
                return Redirect(urlRedirect);
            }

            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            var depositFile = HttpContext.Request.Form.Files.GetFile("DepositFile");
            if (depositFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(depositFile, null, "Distribution", out var errorMessage);
                if (isSaved == false)
                {
                    HttpContext.Session.SetString("Message", errorMessage);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                }

                entity.DepositFile = fileUrl;
            }

            var returnResponse = _shareDistributionService.Create(entity);
            if (returnResponse.executionState == ExecutionState.Created)
            {
                HttpContext.Session.SetString("Message", "Distribution has been created successfully.");
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
        var result = _shareDistributionService.SoftDelete(id);
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
