using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.AccountManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.AccountManagement;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.AccountManagement;

[SessionAuthorize]
public class SourceOfFundController : Controller
{
    private readonly ISourceOfFundService _sourceOfFundService;

    public SourceOfFundController(HttpHelper httpHelper)
    {
        _sourceOfFundService = new SourceOfFundService(httpHelper);
    }

    public ActionResult Index()
    {
        (ExecutionState executionState, List<SourceOfFundVM> entity, string message) returnResponse = _sourceOfFundService.List();
        return View(returnResponse.entity);
    }

    [HttpPost]
    public JsonResult Pagination(JqueryDatatableParam jqueryDatatableParam)
    {
        return Json(new { }, SerializerOption.Default);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, SourceOfFundVM entity, string message) returnResponse = _sourceOfFundService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        SourceOfFundVM entity = new SourceOfFundVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(SourceOfFundVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                (ExecutionState executionState, SourceOfFundVM entity, string message) returnResponse = _sourceOfFundService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

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
        (ExecutionState executionState, SourceOfFundVM entity, string message) returnResponse = _sourceOfFundService.GetById(id);

        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, SourceOfFundVM entity)
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
                (ExecutionState executionState, SourceOfFundVM entity, string message) returnResponse = _sourceOfFundService.Update(entity);

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View(entity);
        }
        catch
        {
            return View(entity);
        }
    }

    public JsonResult Delete(int id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _sourceOfFundService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, SourceOfFundVM entity, string message) returnResponse = _sourceOfFundService.Delete(id);
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
    public ActionResult Delete(int id, SourceOfFundVM entity)
    {
        try
        {
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(this.Index), "Category");
            }
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, SourceOfFundVM entity, string message) returnResponse = _sourceOfFundService.Update(entity);

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

}
