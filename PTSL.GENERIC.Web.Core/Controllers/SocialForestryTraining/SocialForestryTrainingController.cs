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
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Services.Implementation.Capacity;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Controllers.SocialForestryTraining
{
    [SessionAuthorize]
    public class SocialForestryTrainingController : Controller
    {
        private readonly ISocialForestryTrainingService _SocialForestryTrainingService;
        private readonly ISocialForestryTrainingFileService _SocialForestryTrainingFileService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly IEthnicityService _EthnicityService;
        private readonly IDivisionService _DivisionService;
        private readonly ITrainingOrganizerForTrainingService _TrainingOrganizerForTrainingService;
        private readonly ISocialForestryTrainingMemberService _SocialForestryTrainingMemberService;
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


        public SocialForestryTrainingController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _SocialForestryTrainingService = new SocialForestryTrainingService(httpHelper);
            _SocialForestryTrainingFileService = new SocialForestryTrainingFileService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _EthnicityService = new EthnicityService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
            _SocialForestryTrainingMemberService = new SocialForestryTrainingMemberService(httpHelper);
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
        }

        public ActionResult Index()
        {
            ViewBag.FinancialYearForTrainingId = new SelectList(_financialYearForTrainingService.List().entity ?? new List<FinancialYearForTrainingVM>(), "Id", "Name");
            ViewBag.EventTypeForTrainingId = new SelectList(_eventTypeForTrainingService.List().entity ?? new List<EventTypeForTrainingVM>(), "Id", "Name");

            (ExecutionState executionState, List<SocialForestryTrainingVM> entity, string message) returnResponse = _SocialForestryTrainingService.List();
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult IndexFilter(SocialForestryTrainingFilterVM filter)
        {
            ViewBag.FinancialYearForTrainingId = new SelectList(_financialYearForTrainingService.List().entity ?? new List<FinancialYearForTrainingVM>(), "Id", "Name", filter.FinancialYearForTrainingId);
            ViewBag.EventTypeForTrainingId = new SelectList(_eventTypeForTrainingService.List().entity ?? new List<EventTypeForTrainingVM>(), "Id", "Name", filter.EventTypeForTrainingId);

            ViewBag.StartDate = filter.StartDate;
            ViewBag.EndDate = filter.EndDate;

            (ExecutionState executionState, List<SocialForestryTrainingVM> entity, string message) returnResponse = _SocialForestryTrainingService.GetByFilterVM(filter);

            return View("Index", returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, SocialForestryTrainingVM entity, string message) returnResponse = _SocialForestryTrainingService.GetById(id);
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

            var entity = new SocialForestryTrainingVM();

            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.FinancialYearForTrainingId = new SelectList(_financialYearForTrainingService.List().entity ?? new List<FinancialYearForTrainingVM>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(SocialForestryTrainingVM entity)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;

                entity.SocialForestryTrainingParticipentsMaps = JsonConvert.DeserializeObject<List<SocialForestryTrainingParticipentsMapVM>>(entity.SocialForestryTrainingParticipentsMapsJSON);

                var imageFiles = HttpContext.Request.Form.Files.GetFiles("SocialForestryTrainingImageFiles[]");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("SocialForestryTrainingDocumentFiles[]");

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

                (ExecutionState executionState, SocialForestryTrainingVM entity, string message) returnResponse = _SocialForestryTrainingService.Create(entity);

                if (returnResponse.executionState.ToString() == "Created")
                {
                    HttpContext.Session.SetString("Message", "Social forestry training has been created successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return Json(
                        new { Success = true, Message = "Social forestry training has been created successfully", RedirectUrl = "/SocialForestryTraining/Index" },
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

            (ExecutionState executionState, SocialForestryTrainingVM entity, string message) returnResponse = _SocialForestryTrainingService.GetById(id);

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


            ViewBag.TrainingOrganizerForTrainingId = new SelectList(_TrainingOrganizerForTrainingService.List().entity ?? new List<TrainingOrganizerForTrainingVM>(), "Id", "Name", returnResponse.entity?.TrainingOrganizerForTrainingId);
            ViewBag.EventTypeForTrainingId = new SelectList(_eventTypeForTrainingService.List().entity ?? new List<EventTypeForTrainingVM>(), "Id", "Name", returnResponse.entity?.EventTypeForTrainingId);
            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.FinancialYearForTrainingId = new SelectList(_financialYearForTrainingService.List().entity ?? new List<FinancialYearForTrainingVM>(), "Id", "Name", returnResponse.entity?.FinancialYearForTrainingId);

            return View(returnResponse.entity);
        }


        [HttpPost]
        public ActionResult Edit(SocialForestryTrainingVM entity)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;

                    entity.SocialForestryTrainingParticipentsMaps = JsonConvert.DeserializeObject<List<SocialForestryTrainingParticipentsMapVM>>(entity.SocialForestryTrainingParticipentsMapsJSON);

                    var imageFiles = HttpContext.Request.Form.Files.GetFiles("SocialForestryTrainingImageFiles[]");
                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("SocialForestryTrainingDocumentFiles[]");

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

                    (ExecutionState executionState, SocialForestryTrainingVM entity, string message) returnResponse = _SocialForestryTrainingService.Update(entity);

                    //                    Session["Message"] = returnResponse.message;
                    //                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() == "Updated")
                    {
                        HttpContext.Session.SetString("Message", "Social Forestry Training has been updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Social Forestry Training updated successfully", RedirectUrl = "/SocialForestryTraining/Index" },
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







        //        public ActionResult GetByFilter(int? FinancialYearForTrainingId)
        //        {
        //            if (FinancialYearForTrainingId == null || FinancialYearForTrainingId < 1)
        //            {
        //                return Json(
        //                    new { Success = false, Message = "Invalid financial year Id" },
        //                    SerializerOption.Default);
        //            }

        //            (ExecutionState executionState, List<SocialForestryTrainingVM> entity, string message) returnResponse = _SocialForestryTrainingService.GetByFilter(FinancialYearForTrainingId);

        //            return Json(
        //                new { Success = true, Message = "Data found", Data = returnResponse.entity },
        //                SerializerOption.Default);
        //        }

        //       

        public JsonResult Delete(int id)
        {
            var result = _SocialForestryTrainingService.SoftDelete(id);
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
        public ActionResult Delete(int id, SocialForestryTrainingVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, SocialForestryTrainingVM entity, string message) returnResponse = _SocialForestryTrainingService.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult DeleteParticipant(long SocialForestryTrainingParticipentsMapId)
        {
            try
            {
                (ExecutionState executionState, bool isDeleted, string message) returnResponse = _SocialForestryTrainingService.DeleteParticipant(SocialForestryTrainingParticipentsMapId);
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
            var result = _SocialForestryTrainingFileService.SoftDelete(id);
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

        private bool SaveFiles(IReadOnlyList<IFormFile> files, ref SocialForestryTrainingVM entity, FileType fileType, out string error)
        {
            foreach (var file in files)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "SocialForestryTraining", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                var entityFile = new SocialForestryTrainingFileVM
                {
                    FileName = file.FileName,
                    FileType = fileType,
                    FileNameUrl = fileName,
                };

                entity?.SocialForestryTrainingFiles?.Add(entityFile);
            }

            error = string.Empty;
            return true;
        }
    }
}
