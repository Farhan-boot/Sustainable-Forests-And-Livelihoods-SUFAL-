using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry.Cutting
{
    [SessionAuthorize]
    public class DistributionPercentageController : Controller
    {
        private readonly IDistributionPercentageService _distributionPercentageService;
        private readonly IPlantationTypeService _plantationTypeService;
        private readonly IDistributionFundTypeService _distributionFundTypeService;

        public DistributionPercentageController(HttpHelper httpHelper)
        {
            _distributionPercentageService = new DistributionPercentageService(httpHelper);
            _plantationTypeService = new PlantationTypeService(httpHelper);
            _distributionFundTypeService = new DistributionFundTypeService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) returnResponse = _distributionPercentageService.List();
            return View(returnResponse.entity);
        }

        public JsonResult List()
        {
            var returnResponse = _distributionPercentageService.List().entity ?? new List<DistributionPercentageVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) returnResponse = _distributionPercentageService.GetByPlantationTypeId(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {

            var entity = new DistributionPercentageVM();
            var plantationType = _plantationTypeService.List().entity ?? new List<PlantationTypeVM>();
            var distributionFundType = _distributionFundTypeService.List().entity ?? new List<DistributionFundTypeVM>();
            ViewBag.PlantationType = plantationType;
            ViewBag.DistributionFundType = distributionFundType;

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(DistributionPercentageCustomVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    foreach (var item in entity.DistributionPercentageListVM)
                    {

                        item.IsActive = true;
                        item.CreatedAt = DateTime.Now;
                    }
                    (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) returnResponse = _distributionPercentageService.CreateRange(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(new { Success = false, Message = returnResponse.message, RedirectUrl = string.Empty }, SerializerOption.Default);
                    }
                    else
                    {
                        var urlRedirect = Url.Action(nameof(this.Index), "DistributionPercentage");

                        HttpContext.Session.SetString("Message", "Distribution Percentage created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Nursery distributed successfully", RedirectUrl = urlRedirect },
                            SerializerOption.Default);

                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return Json(
                   new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                   SerializerOption.Default);
            }
            catch
            {
                return Json(
                   new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                   SerializerOption.Default);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantationType = _plantationTypeService.List().entity ?? new List<PlantationTypeVM>();
            var distributionFundType = _distributionFundTypeService.List().entity ?? new List<DistributionFundTypeVM>();


            ViewBag.CuurentPlantationTypeId = id;
            ViewBag.PlantationType = plantationType;
            ViewBag.DistributionFundType = distributionFundType;
            (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) returnResponse = _distributionPercentageService.GetByPlantationTypeId(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, DistributionPercentageCustomVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var plantationType = _plantationTypeService.List().entity ?? new List<PlantationTypeVM>();
                    var distributionFundType = _distributionFundTypeService.List().entity ?? new List<DistributionFundTypeVM>();
                    ViewBag.PlantationType = plantationType;
                    ViewBag.DistributionFundType = distributionFundType;

                    List<DistributionPercentageVM> currentEntity = _distributionPercentageService.GetByPlantationTypeId(id).entity ?? new List<DistributionPercentageVM>();


                    if (entity.DistributionPercentageListVM == null || entity.DistributionPercentageListVM.Count <= 0)
                    {
                        return Json(
                            new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                                    SerializerOption.Default);
                    }


                    foreach (var item in entity.DistributionPercentageListVM)
                    {

                        item.IsActive = true;
                        item.IsDeleted = false;
                        item.CreatedAt =currentEntity.Find(a=>a.Id==item.Id).CreatedAt;
                        item.CreatedBy= currentEntity.Find(a => a.Id == item.Id).CreatedBy;
                        item.UpdatedAt = DateTime.Now;
                        item.Id = 0;
                    }

                    (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) returnResponse = _distributionPercentageService.UpadateRange(id, entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                                    new { Success = false, Message = returnResponse.message, RedirectUrl = string.Empty },
                                    SerializerOption.Default);
                    }
                    else
                    {
                        var urlRedirect = Url.Action(nameof(this.Index), "DistributionPercentage");
                        HttpContext.Session.SetString("Message", "Distribution Percentage updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                           new { Success = true, Message = returnResponse.message, RedirectUrl = urlRedirect },
                           SerializerOption.Default);

                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                   new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                   SerializerOption.Default);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _distributionPercentageService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, DistributionPercentageVM entity, string message) returnResponse = _distributionPercentageService.Delete(id);
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
    }
}