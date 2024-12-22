using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry
{
    [SessionAuthorize]
    public class ProjectTypeController : Controller
    {
        private readonly IProjectTypeService _projectTypeService;

        public ProjectTypeController(HttpHelper httpHelper)
        {
            _projectTypeService = new ProjectTypeService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<ProjectTypeVM> entity, string message) returnResponse = _projectTypeService.List();
            return View(returnResponse.entity);
        }

        public JsonResult List()
        {
            var returnResponse = _projectTypeService.List().entity ?? new List<ProjectTypeVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, ProjectTypeVM entity, string message) returnResponse = _projectTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new ProjectTypeVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(ProjectTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, ProjectTypeVM entity, string message) returnResponse = _projectTypeService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Project type created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "ProjectType");

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

            (ExecutionState executionState, ProjectTypeVM entity, string message) returnResponse = _projectTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, ProjectTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "ProjectType");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, ProjectTypeVM entity, string message) returnResponse = _projectTypeService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Project type updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                                                return RedirectToAction(nameof(this.Index), "ProjectType");

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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _projectTypeService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, ProjectTypeVM entity, string message) returnResponse = _projectTypeService.Delete(id);
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