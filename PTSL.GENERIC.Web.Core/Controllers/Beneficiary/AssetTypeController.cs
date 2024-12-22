using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class AssetTypeController : Controller
    {
        private readonly IAssetTypeService _AssetTypeService;

        public AssetTypeController(HttpHelper httpHelper)
        {
            _AssetTypeService = new AssetTypeService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<AssetTypeVM> entity, string message) returnResponse = _AssetTypeService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, AssetTypeVM entity, string message) returnResponse = _AssetTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            AssetTypeVM entity = new AssetTypeVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(AssetTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, AssetTypeVM entity, string message) returnResponse = _AssetTypeService.Create(entity);
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);
            }
            catch
            {
                HttpContext.Session.SetString("executionState", "Form Data Not Valid.");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                return View(entity);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, AssetTypeVM entity, string message) returnResponse = _AssetTypeService.GetById(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, AssetTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "AssetType");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, AssetTypeVM entity, string message) returnResponse = _AssetTypeService.Update(entity);
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                return View(entity);
            }
            catch
            {
                HttpContext.Session.SetString("executionState", "Form Data Not Valid.");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                return View(entity);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _AssetTypeService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, AssetTypeVM entity, string message) returnResponse = _AssetTypeService.Delete(id);
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
        public ActionResult Delete(int id, AssetTypeVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "AssetType");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, AssetTypeVM entity, string message) returnResponse = _AssetTypeService.Update(entity);
                HttpContext.Session.SetString("Message", returnResponse.message);
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
