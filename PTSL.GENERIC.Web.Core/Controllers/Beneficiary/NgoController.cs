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
    public class NgoController : Controller
    {
        private readonly INgoService _NgoService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestCircleService _ForestCircleService;

        public NgoController(HttpHelper httpHelper)
        {
            _NgoService = new NgoService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<NgoVM> entity, string message) returnResponse = _NgoService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, NgoVM entity, string message) returnResponse = _NgoService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();
            ViewBag.ForestDivisionId = new SelectList("");

            NgoVM entity = new NgoVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(NgoVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, NgoVM entity, string message) returnResponse = _NgoService.Create(entity);
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

            (ExecutionState executionState, NgoVM entity, string message) result = _NgoService.GetById(id);

            ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();
            ViewBag.ForestDivisionId = _ForestDivisionService.ListByMultipleForestCircle(result.entity.ForestCircleIdList ?? new List<long>()).entity ?? new List<ForestDivisionVM>();

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, NgoVM entity)
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
                    (ExecutionState executionState, NgoVM entity, string message) returnResponse = _NgoService.Update(entity);
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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _NgoService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, NgoVM entity, string message) returnResponse = _NgoService.Delete(id);
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
        public ActionResult Delete(int id, NgoVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, NgoVM entity, string message) returnResponse = _NgoService.Update(entity);
////                Session["Message"] = returnResponse.message;
//                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult ListByForestDivisions(List<long> divisions)
        {
            var result = _NgoService.ListByForestDivisions(divisions);
            if (result.entity == null)
            {
                return Json(new List<NgoVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }
    }
}
