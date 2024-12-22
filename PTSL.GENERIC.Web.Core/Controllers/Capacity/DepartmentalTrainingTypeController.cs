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
    public class DepartmentalTrainingTypeController : Controller
    {
        private readonly IDepartmentalTrainingTypeService _DepartmentalTrainingTypeService;
        private readonly IDivisionService _DivisionService;

        public DepartmentalTrainingTypeController(HttpHelper httpHelper)
        {
            _DepartmentalTrainingTypeService = new DepartmentalTrainingTypeService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
        }

        // GET: DepartmentalTrainingType
        public ActionResult Index()
        {
            (ExecutionState executionState, List<DepartmentalTrainingTypeVM> entity, string message) returnResponse = _DepartmentalTrainingTypeService.List();
            return View(returnResponse.entity);
        }

        // GET: DepartmentalTrainingType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse = _DepartmentalTrainingTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: DepartmentalTrainingType/Create
        public ActionResult Create()
        {
            DepartmentalTrainingTypeVM entity = new DepartmentalTrainingTypeVM();
            return View(entity);
        }

        // POST: DepartmentalTrainingType/Create
        [HttpPost]
        public ActionResult Create(DepartmentalTrainingTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse = _DepartmentalTrainingTypeService.Create(entity);
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


        // GET: DepartmentalTrainingType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse = _DepartmentalTrainingTypeService.GetById(id);

            return View(returnResponse.entity);
        }

        // POST: DepartmentalTrainingType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DepartmentalTrainingTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(DepartmentalTrainingTypeController.Index), "DepartmentalTrainingType");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse = _DepartmentalTrainingTypeService.Update(entity);
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

        // GET: DepartmentalTrainingType/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _DepartmentalTrainingTypeService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Failure")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);

            }
            (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse = _DepartmentalTrainingTypeService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "DepartmentalTrainingType deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
            //return View();
        }

        // POST: DepartmentalTrainingType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DepartmentalTrainingTypeVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(DepartmentalTrainingTypeController.Index), "DepartmentalTrainingType");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse = _DepartmentalTrainingTypeService.Update(entity);
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
