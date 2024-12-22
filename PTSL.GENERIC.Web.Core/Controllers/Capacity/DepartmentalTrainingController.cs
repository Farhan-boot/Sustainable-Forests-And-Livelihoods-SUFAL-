using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Capacity;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class DepartmentalTrainingController : Controller
    {
        private readonly IDepartmentalTrainingService _DepartmentalTrainingService;
        private readonly IDepartmentalTrainingFileService _DepartmentalTrainingFileService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly IEthnicityService _EthnicityService;
        private readonly IDivisionService _DivisionService;
        private readonly ITrainingOrganizerService _TrainingOrganizerService;
        private readonly IDepartmentalTrainingMemberService _DepartmentalTrainingMemberService;
        private readonly IEventTypeService _eventTypeService;
        private readonly IFinancialYearService _financialYearService;
        private readonly FileHelper _fileHelper;

        public DepartmentalTrainingController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _DepartmentalTrainingService = new DepartmentalTrainingService(httpHelper);
            _DepartmentalTrainingFileService = new DepartmentalTrainingFileService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _EthnicityService = new EthnicityService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
            _DepartmentalTrainingMemberService = new DepartmentalTrainingMemberService(httpHelper);
            _TrainingOrganizerService = new TrainingOrganizerService(httpHelper);
            _eventTypeService = new EventTypeService(httpHelper);
            _financialYearService = new FinancialYearService(httpHelper);
            _fileHelper = fileHelper;
        }

        public ActionResult Index()
        {
            ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
            ViewBag.EventTypeId = new SelectList(_eventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name");

            (ExecutionState executionState, List<DepartmentalTrainingVM> entity, string message) returnResponse = _DepartmentalTrainingService.List();
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult IndexFilter(DepartmentalTrainingFilterVM filter)
        {
            ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name", filter.FinancialYearId);
            ViewBag.EventTypeId = new SelectList(_eventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name", filter.EventTypeId);

            ViewBag.StartDate = filter.StartDate;
            ViewBag.EndDate = filter.EndDate;

            (ExecutionState executionState, PaginationResutlVM<DepartmentalTrainingVM> entity, string message) returnResponse = _DepartmentalTrainingService.GetByFilterVM(filter);

            return View("Index", returnResponse.entity.aaData);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, DepartmentalTrainingVM entity, string message) returnResponse = _DepartmentalTrainingService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new DepartmentalTrainingVM();

            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(DepartmentalTrainingVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;

                    entity.DepartmentalTrainingParticipentsMaps = JsonConvert.DeserializeObject<List<DepartmentalTrainingParticipentsMapVM>>(entity.DepartmentalTrainingParticipentsMapsJSON);

                    var imageFiles = HttpContext.Request.Form.Files.GetFiles("DepartmentalTrainingImageFiles[]");
                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("DepartmentalTrainingDocumentFiles[]");

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

                    (ExecutionState executionState, DepartmentalTrainingVM entity, string message) returnResponse = _DepartmentalTrainingService.Create(entity);

                    if (returnResponse.executionState.ToString() == "Created")
                    {
                        HttpContext.Session.SetString("Message", "Departmental training has been created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Departmental training has been created successfully", RedirectUrl = "/DepartmentalTraining/Index" },
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

            (ExecutionState executionState, DepartmentalTrainingVM entity, string message) returnResponse = _DepartmentalTrainingService.GetById(id);

            ViewBag.TrainingOrganizerId = new SelectList(_TrainingOrganizerService.List().entity ?? new List<TrainingOrganizerVM>(), "Id", "Name", returnResponse.entity?.TrainingOrganizerId);
            ViewBag.EventTypeId = new SelectList(_eventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name", returnResponse.entity?.EventTypeId);
            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name", returnResponse.entity?.FinancialYearId);

            return View(returnResponse.entity);
        }

        public ActionResult GetByFilter(int? financialYearId)
        {
            if (financialYearId == null || financialYearId < 1)
            {
                return Json(
                    new { Success = false, Message = "Invalid financial year Id" },
                    SerializerOption.Default);
            }

            (ExecutionState executionState, List<DepartmentalTrainingVM> entity, string message) returnResponse = _DepartmentalTrainingService.GetByFilter(financialYearId);

            return Json(
                new { Success = true, Message = "Data found", Data = returnResponse.entity },
                SerializerOption.Default);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentalTrainingVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;

                    entity.DepartmentalTrainingParticipentsMaps = JsonConvert.DeserializeObject<List<DepartmentalTrainingParticipentsMapVM>>(entity.DepartmentalTrainingParticipentsMapsJSON);

                    var imageFiles = HttpContext.Request.Form.Files.GetFiles("DepartmentalTrainingImageFiles[]");
                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("DepartmentalTrainingDocumentFiles[]");

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

                    (ExecutionState executionState, DepartmentalTrainingVM entity, string message) returnResponse = _DepartmentalTrainingService.Update(entity);

//                    Session["Message"] = returnResponse.message;
//                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() == "Updated")
                    {
                        HttpContext.Session.SetString("Message", "Departmental training has been updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Departmental training updated successfully", RedirectUrl = "/DepartmentalTraining/Index" },
                            SerializerOption.Default);
                    }
                    return Json(
                        new { Success = false, Message = returnResponse.message },
                        SerializerOption.Default);
                }
                else
                {
                    return Json(
                        new { Success = false, Message = "Invalid form" },
                        SerializerOption.Default);
                }
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
            var result = _DepartmentalTrainingService.SoftDelete(id);
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
        public ActionResult Delete(int id, DepartmentalTrainingVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, DepartmentalTrainingVM entity, string message) returnResponse = _DepartmentalTrainingService.Update(entity);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteParticipant(long DepartmentalTrainingParticipentsMapId)
        {
            try
            {
                (ExecutionState executionState, bool isDeleted, string message) returnResponse = _DepartmentalTrainingService.DeleteParticipant(DepartmentalTrainingParticipentsMapId);

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
            var result = _DepartmentalTrainingFileService.SoftDelete(id);
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

        private bool SaveFiles(IReadOnlyList<IFormFile> files, ref DepartmentalTrainingVM entity, FileType fileType, out string error)
        {
            foreach (var file in files)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "DepartmentalTraining", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                var entityFile = new DepartmentalTrainingFileVM
                {
                    FileName = file.FileName,
                    FileType = fileType,
                    FileNameUrl = fileName,
                };

                entity?.DepartmentalTrainingFiles?.Add(entityFile);
            }

            error = string.Empty;
            return true;
        }



        //DataTable Get List using server site Pagination
        //[HttpPost]
        public ActionResult GetDepartmentalTrainingListByPagination(JqueryDatatableParam param)
        {
            ViewBag.FinancialYearId = new SelectList(_financialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name", param.FinancialYearId);
            ViewBag.EventTypeId = new SelectList(_eventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name", param.EventTypeId);

            ViewBag.StartDate = param.StartDate;
            ViewBag.EndDate = param.EndDate;

            (ExecutionState executionState, PaginationResutlVM<DepartmentalTrainingVM> entity, string message) returnResponse = _DepartmentalTrainingService.GetByFilterVM(param);

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
        public ActionResult IndexFilterDepartmentalTrainingListByPagination(DepartmentalTrainingFilterVM filter)
        {

            ViewBag.FinancialYearId = filter.FinancialYearId;
            ViewBag.EventTypeId = filter.EventTypeId;

            ViewBag.StartDate = filter.StartDate;
            ViewBag.EndDate = filter.EndDate;

            (ExecutionState executionState, PaginationResutlVM<DepartmentalTrainingVM> entity, string message) returnResponse = _DepartmentalTrainingService.GetByFilterVM(filter);


            return Json(new
            {
                //filter.sEcho,
                iTotalRecords = returnResponse.entity.iTotalRecords,
                iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
                aaData = returnResponse.entity.aaData
            }, SerializerOption.Default);

            // return View("Index", result.entity);
        }





    }

    public class JqueryDatatableParam : DepartmentalTrainingFilterVM
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
