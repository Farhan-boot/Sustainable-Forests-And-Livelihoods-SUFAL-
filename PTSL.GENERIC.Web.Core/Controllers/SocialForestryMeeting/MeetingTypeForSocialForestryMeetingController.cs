using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestryMeeting;

[SessionAuthorize]
public class MeetingTypeForSocialForestryMeetingController : Controller
{
    private readonly IMeetingTypeForSocialForestryMeetingService _MeetingTypeForSocialForestryMeetingService;

    public MeetingTypeForSocialForestryMeetingController(HttpHelper httpHelper)
    {
        _MeetingTypeForSocialForestryMeetingService = new MeetingTypeForSocialForestryMeetingService(httpHelper);
    }

    public ActionResult Index()
    {
        (ExecutionState executionState, List<MeetingTypeForSocialForestryMeetingVM> entity, string message) returnResponse = _MeetingTypeForSocialForestryMeetingService.List();
        return View(returnResponse.entity);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) returnResponse = _MeetingTypeForSocialForestryMeetingService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        MeetingTypeForSocialForestryMeetingVM entity = new MeetingTypeForSocialForestryMeetingVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(MeetingTypeForSocialForestryMeetingVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) returnResponse = _MeetingTypeForSocialForestryMeetingService.Create(entity);
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
        (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) returnResponse = _MeetingTypeForSocialForestryMeetingService.GetById(id);

        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, MeetingTypeForSocialForestryMeetingVM entity)
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
                (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) returnResponse = _MeetingTypeForSocialForestryMeetingService.Update(entity);
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
        (ExecutionState executionState, string message) CheckDataExistOrNot = _MeetingTypeForSocialForestryMeetingService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) returnResponse = _MeetingTypeForSocialForestryMeetingService.Delete(id);
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
    public ActionResult Delete(int id, MeetingTypeForSocialForestryMeetingVM entity)
    {
        try
        {
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(CategoryController.Index), "Category");
            }
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, MeetingTypeForSocialForestryMeetingVM entity, string message) returnResponse = _MeetingTypeForSocialForestryMeetingService.Update(entity);
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
