using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry
{
    [SessionAuthorize]
    public class DistributionFundTypeController : Controller
    {
        private readonly IDistributionFundTypeService _DistributionFundTypeService;

        public DistributionFundTypeController(HttpHelper httpHelper)
        {
            _DistributionFundTypeService = new DistributionFundTypeService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<DistributionFundTypeVM> entity, string message) returnResponse = _DistributionFundTypeService.List();
            return View(returnResponse.entity);
        }

        public JsonResult List()
        {
            var returnResponse = _DistributionFundTypeService.List().entity ?? new List<DistributionFundTypeVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, DistributionFundTypeVM entity, string message) returnResponse = _DistributionFundTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new DistributionFundTypeVM();

            ViewBag.DistributionFundTypeEnum = new SelectList(EnumHelper.GetEnumDropdowns<DistributionFundTypeEnum>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(DistributionFundTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, DistributionFundTypeVM entity, string message) returnResponse = _DistributionFundTypeService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Distribution Fund Type created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "DistributionFundType");

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

            var returnResponse = _DistributionFundTypeService.GetById(id);

            ViewBag.DistributionFundTypeEnum = new SelectList(EnumHelper.GetEnumDropdowns<DistributionFundTypeEnum>(), "Id", "Name", (int)returnResponse.entity.DistributionFundTypeEnum);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, DistributionFundTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "DistributionFundType");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, DistributionFundTypeVM entity, string message) returnResponse = _DistributionFundTypeService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Distribution Fund Type updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "DistributionFundType");

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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _DistributionFundTypeService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, DistributionFundTypeVM entity, string message) returnResponse = _DistributionFundTypeService.Delete(id);
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