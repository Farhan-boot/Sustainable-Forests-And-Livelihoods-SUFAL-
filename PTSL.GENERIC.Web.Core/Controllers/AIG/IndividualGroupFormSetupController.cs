using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Services.Implementation.AIG;
using PTSL.GENERIC.Web.Core.Services.Interface.AIG;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.AIG;

[SessionAuthorize]
public class IndividualGroupFormSetupController : Controller
{
    private readonly IIndividualGroupFormSetupService _IndividualGroupFormSetupService;
    private readonly FileHelper _fileHelper;

    public IndividualGroupFormSetupController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _IndividualGroupFormSetupService = new IndividualGroupFormSetupService(httpHelper);
        _fileHelper = fileHelper;
    }

    public ActionResult Index()
    {
        (ExecutionState executionState, List<IndividualGroupFormSetupVM> entity, string message) returnResponse = _IndividualGroupFormSetupService.List();
        return View(returnResponse.entity);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) returnResponse = _IndividualGroupFormSetupService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        IndividualGroupFormSetupVM entity = new IndividualGroupFormSetupVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(IndividualGroupFormSetupVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var individualDocumentFile = HttpContext.Request.Form.Files.GetFile("IndividualDocument");
                var groupDocumentFile = HttpContext.Request.Form.Files.GetFile("GroupDocument");

                if (SaveIndividualFile(individualDocumentFile, ref entity, FileType.Document, out var individualError) == false) {
                    HttpContext.Session.SetString("Message", individualError);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }

                if (SaveGroupFile(groupDocumentFile, ref entity, FileType.Document, out var groupFileError) == false) {
                    HttpContext.Session.SetString("Message", groupFileError);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }

                (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) returnResponse = _IndividualGroupFormSetupService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index");
                }
            }
            return View(entity);
        }
        catch
        {
            HttpContext.Session.SetString("Message", "Unexpected error occurred.");
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
        (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) returnResponse = _IndividualGroupFormSetupService.GetById(id);

        return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, IndividualGroupFormSetupVM entity)
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

                var individualDocumentFile = HttpContext.Request.Form.Files.GetFile("IndividualDocument");
                var groupDocumentFile = HttpContext.Request.Form.Files.GetFile("GroupDocument");

                if (SaveIndividualFile(individualDocumentFile, ref entity, FileType.Document, out var individualError) == false) {
                    HttpContext.Session.SetString("Message", individualError);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }

                if (SaveGroupFile(groupDocumentFile, ref entity, FileType.Document, out var groupFileError) == false) {
                    HttpContext.Session.SetString("Message", groupFileError);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }

                (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) returnResponse = _IndividualGroupFormSetupService.Update(entity);

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

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
        (ExecutionState executionState, string message) CheckDataExistOrNot = _IndividualGroupFormSetupService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) returnResponse = _IndividualGroupFormSetupService.Delete(id);
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
    public ActionResult Delete(int id, IndividualGroupFormSetupVM entity)
    {
        try
        {
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(this.Index), "Category");
            }
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, IndividualGroupFormSetupVM entity, string message) returnResponse = _IndividualGroupFormSetupService.Update(entity);
            ////                Session["Message"] = returnResponse.message;
            //                Session["executionState"] = returnResponse.executionState;
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    private bool SaveIndividualFile(IFormFile? file, ref IndividualGroupFormSetupVM entity, FileType fileType, out string error)
    {
        if (file is null)
        {
            error = "File is empty";
            return false;
        }

        var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "IndividualGroupFormSetup", out var errorMessage);
        if (isSaved == false)
        {
            error = errorMessage;
            return false;
        }

        entity.IndividualDocument = fileName;

        error = string.Empty;
        return true;
    }

    private bool SaveGroupFile(IFormFile? file, ref IndividualGroupFormSetupVM entity, FileType fileType, out string error)
    {
        if (file is null)
        {
            error = "File is empty";
            return false;
        }

        var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "IndividualGroupFormSetup", out var errorMessage);
        if (isSaved == false)
        {
            error = errorMessage;
            return false;
        }

        entity.GroupDocument = fileName;

        error = string.Empty;
        return true;
    }
}
