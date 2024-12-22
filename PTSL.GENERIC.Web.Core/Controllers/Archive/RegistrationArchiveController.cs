using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Archive;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.MeetingManagement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Archive;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.MeetingManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.Archive;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Services.Implementation.MeetingManagement;

namespace PTSL.GENERIC.Web.Controllers.Archive
{
    [SessionAuthorize]
    public class RegistrationArchiveController : Controller
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
        private readonly IRegistrationArchiveService _RegistrationArchiveService;
        private readonly IRegistrationArchiveFileService _RegistrationArchiveFileService;

        private readonly IEthnicityService _EthnicityService;
        private readonly FileHelper _fileHelper;

        public RegistrationArchiveController(HttpHelper httpHelper, FileHelper fileHelper)
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
            _RegistrationArchiveService = new RegistrationArchiveService(httpHelper);
            _RegistrationArchiveFileService = new RegistrationArchiveFileService(httpHelper);

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

            (ExecutionState executionState, List<RegistrationArchiveVM> entity, string message) returnResponse = _RegistrationArchiveService.List();

            return View(returnResponse.entity.OrderByDescending(x=>x.Id));
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

            (ExecutionState executionState, List<RegistrationArchiveVM> entity, string message) returnResponse = _RegistrationArchiveService.GetRegistrationArchiveByFilter(filter);


            return View("Index", returnResponse.entity);
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
            (ExecutionState executionState, RegistrationArchiveVM entity, string message) returnResponse = _RegistrationArchiveService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            RegistrationArchiveVM entity = new RegistrationArchiveVM();

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

         

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(RegistrationArchiveVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;

                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("MeetingDocumentFiles[]");


                    if (documentFiles.Count() == 0)
                    {
                        HttpContext.Session.SetString("Message", "Please Select Archive File");
                        HttpContext.Session.SetString("executionState", "Please Select Archive File");

                        return Json(
                            new { Success = false, Message = "Please Select Archive File" },
                            SerializerOption.Default);
                    }



                    // Save document files
                    if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
                    {
                        return Json(
                            new { Success = false, Message = documentFileError },
                            SerializerOption.Default);
                    }

                    (ExecutionState executionState, RegistrationArchiveVM entity, string message) returnResponse = _RegistrationArchiveService.Create(entity);

                    if (returnResponse.executionState.ToString() == "Created")
                    {
                        HttpContext.Session.SetString("Message", "Archive information has been created");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "New archive has been created", RedirectUrl = "/RegistrationArchive/Index" },
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
            (ExecutionState executionState, RegistrationArchiveVM entity, string message) result = _RegistrationArchiveService.GetById(id);

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

          
            return View(result.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, RegistrationArchiveVM entity)
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

                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("MeetingDocumentFiles[]");

                    // Save document files
                    if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
                    {
                        return Json(
                            new { Success = false, Message = documentFileError },
                            SerializerOption.Default);
                    }

                    (ExecutionState executionState, RegistrationArchiveVM entity, string message) returnResponse = _RegistrationArchiveService.Update(entity);
                    if (returnResponse.executionState.ToString() == "Updated")
                    {
                        HttpContext.Session.SetString("Message", "Registration Archive information has been updated");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Registration Archive information has been updated", RedirectUrl = "/RegistrationArchive/Index" },
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


        //[HttpGet]
        //public ActionResult DeleteParticipant(long mapId)
        //{
        //    try
        //    {
        //        (ExecutionState executionState, bool isDeleted, string message) returnResponse = _MeetingService.DeleteParticipant(mapId);

        //        if (returnResponse.isDeleted)
        //        {
        //            return Json(
        //                new { Success = true, Message = "Successfully deleted." },
        //                SerializerOption.Default);
        //        }

        //        return Json(
        //            new { Success = false, Message = returnResponse.message },
        //            SerializerOption.Default);
        //    }
        //    catch
        //    {
        //        return Json(
        //            new { Success = false, Message = "Unknown error occurred." },
        //            SerializerOption.Default);
        //    }
        //}

        public ActionResult DeleteImageOrDocument(long id)
        {
            var result = _RegistrationArchiveFileService.SoftDelete(id);
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
            var result = _RegistrationArchiveService.SoftDelete(id);
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


        //[RequireAuthRole(Roles = RoleNames.GENERAL_DELETE_PERMISSION, RedirectTo = "Meeting/Index")]
        //[HttpPost]
        //public ActionResult Delete(int id, MeetingVM entity)
        //{
        //    try
        //    {
        //        if (id != entity.Id)
        //        {
        //            return RedirectToAction(nameof(CategoryController.Index), "Category");
        //        }
        //        entity.IsDeleted = true;
        //        entity.UpdatedAt = DateTime.Now;
        //        (ExecutionState executionState, MeetingVM entity, string message) returnResponse = _MeetingService.Update(entity);
        //        //				Session["Message"] = returnResponse.message;
        //        //				Session["executionState"] = returnResponse.executionState;
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        private bool SaveFiles(IReadOnlyList<IFormFile> files, ref RegistrationArchiveVM entity, FileType fileType, out string error)
        {
            foreach (var file in files)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFileAll(file, fileType, "RegistrationArchive", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                var entityFile = new RegistrationArchiveFileVM
                {
                    FileName = file.FileName,
                    DocumentUrl = fileName,
                };

                entity?.RegistrationArchiveFiles?.Add(entityFile);
            }

            error = string.Empty;
            return true;
        }

    }
}
