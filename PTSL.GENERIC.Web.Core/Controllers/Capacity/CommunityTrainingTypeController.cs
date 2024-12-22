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
    public class CommunityTrainingTypeController : Controller
    {
        private readonly ICommunityTrainingTypeService _CommunityTrainingTypeService;
        private readonly IDivisionService _DivisionService;

        public CommunityTrainingTypeController(HttpHelper httpHelper)
        {
            _CommunityTrainingTypeService = new CommunityTrainingTypeService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
        }

        // GET: CommunityTrainingType
        public ActionResult Index()
        {
            (ExecutionState executionState, List<CommunityTrainingTypeVM> entity, string message) returnResponse = _CommunityTrainingTypeService.List();
            return View(returnResponse.entity);
        }

        // GET: CommunityTrainingType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) returnResponse = _CommunityTrainingTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: CommunityTrainingType/Create
        public ActionResult Create()
        {
            CommunityTrainingTypeVM entity = new CommunityTrainingTypeVM();
            return View(entity);
        }

        // POST: CommunityTrainingType/Create
        [HttpPost]
        public ActionResult Create(CommunityTrainingTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) returnResponse = _CommunityTrainingTypeService.Create(entity);
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


        // GET: CommunityTrainingType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) returnResponse = _CommunityTrainingTypeService.GetById(id);

            return View(returnResponse.entity);
        }

        // POST: CommunityTrainingType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CommunityTrainingTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(CommunityTrainingTypeController.Index), "CommunityTrainingType");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) returnResponse = _CommunityTrainingTypeService.Update(entity);
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

        // GET: CommunityTrainingType/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _CommunityTrainingTypeService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            if (CheckDataExistOrNot.executionState.ToString() == "Failure")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);

            }
            (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) returnResponse = _CommunityTrainingTypeService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "CommunityTrainingType deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
            //return View();
        }

        // POST: CommunityTrainingType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CommunityTrainingTypeVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CommunityTrainingTypeController.Index), "CommunityTrainingType");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, CommunityTrainingTypeVM entity, string message) returnResponse = _CommunityTrainingTypeService.Update(entity);
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
