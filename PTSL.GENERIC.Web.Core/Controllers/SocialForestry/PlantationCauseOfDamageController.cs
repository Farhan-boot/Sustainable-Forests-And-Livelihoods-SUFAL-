using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry
{
    [SessionAuthorize]
    public class PlantationCauseOfDamageController : Controller
    {
        private readonly IPlantationCauseOfDamageService _plantationCauseOfDamageService;

        public PlantationCauseOfDamageController(HttpHelper httpHelper)
        {
            _plantationCauseOfDamageService = new PlantationCauseOfDamageService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<PlantationCauseOfDamageVM> entity, string message) returnResponse = _plantationCauseOfDamageService.List();
            return View(returnResponse.entity);
        }

        public JsonResult List()
        {
            var returnResponse = _plantationCauseOfDamageService.List().entity ?? new List<PlantationCauseOfDamageVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) returnResponse = _plantationCauseOfDamageService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new PlantationCauseOfDamageVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(PlantationCauseOfDamageVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) returnResponse = _plantationCauseOfDamageService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Project type created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "PlantationCauseOfDamage");

                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);

            }
            catch
            {
                return View(entity);

            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) returnResponse = _plantationCauseOfDamageService.GetById(id);
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, PlantationCauseOfDamageVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "PlantationCauseOfDamage");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) returnResponse = _plantationCauseOfDamageService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Project type updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "PlantationCauseOfDamage");

                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);

            }
            catch
            {
                return View(entity);

            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _plantationCauseOfDamageService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, PlantationCauseOfDamageVM entity, string message) returnResponse = _plantationCauseOfDamageService.Delete(id);
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