using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.MeetingManagement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.MeetingManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Services.Implementation.MeetingManagement;

namespace PTSL.GENERIC.Web.Controllers.MeetingManagement
{
    [SessionAuthorize]
    public class MeetingController : Controller
    {
        private readonly IMeetingService _MeetingService;
        private readonly IMeetingMemberService _MeetingMemberService;
        public readonly IMeetingTypeService _MeetingTypeService;
        public readonly IMeetingFileService _MeetingFileService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;
        private readonly INgoService _NgoService;

        private readonly IEthnicityService _EthnicityService;
        private readonly FileHelper _fileHelper;

        public MeetingController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _MeetingService = new MeetingService(httpHelper);
            _MeetingMemberService = new MeetingMemberService(httpHelper);
            _MeetingTypeService = new MeetingTypeService(httpHelper);
            _MeetingFileService = new MeetingFileService(httpHelper);

            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
            _NgoService = new NgoService(httpHelper);

            _EthnicityService = new EthnicityService(httpHelper);
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

            var filter = AuthLocationHelper.GetFilterFromSession<MeetingFilterVM>(HttpContext, 50);
            //(ExecutionState executionState, List<MeetingVM> entity, string message) returnResponse = _MeetingService.GetMeetingByFilter(filter);

            //Extra Filter
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
            ViewBag.MeetingDate = string.Empty;
            ViewBag.MeetingTypeId = new SelectList(_MeetingTypeService.List().entity ?? new List<MeetingTypeVM>(), "Id", "Name");

            // returnResponse.entity
            return View(new List<MeetingVM>());
        }

        [HttpPost]
        public ActionResult IndexFilter(MeetingFilterVM filter)
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

           // (ExecutionState executionState, PaginationResutlVM<MeetingVM> entity, string message) returnResponse = _MeetingService.GetMeetingByFilter(filter);

            //Extra Filter
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);
            ViewBag.MeetingDate = filter.MeetingDate;
            ViewBag.MeetingTypeId = new SelectList(_MeetingTypeService.List().entity ?? new List<MeetingTypeVM>(), "Id", "Name", filter.MeetingTypeId);

            //returnResponse.entity.aaData 
            return View("Index", new List<MeetingVM>());
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
            (ExecutionState executionState, MeetingVM entity, string message) returnResponse = _MeetingService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            MeetingVM entity = new MeetingVM();

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

            ViewBag.MeetingTypeId = new SelectList(_MeetingTypeService.List().entity ?? new List<MeetingTypeVM>(), "Id", "Name");
            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
            ViewBag.FilterNgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(MeetingVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;

                    entity.MeetingParticipantsMaps = JsonConvert.DeserializeObject<List<MeetingParticipantsMapVM>>(entity.MeetingParticipantsMapsJSON);

                    var imageFiles = HttpContext.Request.Form.Files.GetFiles("MeetingImageFiles[]");
                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("MeetingDocumentFiles[]");

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

                    (ExecutionState executionState, MeetingVM entity, string message) returnResponse = _MeetingService.Create(entity);

                    if (returnResponse.executionState.ToString() == "Created")
                    {
                        HttpContext.Session.SetString("Message", "Meeting information has been created");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "New meeting has been created", RedirectUrl = "/Meeting/Index" },
                            SerializerOption.Default);
                    }
                    return Json(
                        new { Success = false, Message = returnResponse.message },
                        SerializerOption.Default);
                }

                var message = ModelState.FirstErrorMessage();
                return Json(
                    new { Success = false, Message = message },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                    new { Success = false, Message = "Unknown error occurred." },
                    SerializerOption.Default);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, MeetingVM entity, string message) result = _MeetingService.GetById(id);

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

            ViewBag.MeetingTypeId = new SelectList(_MeetingTypeService.List().entity ?? new List<MeetingTypeVM>(), "Id", "Name", result.entity?.MeetingTypeId ?? 0);
            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", result.entity?.NgoId);
            ViewBag.FilterNgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, MeetingVM entity)
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

                    entity.MeetingParticipantsMaps = JsonConvert.DeserializeObject<List<MeetingParticipantsMapVM>>(entity.MeetingParticipantsMapsJSON);

                    var imageFiles = HttpContext.Request.Form.Files.GetFiles("MeetingImageFiles[]");
                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("MeetingDocumentFiles[]");

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

                    (ExecutionState executionState, MeetingVM entity, string message) returnResponse = _MeetingService.Update(entity);
                    if (returnResponse.executionState.ToString() == "Updated")
                    {
                        HttpContext.Session.SetString("Message", "Meeting information has been updated");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Meeting information has been updated", RedirectUrl = "/Meeting/Index" },
                            SerializerOption.Default);
                    }
                    return Json(
                        new { Success = false, Message = returnResponse.message },
                        SerializerOption.Default);
                }
                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage() },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                    new { Success = false, Message = "Unknown error occurred." },
                    SerializerOption.Default);
            }
        }

        [HttpGet]
        public ActionResult DeleteParticipant(long mapId)
        {
            try
            {
                (ExecutionState executionState, bool isDeleted, string message) returnResponse = _MeetingService.DeleteParticipant(mapId);

                if (returnResponse.isDeleted)
                {
                    return Json(
                        new { Success = true, Message = "Successfully deleted." },
                        SerializerOption.Default);
                }

                return Json(
                    new { Success = false, Message = returnResponse.message },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                    new { Success = false, Message = "Unknown error occurred." },
                    SerializerOption.Default);
            }
        }

        public ActionResult DeleteImageOrDocument(long id)
        {
            var result = _MeetingFileService.SoftDelete(id);
            if (result.isDeleted)
            {
                result.message = "Item deleted successfully.";
            }
            else
            {
                result.message = "Failed to delete this item.";
            }

            return Json(new { Success = result.isDeleted, Message = result.message, result.executionState }, SerializerOption.Default);
        }

        public JsonResult Delete(int id)
        {
            var result = _MeetingService.SoftDelete(id);
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

        [HttpPost]
        public ActionResult Delete(int id, MeetingVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, MeetingVM entity, string message) returnResponse = _MeetingService.Update(entity);
                //				Session["Message"] = returnResponse.message;
                //				Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private bool SaveFiles(IReadOnlyList<IFormFile> files, ref MeetingVM entity, FileType fileType, out string error)
        {
            foreach (var file in files)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "Meeting", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                var entityFile = new MeetingFileVM
                {
                    FileName = file.FileName,
                    FileType = fileType,
                    FileNameUrl = fileName,
                };

                entity?.MeetingFiles?.Add(entityFile);
            }

            error = string.Empty;
            return true;
        }

        public ActionResult GetMeetingMemberById(long id)
        {
            var result = _MeetingMemberService.GetById(id);
            if (result.entity == null)
            {
                return Json(new MeetingMemberVM(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }




        //DataTable Get List using server site Pagination
        //[HttpPost]
        public ActionResult GetMeetingListByPagination(JqueryDatatableParam param)
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

            var filter = AuthLocationHelper.GetFilterFromSession<MeetingFilterVM>(HttpContext);
            filter.iDisplayStart = param.iDisplayStart;
            filter.iDisplayLength = param.iDisplayLength;
            filter.sSearch = param.sSearch;


            (ExecutionState executionState, PaginationResutlVM<MeetingVM> entity, string message) returnResponse = _MeetingService.GetMeetingByFilter(filter);

            //Extra Filter
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
            ViewBag.MeetingDate = string.Empty;
            ViewBag.MeetingTypeId = new SelectList(_MeetingTypeService.List().entity ?? new List<MeetingTypeVM>(), "Id", "Name");


            foreach (var item in returnResponse.entity.aaData)
            {
                item.Difference = Convert.ToString(Math.Abs((item.EndTime - item.StartTime).TotalMinutes));
                item.DifferenceRedable = Convert.ToString(Convert.ToDecimal(item.Difference) >= 60 ? $"{(Math.Ceiling(Convert.ToDecimal(item.Difference) / 60))} hour" : $"{item.Difference} minute");
            }

            return Json(new
            {
                param.sEcho,
                iTotalRecords = returnResponse.entity.iTotalRecords,
                iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
                aaData = returnResponse.entity.aaData
            }, SerializerOption.Default);

            //return View(returnResponse.entity);
        }



        [HttpPost]
        public ActionResult IndexFilterMeetingListByPagination(MeetingFilterVM filter)
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

            (ExecutionState executionState, PaginationResutlVM<MeetingVM> entity, string message) returnResponse = _MeetingService.GetMeetingByFilter(filter);

            //Extra Filter
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);
            ViewBag.MeetingDate = filter.MeetingDate;
            ViewBag.MeetingTypeId = new SelectList(_MeetingTypeService.List().entity ?? new List<MeetingTypeVM>(), "Id", "Name", filter.MeetingTypeId);

            foreach (var item in returnResponse.entity.aaData)
            {
                item.Difference = Convert.ToString(Math.Abs((item.EndTime - item.StartTime).TotalMinutes));
                item.DifferenceRedable = Convert.ToString(Convert.ToDecimal(item.Difference) >= 60 ? $"{(Math.Ceiling(Convert.ToDecimal(item.Difference) / 60))} hour" : $"{item.Difference} minute");
            }


            return Json(new
            {
                filter.sEcho,
                iTotalRecords = returnResponse.entity.iTotalRecords,
                iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
                aaData = returnResponse.entity.aaData
            }, SerializerOption.Default);

            // return View("Index", returnResponse.entity.aaData);

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

}
