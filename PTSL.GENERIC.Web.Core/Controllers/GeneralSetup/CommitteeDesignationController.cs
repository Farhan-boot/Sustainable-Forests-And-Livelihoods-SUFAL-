using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Controllers.GeneralSetup;

[SessionAuthorize]
public class CommitteeDesignationController : Controller
{
    private readonly ICommitteeDesignationService _SubCommitteeDesignationService;

    public CommitteeDesignationController(HttpHelper httpHelper)
    {
        _SubCommitteeDesignationService = new CommitteeDesignationService(httpHelper);
    }

    public ActionResult Index()
    {
        (ExecutionState executionState, List<CommitteeDesignationVM> entity, string message) returnResponse = _SubCommitteeDesignationService.List();
        return View(returnResponse.entity);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, CommitteeDesignationVM entity, string message) returnResponse = _SubCommitteeDesignationService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        var entity = new CommitteeDesignationVM();

        ViewBag.CommitteeType = new SelectList(EnumHelper.GetEnumDropdowns<CommitteeType>(), "Id", "Name");
        ViewBag.SubCommitteeType = new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name");

        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(CommitteeDesignationVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                (ExecutionState executionState, CommitteeDesignationVM entity, string message) returnResponse = _SubCommitteeDesignationService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Create");
                }
                else
                {
                    HttpContext.Session.SetString("Message", "New committee designation has been created successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index");
                }
            }

            HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
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

        var result = _SubCommitteeDesignationService.GetById(id);
        if (result.entity is not null)
        {
            ViewBag.CommitteeType = new SelectList(EnumHelper.GetEnumDropdowns<CommitteeType>(), "Id", "Name", (int)result.entity.CommitteeType);

            ViewBag.SubCommitteeType = result.entity.SubCommitteeType is null
                ? new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name")
                : new SelectList(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), "Id", "Name", (int)result.entity.SubCommitteeType);
        }

        return View(result.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, CommitteeDesignationVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CommitteeDesignationController.Index), "Index");
                }
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;

                (ExecutionState executionState, CommitteeDesignationVM entity, string message) returnResponse = _SubCommitteeDesignationService.Update(entity);

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Committee designation has been updated successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index");
                }
            }
            HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return View(entity);
        }
    }

    public JsonResult Delete(int id)
    {
        var result = _SubCommitteeDesignationService.SoftDelete(id);
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
}
