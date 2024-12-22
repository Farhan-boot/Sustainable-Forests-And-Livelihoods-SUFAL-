using Microsoft.AspNetCore.Mvc;
using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry;

////[SessionAuthorize]
public class SocialForestyNgoController : Controller
{
    private readonly ISocialForestryNgoService _socialForestyNgoService;

    public SocialForestyNgoController(HttpHelper httpHelper)
    {
        _socialForestyNgoService = new SocialForestryNgoService(httpHelper);
    }

    public ActionResult Index()
    {
        (ExecutionState executionState, List<SocialForestryNgoVM> entity, string message) returnResponse = _socialForestyNgoService.List();
        return View(returnResponse.entity);
    }

    public JsonResult List()
    {
        var returnResponse = _socialForestyNgoService.List().entity ?? new List<SocialForestryNgoVM>();
        return Json(new { Data = returnResponse }, SerializerOption.Default);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, SocialForestryNgoVM entity, string message) returnResponse = _socialForestyNgoService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        SocialForestryNgoVM entity = new SocialForestryNgoVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(SocialForestryNgoVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                (ExecutionState executionState, SocialForestryNgoVM entity, string message) returnResponse = _socialForestyNgoService.Create(entity);

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
        (ExecutionState executionState, SocialForestryNgoVM entity, string message) returnResponse = _socialForestyNgoService.GetById(id);

        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, SocialForestryNgoVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(SocialForestyNgoController.Index), "SocialForestyNgo");
                }
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, SocialForestryNgoVM entity, string message) returnResponse = _socialForestyNgoService.Update(entity);
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
        (ExecutionState executionState, string message) CheckDataExistOrNot = _socialForestyNgoService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, SocialForestryNgoVM entity, string message) returnResponse = _socialForestyNgoService.Delete(id);
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
    public ActionResult Delete(int id, SocialForestryNgoVM entity)
    {
        try
        {
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(SocialForestyNgoController.Index), "SocialForestyNgo");
            }
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, SocialForestryNgoVM entity, string message) returnResponse = _socialForestyNgoService.Update(entity);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
}