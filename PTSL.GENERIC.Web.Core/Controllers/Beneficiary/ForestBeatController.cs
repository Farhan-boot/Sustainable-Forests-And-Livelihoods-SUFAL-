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
    public class ForestBeatController : Controller
    {
        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;

        private readonly IForestBeatService _ForestBeatService;


        public ForestBeatController(HttpHelper httpHelper)
        {
            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);

            _ForestBeatService = new ForestBeatService(httpHelper);

        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<ForestBeatVM> entity, string message) returnResponse = _ForestBeatService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, ForestBeatVM entity, string message) returnResponse = _ForestBeatService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            ForestBeatVM entity = new ForestBeatVM();

            (ExecutionState executionState, List<ForestCircleVM> entity, string message) returnResponse = _ForestCircleService.List();

            ViewBag.ForestCircleId = new SelectList("");
            ViewBag.ForestDivisionId = new SelectList("");
            ViewBag.ForestRangeId = new SelectList("");

            if (returnResponse.entity != null)
            {
                ViewBag.ForestCircleId = new SelectList(returnResponse.entity, "Id", "Name");
            }

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(ForestBeatVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, ForestBeatVM entity, string message) returnResponse = _ForestBeatService.Create(entity);
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
            (ExecutionState executionState, ForestBeatVM entity, string message) returnResponse = _ForestBeatService.GetById(id);
            (ExecutionState executionState, List<ForestCircleVM> entity, string message) forestCircleResponse = _ForestCircleService.List();

            ViewBag.ForestCircleId = new SelectList("");
            ViewBag.ForestDivisionId = new SelectList("");
            ViewBag.ForestRangeId = new SelectList("");

            if (returnResponse.entity != null)
            {
                var forestCircleId = returnResponse.entity?.ForestRange?.ForestDivision?.ForestCircleId ?? 0;
                var forestDivisionId = returnResponse.entity?.ForestRange?.ForestDivisionId ?? 0;
                var forestRangeId = returnResponse.entity?.ForestRangeId ?? 0;

                if (forestCircleResponse.entity != null)
                {
                    ViewBag.ForestCircleId = new SelectList(forestCircleResponse.entity, "Id", "Name", forestCircleId);
                }
                if (forestCircleId != 0)
                {
                    (ExecutionState executionState, List<ForestDivisionVM> entity, string message) forestDivisionResponse = _ForestDivisionService.ListByForestCircle(forestCircleId);

                    if (forestDivisionResponse.entity != null)
                    {
                        ViewBag.ForestDivisionId = new SelectList(forestDivisionResponse.entity, "Id", "Name", forestDivisionId);
                    }
                }
                if (forestDivisionId != 0)
                {
                    (ExecutionState executionState, List<ForestRangeVM> entity, string message) forestRangeResponse = _ForestRangeService.ListByForestDivision(forestDivisionId);

                    if (forestRangeResponse.entity != null)
                    {
                        ViewBag.ForestRangeId = new SelectList(forestRangeResponse.entity, "Id", "Name", forestRangeId);
                    }
                }
            }

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, ForestBeatVM entity)
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
                    (ExecutionState executionState, ForestBeatVM entity, string message) returnResponse = _ForestBeatService.Update(entity);
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
            var result = _ForestBeatService.SoftDelete(id);
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
        public ActionResult Delete(int id, ForestBeatVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, ForestBeatVM entity, string message) returnResponse = _ForestBeatService.Update(entity);
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
