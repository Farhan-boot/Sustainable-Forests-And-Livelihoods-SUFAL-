using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Trades;
using PTSL.GENERIC.Web.Core.Services.Implementation.Trades;
using PTSL.GENERIC.Web.Core.Services.Interface.Trades;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.Trades;

[SessionAuthorize]
public class TradeController : Controller
{
    private readonly ITradeService _TradeService;

    public TradeController(HttpHelper httpHelper)
    {
        _TradeService = new TradeService(httpHelper);
    }

    public ActionResult Index()
    {
        (ExecutionState executionState, List<TradeVM> entity, string message) returnResponse = _TradeService.List();
        return View(returnResponse.entity);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, TradeVM entity, string message) returnResponse = _TradeService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        TradeVM entity = new TradeVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(TradeVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                (ExecutionState executionState, TradeVM entity, string message) returnResponse = _TradeService.Create(entity);
                //Session["Message"] = returnResponse.message;
                //Session["executionState"] = returnResponse.executionState;

                if (returnResponse.executionState.ToString() != "Created")
                {
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            //Session["Message"] = ModelState.FirstErrorMessage();
            //Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
        catch
        {
            //Session["Message"] = "Form Data Not Valid.";
            //Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, TradeVM entity, string message) returnResponse = _TradeService.GetById(id);

        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, TradeVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TradeVM entity, string message) returnResponse = _TradeService.Update(entity);
                //Session["Message"] = returnResponse.message;
                //Session["executionState"] = returnResponse.executionState;
                if (returnResponse.executionState.ToString() != "Updated")
                {
                    return View(entity);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            //Session["Message"] = ModelState.FirstErrorMessage();
            //Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
        catch
        {
            //Session["Message"] = "Form Data Not Valid.";
            //Session["executionState"] = ExecutionState.Failure;
            return View(entity);
        }
    }

    public JsonResult Delete(int id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _TradeService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, TradeVM entity, string message) returnResponse = _TradeService.Delete(id);
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
    public ActionResult Delete(int id, TradeVM entity)
    {
        try
        {
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(CategoryController.Index), "Category");
            }
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, TradeVM entity, string message) returnResponse = _TradeService.Update(entity);
            //Session["Message"] = returnResponse.message;
            //Session["executionState"] = returnResponse.executionState;
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
}
