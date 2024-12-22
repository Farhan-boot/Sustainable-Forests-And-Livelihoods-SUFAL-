using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class ForestRangeController : Controller
    {
        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestRangeService _ForestRangeService;

        public readonly IForestDivisionService _ForestDivisionService;

        public ForestRangeController(HttpHelper httpHelper)
        {
            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);

            _ForestDivisionService = new ForestDivisionService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<ForestRangeVM> entity, string message) returnResponse = _ForestRangeService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, ForestRangeVM entity, string message) returnResponse = _ForestRangeService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            ForestRangeVM entity = new ForestRangeVM();

            (ExecutionState executionState, List<ForestCircleVM> entity, string message) returnResponse = _ForestCircleService.List();
            ViewBag.ForestCircleId = new SelectList("");
            ViewBag.ForestDivisionId = new SelectList("");
            if (returnResponse.entity != null)
            {
                ViewBag.ForestCircleId = new SelectList(returnResponse.entity, "Id", "Name");
            }

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(ForestRangeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, ForestRangeVM entity, string message) returnResponse = _ForestRangeService.Create(entity);
////                    Session["Message"] = returnResponse.message;
//                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
////                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
////                Session["Message"] = "Form Data Not Valid.";
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, ForestRangeVM entity, string message) returnResponse = _ForestRangeService.GetById(id);
            (ExecutionState executionState, List<ForestCircleVM> entity, string message) forestCircleResponse = _ForestCircleService.List();

            ViewBag.ForestCircleId = new SelectList("");
            ViewBag.ForestDivisionId = new SelectList("");

            if (forestCircleResponse.entity != null && returnResponse.entity != null)
            {
                var forestCircleId = returnResponse.entity?.ForestDivision.ForestCircleId ?? 0;

                ViewBag.ForestCircleId = new SelectList(forestCircleResponse.entity, "Id", "Name", forestCircleId);

                if (forestCircleId != 0)
                {
                    var divisionByForestCircle = _ForestDivisionService.ListByForestCircle(forestCircleId);

                    if (divisionByForestCircle.entity != null)
                    {
                        ViewBag.ForestDivisionId = new SelectList(divisionByForestCircle.entity, "Id", "Name", returnResponse.entity.ForestDivisionId);
                    }
                }
            }

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, ForestRangeVM entity)
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
                    (ExecutionState executionState, ForestRangeVM entity, string message) returnResponse = _ForestRangeService.Update(entity);
////                    Session["Message"] = returnResponse.message;
//                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

////                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
////                Session["Message"] = "Form Data Not Valid.";
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        public JsonResult Delete(int id)
        {
            var result = _ForestRangeService.SoftDelete(id);
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

        [HttpPost]
        public ActionResult Delete(int id, ForestRangeVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, ForestRangeVM entity, string message) returnResponse = _ForestRangeService.Update(entity);
////                Session["Message"] = returnResponse.message;
//                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
