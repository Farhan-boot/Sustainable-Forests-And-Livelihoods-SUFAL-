using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Common;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Labour;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Labour;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.Labour;

[SessionAuthorize]
public class LabourDatabaseController : Controller
{
    private readonly ILabourDatabaseService _LabourDatabaseService;
    private readonly ILabourDatabaseFileService _LabourDatabaseFileService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IOtherLabourMemberService _otherLabourMemberService;
    private readonly IEthnicityService _EthnicityService;
    private readonly ISurveyService _surveyService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;
    private readonly FileHelper _fileHelper;



    public LabourDatabaseController(HttpHelper httpHelper,FileHelper fileHelper)
    {
        _LabourDatabaseService = new LabourDatabaseService(httpHelper);
        _LabourDatabaseFileService = new LabourDatabaseFileService(httpHelper);

        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _EthnicityService = new EthnicityService(httpHelper);
        _surveyService = new SurveyService(httpHelper);
        _otherLabourMemberService = new OtherLabourMemberService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);
        _fileHelper = fileHelper;
    }
    public IActionResult Index()
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

        ViewBag.OtherLabourId = new SelectList(_otherLabourMemberService.List().entity ?? new List<OtherLabourMemberVM>(), "Id", "Name");
        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

        //var filter = AuthLocationHelper.GetFilterFromSession<LabourDatabaseFilterVM>(HttpContext, 50);
        //(ExecutionState executionState, List<LabourDatabaseVM> entity, string message) returnResponse = _LabourDatabaseService.GetByFilter(filter);

        //return View(returnResponse.entity);
        return View(new List<LabourDatabaseVM>());


    }

    [HttpPost]
    public ActionResult IndexFilter(LabourDatabaseFilterVM filter)
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

        //(ExecutionState executionState, PaginationResutlVM<LabourDatabaseVM> entity, string message) returnResponse = _LabourDatabaseService.GetByFilter(filter);
        return View("Index",new List<LabourDatabaseVM>());
    }

    public ActionResult Create()
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

        ViewBag.SurveyId = new SelectList("");
        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");

        return View(new LabourDatabaseVM());
    }

    [HttpPost]
    public ActionResult Create(LabourDatabaseVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                var imageFiles = HttpContext.Request.Form.Files.GetFiles("LabourDatabaseImageFiles");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("LabourDatabaseDocumentFiles");

                // Save image files
                if (SaveFiles(imageFiles, ref entity, FileType.Image, out var imageFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = imageFileError },
                        SerializerOption.Default);
                }

                // Save document files
                if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = documentFileError },
                        SerializerOption.Default);
                }

                (ExecutionState executionState, LabourDatabaseVM entity, string message) returnResponse = _LabourDatabaseService.Create(entity);

                if (returnResponse.executionState.ToString() != "Created")
                {
                    HttpContext.Session.SetString("Message", returnResponse.message);
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Create");
                }
                else
                {
                    HttpContext.Session.SetString("Message", "Labour database created successfully");
                    HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                    return RedirectToAction("Index");
                }
            }

            HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
            HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

            return RedirectToAction("Create");
        }
        catch
        {
            return RedirectToAction("Create");
        }
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        (ExecutionState executionState, LabourDatabaseVM entity, string message) returnResponse = _LabourDatabaseService.GetById(id);
        return View(returnResponse.entity);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var result = _LabourDatabaseService.GetById(id);

        var resultEntity = result.entity;
        if (resultEntity.SurveyId is null || resultEntity.SurveyId == default)
        {
            ViewBag.Gender = resultEntity.OtherLabourMember?.Gender is null
                ? new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name")
                : new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", (int)resultEntity.OtherLabourMember.Gender);
            ViewBag.EthnicityId = resultEntity.OtherLabourMember?.EthnicityId is null
                ? new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name")
                : new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name", (long)resultEntity.OtherLabourMember.EthnicityId);
        }
        else
        {
            ViewBag.Gender = resultEntity.Survey?.BeneficiaryGender is null
                ? new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name")
                : new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", (int)resultEntity.Survey.BeneficiaryGender);
            ViewBag.EthnicityId = resultEntity.Survey?.BeneficiaryEthnicityId is null
                ? new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name")
                : new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name", (long)resultEntity.Survey.BeneficiaryEthnicityId);
        }

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

            resultEntity.ForestCircleId,
            resultEntity.ForestDivisionId,
            resultEntity.ForestRangeId,
            resultEntity.ForestBeatId,
            resultEntity.ForestFcvVcfId,
            resultEntity.DivisionId,
            resultEntity.DistrictId,
            resultEntity.UpazillaId,
            resultEntity.UnionId
        );

        var surveyLocation = new BeneficiaryFilterVM
        {
            ForestCivilLocation = new ForestCivilLocationVM
            {
                ForestFcvVcfId = result.entity.ForestFcvVcfId
            }
        };

        ViewBag.SurveyId = new SelectList("");

        return View(resultEntity);
    }

    [HttpPost]
    public ActionResult Edit(int id, LabourDatabaseVM entity)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(LabourDatabaseController.Index), "LabourDatabase");
                }
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;

                var imageFiles = HttpContext.Request.Form.Files.GetFiles("LabourDatabaseImageFiles");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("LabourDatabaseDocumentFiles");

                // Save image files
                if (SaveFiles(imageFiles, ref entity, FileType.Image, out var imageFileError) == false)
                {
                    //return Json(
                    //    new { Success = false, Message = imageFileError },
                    //    SerializerOption.Default);
                }

                // Save document files
                if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
                {
                    //return Json(
                    //    new { Success = false, Message = documentFileError },
                    //    SerializerOption.Default);
                }

                (ExecutionState executionState, LabourDatabaseVM entity, string message) returnResponse = _LabourDatabaseService.Update(entity);
                if (returnResponse.executionState.ToString() == "Updated")
                {
                    HttpContext.Session.SetString("Message", "Labour database has been updated successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return RedirectToAction("Index");
                    //return Json(
                    //    new { Success = true, Message = "Labour Database information has been updated", RedirectUrl = "/LabourDatabase/Index" },
                    //    SerializerOption.Default);
                }
                //return Json(
                //    new { Success = false, Message = returnResponse.message },
                //    SerializerOption.Default);
                return View();
            }
            //return Json(
            //    new { Success = false, Message = ModelState.FirstErrorMessage() },
            //    SerializerOption.Default);
            return View();
        }
        catch
        {
            //return Json(
            //    new { Success = false, Message = "Unknown error occurred." },
            //    SerializerOption.Default);
            return View();
        }
    }

    public ActionResult DeleteImageOrDocument(long id)
    {
        var result =_LabourDatabaseFileService.SoftDelete(id);
        if (result.isDelete)
        {
            result.message = "Item deleted successfully.";
        }
        else
        {
            result.message = "Failed to delete this item.";
        }

        return Json(new { Success = result.isDelete, Message = result.message, result.executionState }, SerializerOption.Default);
    }
    public JsonResult Delete(int id)
    {
        (ExecutionState executionState, string message) CheckDataExistOrNot = _LabourDatabaseService.DoesExist(id);
        string message = "Failed, You can't delete this item.";

        if (CheckDataExistOrNot.executionState.ToString() != "Success")
        {
            return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        }

        (ExecutionState executionState, LabourDatabaseVM entity, string message) returnResponse = _LabourDatabaseService.Delete(id);
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

    private bool SaveFiles(IReadOnlyList<IFormFile> files, ref LabourDatabaseVM entity, FileType fileType, out string error)
    {
        foreach (var file in files)
        {
            var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "LabourDatabase", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            var entityFile = new LabourDatabaseFileVM
            {
                FileName = file.FileName,
                FileType = fileType,
                FileUrl = fileName,
            };

            entity?.LabourDatabaseFiles?.Add(entityFile);
        }

        error = string.Empty;
        return true;
    }

    public ActionResult GetOtherLabourMemberById(long Id)
    {
        var result = _otherLabourMemberService.GetById(Id);
        if (result.entity == null)
        {
            return Json(new List<OtherLabourMemberVM>(), SerializerOption.Default);
        }

        return Json(result.entity, SerializerOption.Default);
    }

    //DataTable Get List using server site Pagination
    //[HttpPost]
    public ActionResult GetLabourDatabaseListByPagination(JqueryDatatableParam param)
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


        ViewBag.OtherLabourId = new SelectList(_otherLabourMemberService.List().entity ?? new List<OtherLabourMemberVM>(), "Id", "Name");
        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

        var filter = AuthLocationHelper.GetFilterFromSession<LabourDatabaseFilterVM>(HttpContext);
        filter.iDisplayStart = param.iDisplayStart;
        filter.iDisplayLength = param.iDisplayLength;
        filter.sSearch = param.sSearch;

        (ExecutionState executionState, PaginationResutlVM<LabourDatabaseVM> entity, string message) returnResponse = _LabourDatabaseService.GetByFilter(filter);


        //var displayResult = returnResponse.entity?.Skip(param.iDisplayStart)
          // .Take(param.iDisplayLength).ToList();
       // var totalRecords = returnResponse.entity.Count();


        foreach (var item in returnResponse.entity.aaData)
        {
            if (item.SurveyId is null || item.SurveyId == default)
            {
                item.FullName = item.OtherLabourMember.FullName;
                item.GenderName = Enum.GetName(typeof(Gender), (long)item?.OtherLabourMember.Gender);
                item.NIDName = item.OtherLabourMember.NID;
                item.PhoneNumberName = item.OtherLabourMember.PhoneNumber;
                item.UserTypeName = "Other";
            }
            else
            {
                item.FullName = item.Survey.BeneficiaryName;
                item.GenderName = item.Survey.BeneficiaryGenderString;
                item.NIDName = item.Survey.BeneficiaryNid;
                item.PhoneNumberName = item.Survey.BeneficiaryPhone;
                item.UserTypeName = "Beneficiary";
            }
        }


        return Json(new
        {
            param.sEcho,
            iTotalRecords = returnResponse.entity.iTotalRecords,
            iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
            aaData = returnResponse.entity.aaData
        }, SerializerOption.Default);




        // return View(returnResponse.entity);
    }

    [HttpPost]
    public ActionResult IndexFilterLabourDatabaseListByPagination(LabourDatabaseFilterVM filter)
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
        filter.iDisplayStart = null;
        filter.iDisplayLength = null;

        (ExecutionState executionState, PaginationResutlVM<LabourDatabaseVM> entity, string message) returnResponse = _LabourDatabaseService.GetByFilter(filter);



        foreach (var item in returnResponse.entity.aaData)
        {
            if (item.SurveyId is null || item.SurveyId == default)
            {
                item.FullName = item.OtherLabourMember.FullName;
                item.GenderName = Enum.GetName(typeof(Gender), (long)item?.OtherLabourMember.Gender);
                item.NIDName = item.OtherLabourMember.NID;
                item.PhoneNumberName = item.OtherLabourMember.PhoneNumber;
                item.UserTypeName = "Other";
            }
            else
            {
                item.FullName = item.Survey.BeneficiaryName;
                item.GenderName = item.Survey.BeneficiaryGenderString;
                item.NIDName = item.Survey.BeneficiaryNid;
                item.PhoneNumberName = item.Survey.BeneficiaryPhone;
                item.UserTypeName = "Beneficiary";
            }
        }


        return Json(new
        {
            filter.sEcho,
            iTotalRecords = returnResponse.entity.iTotalRecords,
            iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
            aaData = returnResponse.entity.aaData
        }, SerializerOption.Default);

        //return View("Index", returnResponse.entity);

    }


}
public class JqueryDatatableParam
{
    public string sEcho { get; set; }
    public string sSearch { get; set; }
    public int iDisplayLength { get; set; }
    public int iDisplayStart { get; set; }
    public int iColumns { get; set; }
    public int iSortCol_0 { get; set; }
    public string sSortDir_0 { get; set; }
    public int iSortingCols { get; set; }
    public string sColumns { get; set; }
}

