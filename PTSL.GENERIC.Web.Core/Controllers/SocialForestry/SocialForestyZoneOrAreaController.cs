using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry;

[SessionAuthorize]
public class SocialForestyZoneOrAreaController : Controller
{
    private readonly IZoneOrAreaService _zoneOrAreaService;

    public SocialForestyZoneOrAreaController(HttpHelper httpHelper)
    {
        _zoneOrAreaService = new ZoneOrAreaService(httpHelper);
    }

    public ActionResult Index()
    {
        (ExecutionState executionState, List<ZoneOrAreaVM> entity, string message) returnResponse = _zoneOrAreaService.List();
        return View(returnResponse.entity);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, ZoneOrAreaVM entity, string message) returnResponse = _zoneOrAreaService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        ZoneOrAreaVM entity = new ZoneOrAreaVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(ZoneOrAreaVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                (ExecutionState executionState, ZoneOrAreaVM entity, string message) returnResponse = _zoneOrAreaService.Create(entity);
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
        (ExecutionState executionState, ZoneOrAreaVM entity, string message) returnResponse = _zoneOrAreaService.GetById(id);

        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, ZoneOrAreaVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(SocialForestyZoneOrAreaController.Index), "SocialForestyZoneOrAreaController");
                }
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, ZoneOrAreaVM entity, string message) returnResponse = _zoneOrAreaService.Update(entity);
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
        (ExecutionState executionState, string message) CheckDataExistOrNot = _zoneOrAreaService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, ZoneOrAreaVM entity, string message) returnResponse = _zoneOrAreaService.Delete(id);
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
    public ActionResult Delete(int id, ZoneOrAreaVM entity)
    {
        try
        {
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(SocialForestyZoneOrAreaController.Index), "SocialForestyZoneOrAreaController");
            }
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, ZoneOrAreaVM entity, string message) returnResponse = _zoneOrAreaService.Update(entity);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
}