using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry
{
    [SessionAuthorize]
    public class LandOwningAgencyController : Controller
    {
        private readonly ILandOwningAgencyService _landOwningAgencyService;

        public LandOwningAgencyController(HttpHelper httpHelper)
        {
            _landOwningAgencyService = new LandOwningAgencyService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<LandOwningAgencyVM> entity, string message) returnResponse = _landOwningAgencyService.List();
            return View(returnResponse.entity);
        }

        public JsonResult List()
        {
            var returnResponse = _landOwningAgencyService.List().entity ?? new List<LandOwningAgencyVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, LandOwningAgencyVM entity, string message) returnResponse = _landOwningAgencyService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new LandOwningAgencyVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(LandOwningAgencyVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, LandOwningAgencyVM entity, string message) returnResponse = _landOwningAgencyService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Land Owning Agency created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "LandOwningAgency");

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

            (ExecutionState executionState, LandOwningAgencyVM entity, string message) returnResponse = _landOwningAgencyService.GetById(id);
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, LandOwningAgencyVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "LandOwningAgency");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, LandOwningAgencyVM entity, string message) returnResponse = _landOwningAgencyService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Land Owning Agency updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "LandOwningAgency");

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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _landOwningAgencyService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, LandOwningAgencyVM entity, string message) returnResponse = _landOwningAgencyService.Delete(id);
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