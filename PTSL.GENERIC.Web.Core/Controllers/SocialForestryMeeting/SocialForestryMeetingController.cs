using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Services.Implementation.Capacity;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Controllers.SocialForestryMeeting
{
    [SessionAuthorize]
    public class SocialForestryMeetingController : Controller
    {
        private readonly ISocialForestryMeetingService _SocialForestryMeetingService;
        private readonly ISocialForestryMeetingFileService _SocialForestryMeetingFileService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly IEthnicityService _EthnicityService;
        private readonly IDivisionService _DivisionService;
        private readonly ITrainingOrganizerForTrainingService _TrainingOrganizerForTrainingService;
        private readonly ISocialForestryMeetingMemberService _SocialForestryMeetingMemberService;
        private readonly IEventTypeForTrainingService _eventTypeForTrainingService;
        private readonly IFinancialYearForTrainingService _financialYearForTrainingService;
        private readonly FileHelper _fileHelper;

        private readonly IForestFcvVcfService _ForestFcvVcfService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;

        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        //New
        private readonly INgoService _NgoService;
        private readonly IMeetingTypeForSocialForestryMeetingService _MeetingTypeForSocialForestryMeetingService;


        public SocialForestryMeetingController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _SocialForestryMeetingService = new SocialForestryMeetingService(httpHelper);
            _SocialForestryMeetingFileService = new SocialForestryMeetingFileService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _EthnicityService = new EthnicityService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
            _SocialForestryMeetingMemberService = new SocialForestryMeetingMemberService(httpHelper);
            _TrainingOrganizerForTrainingService = new TrainingOrganizerForTrainingService(httpHelper);
            _eventTypeForTrainingService = new EventTypeForTrainingService(httpHelper);
            _financialYearForTrainingService = new FinancialYearForTrainingService(httpHelper);
            _fileHelper = fileHelper;

            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);

            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

            //New
            _NgoService = new NgoService(httpHelper);
            _MeetingTypeForSocialForestryMeetingService = new MeetingTypeForSocialForestryMeetingService(httpHelper);
            
        }

        public ActionResult Index()
        {
            ViewBag.FinancialYearForTrainingId = new SelectList(_financialYearForTrainingService.List().entity ?? new List<FinancialYearForTrainingVM>(), "Id", "Name");
            ViewBag.EventTypeForTrainingId = new SelectList(_eventTypeForTrainingService.List().entity ?? new List<EventTypeForTrainingVM>(), "Id", "Name");

            (ExecutionState executionState, List<SocialForestryMeetingVM> entity, string message) returnResponse = _SocialForestryMeetingService.List();
            return View(returnResponse.entity);
        }

        //[HttpPost]
        //public ActionResult IndexFilter(SocialForestryMeetingFilterVM filter)
        //{
        //    ViewBag.FinancialYearForTrainingId = new SelectList(_financialYearForTrainingService.List().entity ?? new List<FinancialYearForTrainingVM>(), "Id", "Name", filter.FinancialYearForTrainingId);
        //    ViewBag.EventTypeForTrainingId = new SelectList(_eventTypeForTrainingService.List().entity ?? new List<EventTypeForTrainingVM>(), "Id", "Name", filter.EventTypeForTrainingId);

        //    ViewBag.StartDate = filter.StartDate;
        //    ViewBag.EndDate = filter.EndDate;

        //    (ExecutionState executionState, List<SocialForestryMeetingVM> entity, string message) returnResponse = _SocialForestryMeetingService.GetByFilterVM(filter);

        //    return View("Index", returnResponse.entity);
        //}

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, SocialForestryMeetingVM entity, string message) returnResponse = _SocialForestryMeetingService.GetById(id);
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

            var entity = new SocialForestryMeetingVM();

            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.FinancialYearForTrainingId = new SelectList(_financialYearForTrainingService.List().entity ?? new List<FinancialYearForTrainingVM>(), "Id", "Name");


            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
            ViewBag.MeetingTypeForSocialForestryMeetingId = new SelectList(_MeetingTypeForSocialForestryMeetingService.List().entity ?? new List<MeetingTypeForSocialForestryMeetingVM>(), "Id", "Name");


            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(SocialForestryMeetingVM entity)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                entity.SocialForestryMeetingParticipentsMaps = JsonConvert.DeserializeObject<List<SocialForestryMeetingParticipentsMapVM>>(entity.SocialForestryMeetingParticipentsMapsJSON);

                var imageFiles = HttpContext.Request.Form.Files.GetFiles("SocialForestryMeetingImageFiles[]");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("SocialForestryMeetingDocumentFiles[]");

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

                (ExecutionState executionState, SocialForestryMeetingVM entity, string message) returnResponse = _SocialForestryMeetingService.Create(entity);

                if (returnResponse.executionState.ToString() == "Created")
                {
                    HttpContext.Session.SetString("Message", "Social forestry meeting has been created successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return Json(
                        new { Success = true, Message = "Social forestry meeting has been created successfully", RedirectUrl = "/SocialForestryMeeting/Index" },
                        SerializerOption.Default);
                }
                return Json(
                    new { Success = false, Message = returnResponse.message },
                    SerializerOption.Default);
                //}
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

            (ExecutionState executionState, SocialForestryMeetingVM entity, string message) returnResponse = _SocialForestryMeetingService.GetById(id);

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

             returnResponse.entity.ForestCircleId,
             returnResponse.entity.ForestDivisionId,
             returnResponse.entity.ForestRangeId,
             returnResponse.entity.ForestBeatId,
             0,
             returnResponse.entity.DivisionId,
             returnResponse.entity.DistrictId,
             returnResponse.entity.UpazillaId,
             returnResponse.entity.UnionId
         );

            //ViewBag.TrainingOrganizerForTrainingId = new SelectList(_TrainingOrganizerForTrainingService.List().entity ?? new List<TrainingOrganizerForTrainingVM>(), "Id", "Name", returnResponse.entity?.TrainingOrganizerForTrainingId);
            //ViewBag.EventTypeForTrainingId = new SelectList(_eventTypeForTrainingService.List().entity ?? new List<EventTypeForTrainingVM>(), "Id", "Name", returnResponse.entity?.EventTypeForTrainingId);
            //ViewBag.FinancialYearForTrainingId = new SelectList(_financialYearForTrainingService.List().entity ?? new List<FinancialYearForTrainingVM>(), "Id", "Name", returnResponse.entity?.FinancialYearForTrainingId);


            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", returnResponse.entity?.NgoId);
            ViewBag.MeetingTypeForSocialForestryMeetingId = new SelectList(_MeetingTypeForSocialForestryMeetingService.List().entity ?? new List<MeetingTypeForSocialForestryMeetingVM>(), "Id", "Name", returnResponse.entity?.MeetingTypeForSocialForestryMeetingId);


            return View(returnResponse.entity);
        }




        [HttpPost]
        public ActionResult Edit(SocialForestryMeetingVM entity)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;

                entity.SocialForestryMeetingParticipentsMaps = JsonConvert.DeserializeObject<List<SocialForestryMeetingParticipentsMapVM>>(entity.SocialForestryMeetingParticipentsMapsJSON);

                var imageFiles = HttpContext.Request.Form.Files.GetFiles("SocialForestryMeetingImageFiles[]");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("SocialForestryMeetingDocumentFiles[]");

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

                (ExecutionState executionState, SocialForestryMeetingVM entity, string message) returnResponse = _SocialForestryMeetingService.Update(entity);

                //                    Session["Message"] = returnResponse.message;
                //                    Session["executionState"] = returnResponse.executionState;
                if (returnResponse.executionState.ToString() == "Updated")
                {
                    HttpContext.Session.SetString("Message", "Social Forestry Meeting has been updated successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return Json(
                        new { Success = true, Message = "Social Forestry Meeting updated successfully", RedirectUrl = "/SocialForestryMeeting/Index" },
                        SerializerOption.Default);
                }
                return Json(
                    new { Success = false, Message = returnResponse.message },
                    SerializerOption.Default);
                //}
                //else
                // {
                // return Json(
                //     new { Success = false, Message = "Invalid form" },
                //     SerializerOption.Default);
                //}
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
            var result = _SocialForestryMeetingService.SoftDelete(id);
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
        public ActionResult Delete(int id, SocialForestryMeetingVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, SocialForestryMeetingVM entity, string message) returnResponse = _SocialForestryMeetingService.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult DeleteParticipant(long SocialForestryMeetingParticipentsMapId)
        {
            try
            {
                (ExecutionState executionState, bool isDeleted, string message) returnResponse = _SocialForestryMeetingService.DeleteParticipant(SocialForestryMeetingParticipentsMapId);
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
            var result = _SocialForestryMeetingFileService.SoftDelete(id);
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

        private bool SaveFiles(IReadOnlyList<IFormFile> files, ref SocialForestryMeetingVM entity, FileType fileType, out string error)
        {
            foreach (var file in files)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "SocialForestryMeeting", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                var entityFile = new SocialForestryMeetingFileVM
                {
                    FileName = file.FileName,
                    FileType = fileType,
                    FileNameUrl = fileName,
                };

                entity?.SocialForestryMeetingFiles?.Add(entityFile);
            }

            error = string.Empty;
            return true;
        }
    }
}
