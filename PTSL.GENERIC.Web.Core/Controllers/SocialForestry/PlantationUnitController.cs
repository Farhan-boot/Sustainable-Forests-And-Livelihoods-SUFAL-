using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry
{
    [SessionAuthorize]
    public class PlantationUnitController : Controller
    {
        private readonly IPlantationUnitService _plantationUnitService;

        public PlantationUnitController(HttpHelper httpHelper)
        {
            _plantationUnitService = new PlantationUnitService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<PlantationUnitVM> entity, string message) returnResponse = _plantationUnitService.List();
            return View(returnResponse.entity);
        }

        public JsonResult List()
        {
            var returnResponse = _plantationUnitService.List().entity ?? new List<PlantationUnitVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public JsonResult ListByType(UnitType unitType)
        {
            var returnResponse = _plantationUnitService.ListByType(unitType).entity ?? new List<PlantationUnitVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, PlantationUnitVM entity, string message) returnResponse = _plantationUnitService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new PlantationUnitVM();

            ViewBag.UnitType = new SelectList(EnumHelper.GetEnumDropdowns<UnitType>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(PlantationUnitVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, PlantationUnitVM entity, string message) returnResponse = _plantationUnitService.Create(entity);

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

                        return RedirectToAction(nameof(this.Index), "PlantationUnit");

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

            var returnResponse = _plantationUnitService.GetById(id);

            ViewBag.UnitType = new SelectList(EnumHelper.GetEnumDropdowns<UnitType>(), "Id", "Name", (int)returnResponse.entity.UnitType);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, PlantationUnitVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "PlantationUnit");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, PlantationUnitVM entity, string message) returnResponse = _plantationUnitService.Update(entity);

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

                        return RedirectToAction(nameof(this.Index), "PlantationUnit");

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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _plantationUnitService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, PlantationUnitVM entity, string message) returnResponse = _plantationUnitService.Delete(id);
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