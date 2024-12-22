using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.AIG;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AIG;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.AIG;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.AIG;

[SessionAuthorize]
public class IndividualLDFInfoFormController : Controller
{
    private readonly IIndividualLDFInfoFormService _IndividualLDFInfoFormService;
    private readonly IIndividualGroupFormSetupService _IndividualGroupFormSetupService;

    private readonly ISurveyService _SurveyService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;

    private readonly INgoService _ngoService;
    private readonly FileHelper _fileHelper;

    public IndividualLDFInfoFormController(HttpHelper httpHelper, FileHelper fileHelper)
    {
        _IndividualLDFInfoFormService = new IndividualLDFInfoFormService(httpHelper);
        _IndividualGroupFormSetupService = new IndividualGroupFormSetupService(httpHelper);

        _SurveyService = new SurveyService(httpHelper);

        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);

        _ngoService = new NgoService(httpHelper);
        _fileHelper = fileHelper;
    }

    public ActionResult Index()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        ViewBag.IndividualDocument = (_IndividualGroupFormSetupService.List().entity ?? new List<IndividualGroupFormSetupVM>()).FirstOrDefault()?.IndividualDocument;

        var filter = AuthLocationHelper.GetFilterFromSession<IndividualLDFFilterVM>(HttpContext, 50);
        //(ExecutionState executionState, PaginationResutlVM<IndividualLDFInfoFormVM> entity, string message) returnResponse = _IndividualLDFInfoFormService.ListByFilter(filter);

        //returnResponse.entity.aaData
        return View(new List<IndividualLDFInfoFormVM>());
    }

    [HttpPost]
    public ActionResult IndexFilter(IndividualLDFFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.HasGender ? (int)filter.Gender! : null);
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);

        ViewBag.IndividualDocument = (_IndividualGroupFormSetupService.List().entity ?? new List<IndividualGroupFormSetupVM>()).FirstOrDefault()?.IndividualDocument;

        //(ExecutionState executionState, PaginationResutlVM<IndividualLDFInfoFormVM> entity, string message) returnResponse = _IndividualLDFInfoFormService.ListByFilter(filter);

        //returnResponse.entity.aaData
        return View("Index", new List<IndividualLDFInfoFormVM>());
    }

    public ActionResult ListByFilter(IndividualLDFFilterVM filter)
    {
        if (filter is null) return Json(null);

        var result = _IndividualLDFInfoFormService.ListByFilter(filter);
        return Json(
            new
            {
                Success = result.executionState == ExecutionState.Retrieved,
                Data = result.entity,
                Message = result.message
            },
            SerializerOption.Default);
    }
    public ActionResult ListByFilterBasic(IndividualLDFFilterVM filter)
    {
        if (filter is null) return Json(null);

        (ExecutionState executionState, List<IndividualLDFInfoFormVM> entity, string message) result = _IndividualLDFInfoFormService.ListByFilterBasic(filter);
        return Json(
            new
            {
                Success = result.executionState == ExecutionState.Retrieved,
                Data = result.entity,
                Message = result.message
            },
            SerializerOption.Default);
    }

    public ActionResult ListByFilterBeneficiary(IndividualLDFFilterVM filter)
    {
        if (filter is null) return Json(null);

        var result = _IndividualLDFInfoFormService.ListByFilterBeneficiary(filter);
        return Json(
            new
            {
                Success = result.executionState == ExecutionState.Retrieved,
                Data = result.entity,
                Message = result.message
            },
            SerializerOption.Default);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) returnResponse = _IndividualLDFInfoFormService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Create()
    {
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
        ViewBag.SurveyId = new SelectList("");

        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        var entity = new IndividualLDFInfoFormVM();
        return View(entity);
    }

    [HttpPost]
    public ActionResult Create(IndividualLDFInfoFormVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var documentFile = HttpContext.Request.Form.Files.GetFile("IndividualLDFInfoForm");

                // Save image files
                if (SaveFiles(documentFile, ref entity, FileType.Document, out var imageFileError) == false)
                {
                    HttpContext.Session.SetString("Message", imageFileError);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Create");
                }

                (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) returnResponse = _IndividualLDFInfoFormService.Create(entity);


                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Create");
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Individual LDF information has been created successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Create");
        }
        catch
        {
            return RedirectToAction("Create");
        }
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) result = _IndividualLDFInfoFormService.GetById(id);
        if (result.entity is null)
        {
            HttpContext.Session.SetString("Message", "Individual LDF Information not found");
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Index");
        }

        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name", result.entity.NgoId);

        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,

            result.entity.ForestCircleId,
            result.entity.ForestDivisionId,
            result.entity.ForestRangeId,
            result.entity.ForestBeatId,
            result.entity.ForestFcvVcfId,
            result.entity.DivisionId,
            result.entity.DistrictId,
            result.entity.UpazillaId,
            result.entity.UnionId
        );

        ViewBag.SurveyId = new SelectList(_SurveyService.GetBeneficiaryByFcvVcfId(result.entity.ForestFcvVcfId).entity ?? new List<SurveyVM>(), "Id", "BeneficiaryName", result.entity.SurveyId);

        return View(result.entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, IndividualLDFInfoFormVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var documentFile = HttpContext.Request.Form.Files.GetFile("IndividualLDFInfoForm");

                // Save image files
                if (documentFile is not null && SaveFiles(documentFile, ref entity, FileType.Document, out var imageFileError) == false)
                {
                    HttpContext.Session.SetString("Message", imageFileError);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }

                (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) returnResponse = _IndividualLDFInfoFormService.Update(entity);

                if (returnResponse.executionState.ToString() != "Updated")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return View(entity);
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Individual LDF information has been updated successfully");
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
        (ExecutionState executionState, string message) CheckDataExistOrNot = _IndividualLDFInfoFormService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) returnResponse = _IndividualLDFInfoFormService.Delete(id);
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
    public ActionResult Delete(int id, IndividualLDFInfoFormVM entity)
    {
        try
        {
            if (id != entity.Id)
            {
                return RedirectToAction(nameof(this.Index), "Category");
            }
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            (ExecutionState executionState, IndividualLDFInfoFormVM entity, string message) returnResponse = _IndividualLDFInfoFormService.Update(entity);
            ////                Session["Message"] = returnResponse.message;
            //                Session["executionState"] = returnResponse.executionState;
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    public ActionResult ApproveLDF(long ldfId, double approvedLoanAmount)
    {
        try
        {
            (ExecutionState executionState, bool entity, string message) returnResponse = _IndividualLDFInfoFormService.ApproveLDF(ldfId, approvedLoanAmount);

            return Json(
                new { Success = returnResponse.entity, Message = returnResponse.message },
                SerializerOption.Default);
        }
        catch (Exception)
        {
            return Json(
                new { Success = false, Message = "Unexpected error occurred." },
                SerializerOption.Default);
        }
    }

    private bool SaveFiles(IFormFile? file, ref IndividualLDFInfoFormVM entity, FileType fileType, out string error)
    {
        if (file is null)
        {
            error = "File is empty";
            return false;
        }

        var (isSaved, fileUrl, _) = _fileHelper.SaveFile(file, fileType, "IndividualLDFInfoForm", out var errorMessage);
        if (isSaved == false)
        {
            error = errorMessage;
            return false;
        }

        entity.DocumentInfoURL = fileUrl;

        error = string.Empty;
        return true;
    }




    //DataTable Get List using server site Pagination 
    //[HttpPost]
    public ActionResult GetIndividualLDFInfoFormListByPagination(PTSL.GENERIC.Web.Core.Controllers.AIG.JqueryDatatableParam param)
    {

        AuthLocationHelper.GenerateViewBagForForestAndCivil(
                     HttpContext,
                     ViewBag,
                     _ForestCircleService,
                     _ForestDivisionService,
                     _ForestRangeService,
                     _ForestBeatService,
                     _ForestFcvVcfService,
                     _DivisionService,
                     _DistrictService,
                     _UpazillaService,
                     _UnionService
                   );



        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name");


        var filter = AuthLocationHelper.GetFilterFromSession<IndividualLDFFilterVM>(HttpContext);
        filter.iDisplayStart = param.iDisplayStart;
        filter.iDisplayLength = param.iDisplayLength;
        filter.sSearch = param.sSearch;
        (ExecutionState executionState, PaginationResutlVM<IndividualLDFInfoFormVM> entity, string message) returnResponse = _IndividualLDFInfoFormService.ListByFilter(filter);



        return Json(new
        {
            param.sEcho,
            iTotalRecords = returnResponse.entity.iTotalRecords,
            iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
            aaData = returnResponse.entity.aaData
        }, SerializerOption.Default);

        //return View(new List<CommunityTrainingVM>());
    }



    [HttpPost]
    public ActionResult IndexFilterIndividualLDFInfoFormListByPagination(IndividualLDFFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
         HttpContext,
         ViewBag,
         _ForestCircleService,
         _ForestDivisionService,
         _ForestRangeService,
         _ForestBeatService,
         _ForestFcvVcfService,
         _DivisionService,
         _DistrictService,
         _UpazillaService,
         _UnionService,
         filter
       );


        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.HasGender ? (int)filter.Gender! : null);
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_ngoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);

        ViewBag.IndividualDocument = (_IndividualGroupFormSetupService.List().entity ?? new List<IndividualGroupFormSetupVM>()).FirstOrDefault()?.IndividualDocument;


        (ExecutionState executionState, PaginationResutlVM<IndividualLDFInfoFormVM> entity, string message) returnResponse = _IndividualLDFInfoFormService.ListByFilter(filter);


        return Json(new
        {
            filter.sEcho,
            iTotalRecords = returnResponse.entity.iTotalRecords,
            iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
            aaData = returnResponse.entity.aaData
        }, SerializerOption.Default);

        // return View("Index", result.entity);
    }



}


