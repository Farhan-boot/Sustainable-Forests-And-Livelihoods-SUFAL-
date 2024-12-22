using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class UpazillaController : Controller
    {
        private readonly IUpazillaService _UpazillaService;
        private readonly IDistrictService _DistrictService;
        private readonly IDivisionService _DivisionService;




        public UpazillaController(HttpHelper httpHelper)
        {
            _UpazillaService = new UpazillaService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);

        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<UpazillaVM> entity, string message) returnResponse = _UpazillaService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponse = _DivisionService.List();
            ViewBag.DivisionId = new SelectList("");
            ViewBag.DistrictId = new SelectList("");
            if (returnResponse.entity != null)
            {
                ViewBag.DivisionId = new SelectList(returnResponse.entity, "Id", "Name");
            }
            UpazillaVM entity = new UpazillaVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(UpazillaVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.Create(entity);
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
            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.GetById(id);

            (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponseDivision = _DivisionService.List();
            (ExecutionState executionState, List<DistrictVM> entity, string message) returnResponseDistrict = _DistrictService.List();


            ViewBag.DivisionId = new SelectList("");
            ViewBag.DistrictId = new SelectList("");

            if (returnResponseDistrict.entity != null)
            {
                ViewBag.DistrictId = new SelectList(returnResponseDistrict.entity, "Id", "Name", returnResponse.entity.DistrictId);
            }

            if (returnResponseDivision.entity != null)
            {
                ViewBag.DivisionId = new SelectList(returnResponseDivision.entity, "Id", "Name", returnResponse.entity.District.DivisionId);
            }

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, UpazillaVM entity)
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
                    (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.Update(entity);
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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _UpazillaService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.Delete(id);
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
        public ActionResult Delete(int id, UpazillaVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, UpazillaVM entity, string message) returnResponse = _UpazillaService.Update(entity);
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
