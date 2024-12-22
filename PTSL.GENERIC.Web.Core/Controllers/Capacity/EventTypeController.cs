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
    public class EventTypeController : Controller
    {
        private readonly IEventTypeService _EventTypeService;
        private readonly IDivisionService _DivisionService;

        public EventTypeController(HttpHelper httpHelper)
        {
            _EventTypeService = new EventTypeService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
        }
        // GET: EventType
        public ActionResult Index()
        {
            (ExecutionState executionState, List<EventTypeVM> entity, string message) returnResponse = _EventTypeService.List();
            return View(returnResponse.entity);
        }

        // GET: EventType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, EventTypeVM entity, string message) returnResponse = _EventTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: EventType/Create
        public ActionResult Create()
        {
            EventTypeVM entity = new EventTypeVM();
            return View(entity);
        }

        // POST: EventType/Create
        [HttpPost]
        public ActionResult Create(EventTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, EventTypeVM entity, string message) returnResponse = _EventTypeService.Create(entity);
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


        // GET: EventType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, EventTypeVM entity, string message) returnResponse = _EventTypeService.GetById(id);

            return View(returnResponse.entity);
        }

        // POST: EventType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(EventTypeController.Index), "EventType");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, EventTypeVM entity, string message) returnResponse = _EventTypeService.Update(entity);
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

        // GET: EventType/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _EventTypeService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Failure")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);

            }
            (ExecutionState executionState, EventTypeVM entity, string message) returnResponse = _EventTypeService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "EventType deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
            //return View();
        }

        // POST: EventType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EventTypeVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(EventTypeController.Index), "EventType");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, EventTypeVM entity, string message) returnResponse = _EventTypeService.Update(entity);
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
