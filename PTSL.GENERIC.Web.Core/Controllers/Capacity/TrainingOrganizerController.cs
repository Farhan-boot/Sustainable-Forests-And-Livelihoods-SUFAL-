using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Controllers.Capacity
{
    [SessionAuthorize]
    public class TrainingOrganizerController : Controller
    {
        private readonly ITrainingOrganizerService _TrainingOrganizerService;
        private readonly IDivisionService _DivisionService;

        public TrainingOrganizerController(HttpHelper httpHelper)
        {
            _TrainingOrganizerService = new TrainingOrganizerService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
        }
        // GET: TrainingOrganizer
        public ActionResult Index()
        {
            (ExecutionState executionState, List<TrainingOrganizerVM> entity, string message) returnResponse = _TrainingOrganizerService.List();
            return View(returnResponse.entity);
        }

        // GET: TrainingOrganizer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, TrainingOrganizerVM entity, string message) returnResponse = _TrainingOrganizerService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: TrainingOrganizer/Create
        public ActionResult Create()
        {
            TrainingOrganizerVM entity = new TrainingOrganizerVM();
            return View(entity);
        }

        // POST: TrainingOrganizer/Create
        [HttpPost]
        public ActionResult Create(TrainingOrganizerVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, TrainingOrganizerVM entity, string message) returnResponse = _TrainingOrganizerService.Create(entity);
//                    Session["Message"] = returnResponse.message;
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
//                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
//                Session["Message"] = "Form Data Not Valid.";
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }


        // GET: TrainingOrganizer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, TrainingOrganizerVM entity, string message) returnResponse = _TrainingOrganizerService.GetById(id);

            return View(returnResponse.entity);
        }

        // POST: TrainingOrganizer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TrainingOrganizerVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(TrainingOrganizerController.Index), "TrainingOrganizer");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, TrainingOrganizerVM entity, string message) returnResponse = _TrainingOrganizerService.Update(entity);
//                    Session["Message"] = returnResponse.message;
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

//                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
//                Session["Message"] = "Form Data Not Valid.";
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        // GET: TrainingOrganizer/Delete/5
        public JsonResult Delete(int id)
        {
            var result = _TrainingOrganizerService.SoftDelete(id);
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

        // POST: TrainingOrganizer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TrainingOrganizerVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(TrainingOrganizerController.Index), "TrainingOrganizer");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TrainingOrganizerVM entity, string message) returnResponse = _TrainingOrganizerService.Update(entity);
//                Session["Message"] = returnResponse.message;
//                Session["executionState"] = returnResponse.executionState;
                //return View(returnResponse.entity);
                // return RedirectToAction("Edit?id="+id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
