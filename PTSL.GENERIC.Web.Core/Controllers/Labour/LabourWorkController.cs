using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Web.Core.Services.Implementation.Labour;
using PTSL.GENERIC.Web.Core.Services.Interface.Labour;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.AIG;

[SessionAuthorize]
public class LabourWorkController : Controller
{
    private readonly ILabourWorkService _LabourWorkService;

    public LabourWorkController(HttpHelper httpHelper)
    {
        _LabourWorkService = new LabourWorkService(httpHelper);
    }

    public ActionResult Index(long labourDatabaseId = default)
    {
        if (labourDatabaseId == default)
        {
            return NotFound();
        }

        var filterList = _LabourWorkService.ListByFilter(new LabourWorkFilterVM
        {
            LabourDatabaseId = labourDatabaseId
        });
        return View(filterList.entity);
    }

    public ActionResult IndexFilter()
    {
        return RedirectToAction("Index");
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, LabourWorkVM entity, string message) returnResponse = _LabourWorkService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create(long labourDatabaseId = default)
    {
        if (labourDatabaseId == default)
        {
            return NotFound();
        }

        var entity = new LabourWorkVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(LabourWorkVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                (ExecutionState executionState, LabourWorkVM entity, string message) returnResponse = _LabourWorkService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Create");
                }
                else
                {
                    HttpContext.Session.SetString("Message", "New Labour work information has been created successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index", new { labourDatabaseId = returnResponse.entity?.LabourDatabaseId });
                }
            }

            HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Create");
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Create");
        }
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        (ExecutionState executionState, LabourWorkVM entity, string message) result = _LabourWorkService.GetById(id);
        if (result.entity is null)
        {
            HttpContext.Session.SetString("Message", "Labour work information not found");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Index");
        }

        return View(result.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, LabourWorkVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                (ExecutionState executionState, LabourWorkVM entity, string message) returnResponse = _LabourWorkService.Update(entity);

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Labour work information has been updated successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index", new { labourDatabaseId = returnResponse.entity?.LabourDatabaseId });
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
        var result = _LabourWorkService.SoftDelete(id);
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

