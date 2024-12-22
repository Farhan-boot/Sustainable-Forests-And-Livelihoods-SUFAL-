using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Capacity;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.Capacity
{
    [SessionAuthorize]
    public class CommunityTrainingController : Controller
    {
        private readonly ICommunityTrainingService _CommunityTrainingService;
        private readonly ICommunityTrainingFileService _CommunityTrainingFileService;
        private readonly ICommunityTrainingMemberService _CommunityTrainingMemberService;

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
        private readonly ITrainingOrganizerService _TrainingOrganizerService;
        private readonly IEventTypeService _EventTypeService;
        private readonly FileHelper _fileHelper;

        public CommunityTrainingController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _CommunityTrainingService = new CommunityTrainingService(httpHelper);
            _CommunityTrainingFileService = new CommunityTrainingFileService(httpHelper);
            _CommunityTrainingMemberService = new CommunityTrainingMemberService(httpHelper);
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
            _TrainingOrganizerService = new TrainingOrganizerService(httpHelper);
            _EventTypeService = new EventTypeService(httpHelper);
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

            var filter = AuthLocationHelper.GetFilterFromSession<CommunityTrainingFilterVM>(HttpContext, 50);
            //(ExecutionState executionState, List<CommunityTrainingVM> entity, string message) returnResponse = _CommunityTrainingService.GetTrainingByFilter(filter);

            ViewBag.TrainingOrganizerId = new SelectList(_TrainingOrganizerService.List().entity ?? new List<TrainingOrganizerVM>(), "Id", "Name");
            ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name");
            ViewBag.StartDate = string.Empty;
            ViewBag.EndDate = string.Empty;

            //returnResponse.entity
            return View(new List<CommunityTrainingVM>());
        }

        [HttpPost]
        public ActionResult IndexFilter(CommunityTrainingFilterVM filter)
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

            var result = _CommunityTrainingService.GetTrainingByFilter(filter);

            ViewBag.TrainingOrganizerId = new SelectList(_TrainingOrganizerService.List().entity ?? new List<TrainingOrganizerVM>(), "Id", "Name", filter.NgoId);
            ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name", filter.EventTypeId);
            ViewBag.StartDate = filter.StartDate;
            ViewBag.EndDate = filter.EndDate;

            return View("Index", result.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, CommunityTrainingVM entity, string message) returnResponse = _CommunityTrainingService.GetById(id);
            return View(returnResponse.entity);
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

            var entity = new CommunityTrainingVM();

            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(CommunityTrainingVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;

                    entity.CommunityTrainingParticipentsMaps = JsonConvert.DeserializeObject<List<CommunityTrainingParticipentsMapVM>>(entity.CommunityTrainingParticipentsMapsJSON);

                    var imageFiles = HttpContext.Request.Form.Files.GetFiles("CommunityTrainingImageFiles[]");
                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("CommunityTrainingDocumentFiles[]");

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

                    (ExecutionState executionState, CommunityTrainingVM entity, string message) returnResponse = _CommunityTrainingService.Create(entity);

                    if (returnResponse.executionState.ToString() == "Created")
                    {
                        HttpContext.Session.SetString("Message", "Community training has been created");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Community training has been created", RedirectUrl = "/CommunityTraining/Index" },
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, CommunityTrainingVM entity, string message) result = _CommunityTrainingService.GetById(id);

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

            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.TrainingOrganizerId = new SelectList(_TrainingOrganizerService.List().entity ?? new List<TrainingOrganizerVM>(), "Id", "Name", result.entity?.TrainingOrganizerId);
            ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name", result.entity?.EventTypeId);

            return View(result.entity ?? new CommunityTrainingVM());
        }

        [HttpPost]
        public ActionResult Edit(CommunityTrainingVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;

                entity.CommunityTrainingParticipentsMaps = JsonConvert.DeserializeObject<List<CommunityTrainingParticipentsMapVM>>(entity.CommunityTrainingParticipentsMapsJSON);

                var imageFiles = HttpContext.Request.Form.Files.GetFiles("CommunityTrainingImageFiles[]");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("CommunityTrainingDocumentFiles[]");

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

                (ExecutionState executionState, CommunityTrainingVM entity, string message) returnResponse = _CommunityTrainingService.Update(entity);

                if (returnResponse.executionState.ToString() == "Updated")
                {
                    HttpContext.Session.SetString("Message", "Community training information has been updated");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return Json(
                        new { Success = true, Message = "Community training information has been updated", RedirectUrl = "/CommunityTraining/Index" },
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

        public JsonResult Delete(int id)
        {
            var result = _CommunityTrainingService.SoftDelete(id);
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
        public ActionResult Delete(int id, CommunityTrainingVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, CommunityTrainingVM entity, string message) returnResponse = _CommunityTrainingService.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteParticipant(long communityTrainingParticipentsMapId)
        {
            try
            {
                (ExecutionState executionState, bool isDeleted, string message) returnResponse = _CommunityTrainingService.DeleteParticipant(communityTrainingParticipentsMapId);

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

        [HttpPost]
        public ActionResult UpdateOtherMember(CommunityTrainingMemberVM member)
        {
            try
            {
                (ExecutionState executionState, CommunityTrainingMemberVM entity, string message) returnResponse = _CommunityTrainingMemberService.Update(member);

                if (returnResponse.executionState == ExecutionState.Updated)
                {
                    return Json(
                        new { Success = true, Message = "Successfully updated.", Data = returnResponse.entity },
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
            var result = _CommunityTrainingFileService.SoftDelete(id);
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

        private bool SaveFiles(IReadOnlyList<IFormFile> files, ref CommunityTrainingVM entity, FileType fileType, out string error)
        {
            foreach (var file in files)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "CommunityTraining", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                var entityFile = new CommunityTrainingFileVM
                {
                    FileName = file.FileName,
                    FileType = fileType,
                    FileNameUrl = fileName,
                };

                entity?.CommunityTrainingFiles?.Add(entityFile);
            }

            error = string.Empty;
            return true;
        }




        //DataTable Get List using server site Pagination
        //[HttpPost]
        public ActionResult GetCommunityTrainingListByPagination(JqueryDatatableParam param)
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

            var filter = AuthLocationHelper.GetFilterFromSession<CommunityTrainingFilterVM>(HttpContext);
            filter.iDisplayStart = param.iDisplayStart;
            filter.iDisplayLength = param.iDisplayLength;
            filter.sSearch = param.sSearch;

            (ExecutionState executionState, PaginationResutlVM<CommunityTrainingVM> entity, string message) returnResponse = _CommunityTrainingService.GetTrainingByFilter(filter);

            ViewBag.TrainingOrganizerId = new SelectList(_TrainingOrganizerService.List().entity ?? new List<TrainingOrganizerVM>(), "Id", "Name");
            ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name");
            ViewBag.StartDate = string.Empty;
            ViewBag.EndDate = string.Empty;

           

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
        public ActionResult IndexFilterCommunityTrainingListByPagination(CommunityTrainingFilterVM filter)
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


            var result = _CommunityTrainingService.GetTrainingByFilter(filter);

            ViewBag.TrainingOrganizerId = new SelectList(_TrainingOrganizerService.List().entity ?? new List<TrainingOrganizerVM>(), "Id", "Name", filter.NgoId);
            ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name", filter.EventTypeId);
            ViewBag.StartDate = filter.StartDate;
            ViewBag.EndDate = filter.EndDate;

            
            return Json(new
            {
                filter.sEcho,
                iTotalRecords = result.entity.iTotalRecords,
                iTotalDisplayRecords = result.entity.iTotalDisplayRecords,
                aaData = result.entity.aaData 
            }, SerializerOption.Default);

            // return View("Index", result.entity);
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
