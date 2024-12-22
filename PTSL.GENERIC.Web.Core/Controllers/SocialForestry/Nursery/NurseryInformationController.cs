using System.Security.AccessControl;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry.Nursery
{
    [SessionAuthorize]
    public class NurseryInformationController : Controller
    {
        private readonly INurseryRaisedSeedlingInformationService _nurseryRaisedSeedlingInformationService;
        private readonly INurseryInformationService _nurseryInformationService;
        private readonly INurseryRaisingSectorService _nurseryRaisingSectorService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        private readonly IFinancialYearService _financialYearService;
        private readonly IProjectTypeService _projectTypeService;
        private readonly INurseryTypeService _nurseryTypeService;

        private readonly ISocialForestryDesignationService _socialForestryDesignationService;
        private readonly FileHelper _fileHelper;

        private readonly ICostInformationService _costInformationService;


        public NurseryInformationController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _nurseryRaisedSeedlingInformationService = new NurseryRaisedSeedlingInformationService(httpHelper);
            _nurseryInformationService = new NurseryInformationService(httpHelper);
            _nurseryRaisingSectorService = new NurseryRaisingSectorService(httpHelper);

            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
            _financialYearService = new FinancialYearService(httpHelper);
            _projectTypeService = new ProjectTypeService(httpHelper);
            _nurseryTypeService = new NurseryTypeService(httpHelper);

          
            _socialForestryDesignationService = new SocialForestryDesignationService(httpHelper);
            _fileHelper = fileHelper;

            _costInformationService = new CostInformationService(httpHelper);
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


            //ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();
            //ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
            //ViewBag.DistrictId = new SelectList("");
            //ViewBag.UpazillaId = new SelectList("");
            //ViewBag.UnionId = new SelectList("");

            List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();
            ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();


            (ExecutionState executionState, List<NurseryInformationVM> entity, string message) returnResponse = _nurseryInformationService.List();
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult IndexFilter(NurseryFilterVM filter)
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


            //ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();
            //ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
            //ViewBag.DistrictId = new SelectList("");
            //ViewBag.UpazillaId = new SelectList("");
            //ViewBag.UnionId = new SelectList("");

            List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();
            ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();


            (ExecutionState executionState, List<NurseryInformationVM> entity, string message) returnResponse = _nurseryInformationService.ListByFilter(filter);

            return View("Index", returnResponse.entity);
        }


        public JsonResult List()
        {
            var returnResponse = _nurseryInformationService.List().entity ?? new List<NurseryInformationVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, NurseryInformationVM entity, string message) returnResponse = _nurseryInformationService.GetById(id);
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









            var entity = new NurseryInformationVM();

            List<NurseryRaisingSectorVM>? nurseryRaisingSectorList = _nurseryRaisingSectorService.List().entity?.OrderBy(x => x.Name).ToList();
            List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();

            List<ProjectTypeVM>? projectTypeList = _projectTypeService.List().entity?.OrderBy(x => x.Name).ToList();
            List<NurseryTypeVM>? nurseryTypeList = _nurseryTypeService.List().entity?.OrderBy(x => x.Name).ToList();

            List<SocialForestryDesignationVM>? socialForestryDesignationList = _socialForestryDesignationService.List().entity?.OrderBy(x => x.Name).ToList();

            ViewBag.NurseryRaisingSectorId = nurseryRaisingSectorList ?? new List<NurseryRaisingSectorVM>();
            ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();
            ViewBag.ProjectTypeId = projectTypeList ?? new List<ProjectTypeVM>();
            ViewBag.NurseryTypeId = nurseryTypeList ?? new List<NurseryTypeVM>();

            ///////////////////////////////////////////////////////////////////////////

            //ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();

            //ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name");
            //ViewBag.DistrictId = new SelectList("");
            //ViewBag.UpazillaId = new SelectList("");
            //ViewBag.UnionId = new SelectList("");

            ///////////////////////////////////////////////////////////////////////////
            ViewBag.DesignationId = socialForestryDesignationList ?? new List<SocialForestryDesignationVM>();
            ViewBag.SocialForestryDesignationId = socialForestryDesignationList ?? new List<SocialForestryDesignationVM>();


            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(NurseryInformationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var nurseryRaisingSectorList = _nurseryRaisingSectorService.List().entity?.OrderBy(x => x.Name).ToList();
                    var nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();

                    var projectTypeList = _projectTypeService.List().entity?.OrderBy(x => x.Name).ToList();
                    var nurseryTypeList = _nurseryTypeService.List().entity?.OrderBy(x => x.Name).ToList();

                    ViewBag.NurseryRaisingSectorId = new SelectList(nurseryRaisingSectorList ?? new List<NurseryRaisingSectorVM>(), "Id", "Name");
                    ViewBag.FinancialYearId = new SelectList(nursaryRaisingYearList ?? new List<FinancialYearVM>(), "Id", "Name");
                    ViewBag.ProjectTypeId = new SelectList(projectTypeList ?? new List<ProjectTypeVM>(), "Id", "Name");
                    ViewBag.NurseryTypeId = new SelectList(nurseryTypeList ?? new List<NurseryTypeVM>(), "Id", "Name");

                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;

                    var nursaryImagefile = HttpContext.Request.Form.Files.GetFile("NursaryImageFile");
                    var nursaryLayoutfile = HttpContext.Request.Form.Files.GetFile("NursaryLayout");
                    var nursaryJournalfile = HttpContext.Request.Form.Files.GetFile("NursaryJournal");
                    var inspectionDetailsFiles = HttpContext.Request.Form.Files.GetFiles("InspectionFiles");
                    var costInformationFiles = HttpContext.Request.Form.Files.GetFiles("CostInformationFiles");

                    if (SaveFiles(inspectionDetailsFiles, costInformationFiles, nursaryImagefile, nursaryJournalfile, nursaryLayoutfile, ref entity, FileType.Image, out var imageFileError) == false)
                    {
                        return Json(
                            new { Success = false, Message = imageFileError },
                            SerializerOption.Default);
                    }

                    (ExecutionState executionState, NurseryInformationVM entity, string message) returnResponse = _nurseryInformationService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(new { Success = false, Message = returnResponse.message, RedirectUrl = string.Empty }, SerializerOption.Default);

                    }
                    else
                    {
                        var urlRedirect = Url.Action(nameof(this.Index), "NurseryInformation");

                        HttpContext.Session.SetString("Message", "Nursery  created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                        return Json(
                            new { Success = true, Message = "Nursery  created successfully", RedirectUrl = urlRedirect },
                            SerializerOption.Default);

                    }
                }
                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                   new { Success = false, Message = "Unknown error occured." },
                   SerializerOption.Default);

            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, NurseryInformationVM entity, string message) returnResponse = _nurseryInformationService.GetById(id);

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
                returnResponse.entity.ForestFcvVcfId,
                returnResponse.entity.DivisionId,
                returnResponse.entity.DistrictId,
                returnResponse.entity.UpazillaId,
                returnResponse.entity.UnionId
               );


            List<NurseryRaisingSectorVM>? nurseryRaisingSectorList = _nurseryRaisingSectorService.List().entity?.OrderBy(x => x.Name).ToList();
            List<FinancialYearVM>? nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();

            List<ProjectTypeVM>? projectTypeList = _projectTypeService.List().entity?.OrderBy(x => x.Name).ToList();
            List<NurseryTypeVM>? nurseryTypeList = _nurseryTypeService.List().entity?.OrderBy(x => x.Name).ToList();

            List<SocialForestryDesignationVM>? socialForestryDesignationList = _socialForestryDesignationService.List().entity?.OrderBy(x => x.Name).ToList();

            ViewBag.NurseryRaisingSectorId = nurseryRaisingSectorList ?? new List<NurseryRaisingSectorVM>();
            ViewBag.FinancialYearId = nursaryRaisingYearList ?? new List<FinancialYearVM>();
            ViewBag.ProjectTypeId = projectTypeList ?? new List<ProjectTypeVM>();
            ViewBag.NurseryTypeId = nurseryTypeList ?? new List<NurseryTypeVM>();

            ///////////////////////////////////////////////////////////////////////////

            //ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();
            //ViewBag.ForestDivisionId = _ForestDivisionService.ListByForestCircle(returnResponse.entity.ForestCircleId).entity ?? new List<ForestDivisionVM>();
            //ViewBag.ForestRangeId = _ForestRangeService.ListByForestDivision(returnResponse.entity.ForestDivisionId).entity ?? new List<ForestRangeVM>();
            //ViewBag.ForestBeatId = _ForestBeatService.ListByForestRange(returnResponse.entity.ForestRangeId).entity ?? new List<ForestBeatVM>();

            //ViewBag.DivisionId = new SelectList(_DivisionService.List().entity ?? new List<DivisionVM>(), "Id", "Name", returnResponse.entity.DivisionId);
            //ViewBag.DistrictId = new SelectList(_DistrictService.ListByDivision(returnResponse.entity.DivisionId).entity ?? new List<DistrictVM>(), "Id", "Name", returnResponse.entity.DistrictId);
            //ViewBag.UpazillaId = new SelectList(_UpazillaService.ListByDistrict(returnResponse.entity.DistrictId).entity ?? new List<UpazillaVM>(), "Id", "Name", returnResponse.entity.UpazillaId);
            //ViewBag.UnionId = new SelectList(_UnionService.ListByUpazilla(returnResponse.entity.UpazillaId).entity ?? new List<UnionVM>(), "Id", "Name", returnResponse.entity.UnionId);

            ///////////////////////////////////////////////////////////////////////////
            ViewBag.DesignationId = socialForestryDesignationList ?? new List<SocialForestryDesignationVM>();
            ViewBag.SocialForestryDesignationId = socialForestryDesignationList ?? new List<SocialForestryDesignationVM>();

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, NurseryInformationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "NurseryInformation");

                    }

                    var nurseryRaisingSectorList = _nurseryRaisingSectorService.List().entity?.OrderBy(x => x.Name).ToList();
                    var nursaryRaisingYearList = _financialYearService.List().entity?.OrderBy(x => x.Name).ToList();

                    var projectTypeList = _projectTypeService.List().entity?.OrderBy(x => x.Name).ToList();
                    var nurseryTypeList = _nurseryTypeService.List().entity?.OrderBy(x => x.Name).ToList();

                    ViewBag.NurseryRaisingSectorId = new SelectList(nurseryRaisingSectorList ?? new List<NurseryRaisingSectorVM>(), "Id", "Name");
                    ViewBag.FinancialYearId = new SelectList(nursaryRaisingYearList ?? new List<FinancialYearVM>(), "Id", "Name");
                    ViewBag.ProjectTypeId = new SelectList(projectTypeList ?? new List<ProjectTypeVM>(), "Id", "Name");
                    ViewBag.NurseryTypeId = new SelectList(nurseryTypeList ?? new List<NurseryTypeVM>(), "Id", "Name");

                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, NurseryInformationVM entity, string message) returnResponse = _nurseryInformationService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());


                        return Json(
                            new { Success = false, Message = returnResponse.message, RedirectUrl = string.Empty },
                            SerializerOption.Default);

                    }
                    else
                    {
                        var urlRedirect = Url.Action(nameof(this.Index), "NurseryInformation");

                        HttpContext.Session.SetString("Message", "Nursery  updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                        return Json(
                            new { Success = true, Message = "Nursery  updated successfully", RedirectUrl = urlRedirect },
                            SerializerOption.Default);

                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                    SerializerOption.Default);

            }
            catch
            {
                return Json(
                   new { Success = false, Message = "Unknown error occured." },
                   SerializerOption.Default);

            }
        }

        public JsonResult Delete(int id)
        {
            //(ExecutionState executionState, string message) CheckDataExistOrNot = _nurseryInformationService.DoesExist(id);
            //string message = "Failed, You can't delete this item.";

            //if (CheckDataExistOrNot.executionState.ToString() != "Success")
            //{
            //    return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            //}

            var returnResponse = _nurseryInformationService.SoftDelete(id);
            if (returnResponse.isDeleted)
            {
                returnResponse.message = "Item deleted successfully.";
            }
            else
            {
                returnResponse.message = "Failed to delete this item.";
            }

            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
        }


        private bool SaveFiles(IReadOnlyList<IFormFile> inspectionDetailsFiles, IReadOnlyList<IFormFile> costInformationFiles, IFormFile nursaryImagefile, IFormFile nursaryJournalfile, IFormFile nursaryLayoutfile, ref NurseryInformationVM entity, FileType fileType, out string error)
        {
            // Save Inspection Files
            if (inspectionDetailsFiles != null)
            {
                for (var file = 0; file < inspectionDetailsFiles.Count; file++)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(inspectionDetailsFiles[file], null, "NursaryInformation", out var errorMessage);
                    if (isSaved == false)
                    {
                        error = errorMessage;
                        return false;
                    }
                    entity.InspectionDetailsMap[file].InspectionDetails.InspectionFile = fileUrl;
                }

            }
            if (costInformationFiles != null)
            {

                // Save Cost Files
                for (var file = 0; file < costInformationFiles.Count; file++)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(costInformationFiles[file], null, "NursaryInformation", out var errorMessage);
                    if (isSaved == false)
                    {
                        error = errorMessage;
                        return false;
                    }
                    var entityFile = new NurseryCostInformationFileVM
                    {
                        FileType = fileType,
                        FileUrl = fileUrl,
                    };
                    entity.CostInformations[file].CostInformationFiles.Add(entityFile);
                }

            }
            // save Nursary files
            if (nursaryImagefile != null)
            {

                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(nursaryImagefile, null, "NursaryInformation", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }
                entity.NursaryImageFilePath = fileUrl;
            }
            if (nursaryJournalfile != null)
            {

                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(nursaryJournalfile, null, "NursaryInformation", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }
                entity.NursaryJournalFilePath = fileUrl;
            }
            if (nursaryLayoutfile != null)
            {

                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(nursaryLayoutfile, null, "NursaryInformation", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }
                entity.NursaryLayoutFilePath = fileUrl;
            }

            error = string.Empty;
            return true;
        }

        public JsonResult GetDesignation()
        {
            List<SocialForestryDesignationVM>? designations = _socialForestryDesignationService.List().entity?.OrderBy(x => x.Name).ToList(); ;

            if (designations.Count > 0 && designations != null)
            {
                return Json(new { Success = true, Message = "Success", RedirectUrl = string.Empty, data = designations }, SerializerOption.Default);
            }
            else
            {
                return Json(new { Success = false, Message = "Fail", RedirectUrl = string.Empty, data = new List<SocialForestryDesignationVM>() }, SerializerOption.Default);
            }


        }

        public JsonResult GetNurseryInformation(long id)
        {
            (ExecutionState executionState, NurseryInformationVM entity, string message) returnResponse = _nurseryInformationService.GetById(id);

            if (returnResponse.entity != null)
            {
                return Json(new { Success = true, Message = "Success", RedirectUrl = string.Empty, data = returnResponse.entity }, SerializerOption.Default);
            }
            else
            {
                return Json(new { Success = false, Message = "Fail", RedirectUrl = string.Empty, data = new NurseryInformationVM() }, SerializerOption.Default);
            }
        }

        //DeleteRaisedSeedlingInformationById
        public JsonResult DeleteRaisedSeedlingInformationById(long id)
        {
            var returnResponse = _nurseryRaisedSeedlingInformationService.SoftDelete(id);
            if (returnResponse.isDeleted)
            {
                returnResponse.message = "Item deleted successfully.";
            }
            else
            {
                returnResponse.message = "Failed to delete this item.";
            }
            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
        }


        //DeleteCostInformationById
        public JsonResult DeleteCostInformationById(long id)
        {
            var returnResponse = _costInformationService.SoftDelete(id);
            if (returnResponse.isDeleted)
            {
                returnResponse.message = "Item deleted successfully.";
            }
            else
            {
                returnResponse.message = "Failed to delete this item.";
            }
            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
        }




    }
}