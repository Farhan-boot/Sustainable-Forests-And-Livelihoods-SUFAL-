using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class ForestCircleController : Controller
    {
        private readonly IForestCircleService _ForestCircleService;

        public ForestCircleController(HttpHelper httpHelper)
        {
            _ForestCircleService = new ForestCircleService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<ForestCircleVM> entity, string message) returnResponse = _ForestCircleService.List();
            return View(returnResponse.entity);
        }

        // TODO: Complete
        [HttpPost]
        public JsonResult Pagination(JqueryDatatableParam jqueryDatatableParam)
        {
            return Json(new {  }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            ForestCircleVM entity = new ForestCircleVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(ForestCircleVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

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
            (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.GetById(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, ForestCircleVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "Category");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _ForestCircleService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.Delete(id);
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
        public ActionResult Delete(int id, ForestCircleVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.Update(entity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
