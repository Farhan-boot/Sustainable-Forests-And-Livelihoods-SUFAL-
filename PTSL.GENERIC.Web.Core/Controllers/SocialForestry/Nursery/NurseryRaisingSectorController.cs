using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry.Nursery
{
    [SessionAuthorize]
    public class NurseryRaisingSectorController : Controller
    {
        private readonly INurseryRaisingSectorService _nurseryTypeService;

        public NurseryRaisingSectorController(HttpHelper httpHelper)
        {
            _nurseryTypeService = new NurseryRaisingSectorService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<NurseryRaisingSectorVM> entity, string message) returnResponse = _nurseryTypeService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) returnResponse = _nurseryTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new NurseryRaisingSectorVM();
            ViewBag.RaisingSectorType = new SelectList(EnumHelper.GetEnumDropdowns<RaisingSectorType>(), "Id", "Name");
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(NurseryRaisingSectorVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) returnResponse = _nurseryTypeService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Nursery Type created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "NurseryRaisingSector");

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
            ViewBag.RaisingSectorType = EnumHelper.GetEnumDropdowns<RaisingSectorType>();

            (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) returnResponse = _nurseryTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, NurseryRaisingSectorVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "NurseryRaisingSector");

                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) returnResponse = _nurseryTypeService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Nursery Type updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "NurseryRaisingSector");

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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _nurseryTypeService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, NurseryRaisingSectorVM entity, string message) returnResponse = _nurseryTypeService.Delete(id);
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