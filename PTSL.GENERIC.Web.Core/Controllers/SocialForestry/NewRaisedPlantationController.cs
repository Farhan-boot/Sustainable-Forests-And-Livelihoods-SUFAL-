using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry;

[SessionAuthorize]
public class NewRaisedPlantationController : Controller
{
    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;
    private readonly IZoneOrAreaService _ZoneOrAreaService;

    private readonly IPlantationFileService _PlantationFileService;

    private readonly INewRaisedPlantationService _newRaisedPlantationService;
    private readonly FileHelper _fileHelper;

    public NewRaisedPlantationController(IWebHostEnvironment webHostEnvironment, HttpHelper httpHelper)
    {
        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);
        _ZoneOrAreaService = new ZoneOrAreaService(httpHelper);
        _PlantationFileService = new PlantationFileService(httpHelper);

        _fileHelper = new FileHelper(webHostEnvironment);
        _newRaisedPlantationService = new NewRaisedPlantationService(httpHelper);
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

        ViewBag.ZoneOrAreaId = new SelectList(_ZoneOrAreaService.List().entity ?? new List<ZoneOrAreaVM>(), "Id", "Name");

        var filter = AuthLocationHelper.GetFilterFromSession<NewRaisedPlantationFilter>(HttpContext, 50);
        var (_, entity, _) = _newRaisedPlantationService.ListByFilter(filter);

        return View(entity ?? new List<NewRaisedPlantationVM>());
    }

    [HttpPost]
    public ActionResult IndexFilter(NewRaisedPlantationFilter filter)
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

        ViewBag.ZoneOrAreaId = new SelectList(_ZoneOrAreaService.List().entity ?? new List<ZoneOrAreaVM>(), "Id", "Name", filter.ZoneOrAreaId);

        var (_, entity, _) = _newRaisedPlantationService.ListByFilter(filter);

        return View("Index", entity ?? new List<NewRaisedPlantationVM>());
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

        ViewBag.ZoneOrAreaId = new SelectList(_ZoneOrAreaService.List().entity ?? new List<ZoneOrAreaVM>(), "Id", "Name");

        return View(new NewRaisedPlantationVM());
    }

    [HttpPost]
    public ActionResult Create(NewRaisedPlantationVM entity)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                    SerializerOption.Default);
            }

            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            // Inspection details
            foreach (var item in entity.InspectionDetailsMap ?? Enumerable.Empty<InspectionDetailsMapVM>())
            {
                var file = HttpContext.Request.Form.Files.GetFile($"InspectionDetailsMap[{item.InspectionDetails?.Index ?? -1}][InspectionDetails][InspectionFormFile]");
                if (item.InspectionDetails is null) continue;

                item.InspectionDetails.InspectionFormFile = file;

                if (file is not null)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(file, null, "NewRaisedPlantation", out var errorMessage);
                    if (isSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.InspectionDetails.InspectionFile = fileUrl;
                }
            }

            // Cost information files
            foreach (var item in entity.CostInformation ?? Enumerable.Empty<CostInformationVM>())
            {
                var file = HttpContext.Request.Form.Files.GetFiles($"CostInformation[{item.Index}][FormFiles]");
                item.FormFiles = file;

                foreach (var f in file)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(f, null, "NewRaisedPlantationCostInfo", out var errorMessage);
                    if (isSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.CostInformationFiles ??= new List<CostInformationFileVM>();
                    item.CostInformationFiles.Add(new CostInformationFileVM
                    {
                        FileType = FileHelper.GetFileType(f),
                        FileUrl = fileUrl,
                    });
                }
            }

            // Labor files
            foreach (var item in entity.LaborInformation ?? Enumerable.Empty<LaborInformationVM>())
            {
                var file = HttpContext.Request.Form.Files.GetFiles($"LaborInformation[{item.Index}][FormFiles]");
                item.FormFiles = file;

                foreach (var f in file)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(f, null, "NewRaisedPlantationLabor", out var errorMessage);
                    if (isSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.LaborInformationFiles ??= new List<LaborInformationFileVM>();
                    item.LaborInformationFiles.Add(new LaborInformationFileVM
                    {
                        FileType = FileHelper.GetFileType(f),
                        FileUrl = fileUrl,
                    });
                }
            }

            // Plantation damage
            foreach (var item in entity.PlantationDamageInformation ?? Enumerable.Empty<PlantationDamageInformationVM>())
            {
                var damageFormFile = HttpContext.Request.Form.Files.GetFile($"PlantationDamageInformation[{item.Index}][DamageFormFile]");
                var inspectionFormFile = HttpContext.Request.Form.Files.GetFile($"PlantationDamageInformation[{item.Index}][InspectionFormFile]");

                item.DamageFormFile = damageFormFile;
                item.InspectionFormFile = inspectionFormFile;

                if (damageFormFile is not null)
                {
                    var (disSaved, dfileUrl, _) = _fileHelper.SaveFile(damageFormFile, null, "NewRaisedPlantation", out var errorMessage);
                    if (disSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.DamageUrl = dfileUrl;
                }

                if (inspectionFormFile is not null)
                {
                    var (iisSaved, ifileUrl, _) = _fileHelper.SaveFile(inspectionFormFile, null, "NewRaisedPlantation", out var ierrorMessage);
                    if (iisSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = ierrorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.InspectionReportUrl = ifileUrl;
                }
            }

            // PBSA
            foreach (var item in entity.PlantationSocialForestryBeneficiaryMaps ?? Enumerable.Empty<PlantationSocialForestryBeneficiaryMapVM>())
            {
                var file = HttpContext.Request.Form.Files.GetFile($"{item.PBSAGroupId}_AgreementFile");

                if (file is not null)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(file, null, "NewRaisedPlantationPBSA", out var errorMessage);
                    if (isSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.AgreementUploadFileUrl = fileUrl;
                }
            }

            // PBSA Other files
            var socialForestryManagementCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("SocialForestryManagementCommitteeFormedFile");
            var fundManagementSubCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("FundManagementSubCommitteeFormedFile");
            var advisoryCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("AdvisoryCommitteeFormedFile");
            var plantationJournalUploadUrlFile = HttpContext.Request.Form.Files.GetFile("PlantationJournalUploadUrlFile");
            var monitoringReportUrlFile = HttpContext.Request.Form.Files.GetFile("MonitoringReportUrlFile");
            if (socialForestryManagementCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(socialForestryManagementCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.SocialForestryManagementCommitteeFormedFile = fileUrl;
            }
            if (fundManagementSubCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(fundManagementSubCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.FundManagementSubCommitteeFormedFile = fileUrl;
            }
            if (advisoryCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(advisoryCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.AdvisoryCommitteeFormedFile = fileUrl;
            }
            if (plantationJournalUploadUrlFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(plantationJournalUploadUrlFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.PlantationJournalUploadUrl = fileUrl;
            }
            if (monitoringReportUrlFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(monitoringReportUrlFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.MonitoringReportUrl = fileUrl;
            }

            // Image or document
            var files = HttpContext.Request.Form.Files.GetFiles("PlantationImageOrDocument");
            if (SaveNewRaisedFiles(files, ref entity, out var imageFileError) == false)
            {
                return Json(
                    new { Success = true, Message = imageFileError },
                    SerializerOption.Default);
            }

            var nurseryFile = HttpContext.Request.Form.Files.GetFile("NurseryImage");
            var plantationFile = HttpContext.Request.Form.Files.GetFile("PlantationImage");
            if (SavePlantationNurseryFiles(nurseryFile, plantationFile, ref entity, out var nurseryOrPlantationImageError) == false)
            {
                return Json(
                    new { Success = true, Message = nurseryOrPlantationImageError },
                    SerializerOption.Default);
            }

            var returnResponse = _newRaisedPlantationService.Create(entity);

            if (returnResponse.executionState == ExecutionState.Created)
            {
                var urlRedirect = Url.Action("Index", "NewRaisedPlantation");

                HttpContext.Session.SetString("Message", "New raised plantation has been created successfully.");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                return Json(
                    new { Success = true, Message = "New raised plantation has been created successfully.", RedirectUrl = urlRedirect },
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

    public ActionResult Details(long id)
    {
        if (id == default)
        {
            return NotFound();
        }

        (ExecutionState executionState, NewRaisedPlantationVM entity, string message) returnResponse = _newRaisedPlantationService.GetDetails(id);
        return View(returnResponse.entity);
    }

    public ActionResult Edit(long id)
    {
        if (id == default)
        {
            return NotFound();
        }

        var newRaisedPlantation = _newRaisedPlantationService.GetById(id).entity ?? new NewRaisedPlantationVM();

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
            newRaisedPlantation.ForestCircleId,
            newRaisedPlantation.ForestDivisionId,
            newRaisedPlantation.ForestRangeId,
            newRaisedPlantation.ForestBeatId,
            0,
            newRaisedPlantation.DivisionId,
            newRaisedPlantation.DistrictId,
            newRaisedPlantation.UpazillaId,
            newRaisedPlantation.UnionId
        );

        ViewBag.ZoneOrAreaId = new SelectList(_ZoneOrAreaService.List().entity ?? new List<ZoneOrAreaVM>(), "Id", "Name", newRaisedPlantation.ZoneOrAreaId);

        return View(newRaisedPlantation);
    }

    [HttpPost]
    public ActionResult Edit(NewRaisedPlantationVM entity)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                    SerializerOption.Default);
            }

            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;

            // Inspection details
            foreach (var item in entity.InspectionDetailsMap ?? Enumerable.Empty<InspectionDetailsMapVM>())
            {
                var file = HttpContext.Request.Form.Files.GetFile($"InspectionDetailsMap[{item.InspectionDetails?.Index ?? -1}][InspectionDetails][InspectionFormFile]");
                if (item.InspectionDetails is null) continue;

                item.InspectionDetails.InspectionFormFile = file;

                if (file is not null)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(file, null, "NewRaisedPlantation", out var errorMessage);
                    if (isSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.InspectionDetails.InspectionFile = fileUrl;
                }
            }

            // Cost information files
            foreach (var item in entity.CostInformation ?? Enumerable.Empty<CostInformationVM>())
            {
                var file = HttpContext.Request.Form.Files.GetFiles($"CostInformation[{item.Index}][FormFiles]");
                item.FormFiles = file;

                foreach (var f in file)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(f, null, "NewRaisedPlantationCostInfo", out var errorMessage);
                    if (isSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.CostInformationFiles ??= new List<CostInformationFileVM>();
                    item.CostInformationFiles.Add(new CostInformationFileVM
                    {
                        FileType = FileHelper.GetFileType(f),
                        FileUrl = fileUrl,
                    });
                }
            }

            // Labor files
            foreach (var item in entity.LaborInformation ?? Enumerable.Empty<LaborInformationVM>())
            {
                var file = HttpContext.Request.Form.Files.GetFiles($"LaborInformation[{item.Index}][FormFiles]");
                item.FormFiles = file;

                foreach (var f in file)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(f, null, "NewRaisedPlantationLabor", out var errorMessage);
                    if (isSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.LaborInformationFiles ??= new List<LaborInformationFileVM>();
                    item.LaborInformationFiles.Add(new LaborInformationFileVM
                    {
                        FileType = FileHelper.GetFileType(f),
                        FileUrl = fileUrl,
                    });
                }
            }

            // Plantation damage
            foreach (var item in entity.PlantationDamageInformation ?? Enumerable.Empty<PlantationDamageInformationVM>())
            {
                var damageFormFile = HttpContext.Request.Form.Files.GetFile($"PlantationDamageInformation[{item.Index}][DamageFormFile]");
                var inspectionFormFile = HttpContext.Request.Form.Files.GetFile($"PlantationDamageInformation[{item.Index}][InspectionFormFile]");

                item.DamageFormFile = damageFormFile;
                item.InspectionFormFile = inspectionFormFile;

                if (damageFormFile is not null)
                {
                    var (disSaved, dfileUrl, _) = _fileHelper.SaveFile(damageFormFile, null, "NewRaisedPlantation", out var errorMessage);
                    if (disSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.DamageUrl = dfileUrl;
                }

                if (inspectionFormFile is not null)
                {
                    var (iisSaved, ifileUrl, _) = _fileHelper.SaveFile(inspectionFormFile, null, "NewRaisedPlantation", out var ierrorMessage);
                    if (iisSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = ierrorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.InspectionReportUrl = ifileUrl;
                }
            }

            // PBSA
            foreach (var item in entity.PlantationSocialForestryBeneficiaryMaps ?? Enumerable.Empty<PlantationSocialForestryBeneficiaryMapVM>())
            {
                var file = HttpContext.Request.Form.Files.GetFile($"{item.PBSAGroupId}_AgreementFile");

                if (file is not null)
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(file, null, "NewRaisedPlantationPBSA", out var errorMessage);
                    if (isSaved == false)
                    {
                        return Json(
                            new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                            SerializerOption.Default);
                    }

                    item.AgreementUploadFileUrl = fileUrl;
                }
            }

            // PBSA Other files
            var socialForestryManagementCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("SocialForestryManagementCommitteeFormedFile");
            var fundManagementSubCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("FundManagementSubCommitteeFormedFile");
            var advisoryCommitteeFormedFile = HttpContext.Request.Form.Files.GetFile("AdvisoryCommitteeFormedFile");
            var plantationJournalUploadUrlFile = HttpContext.Request.Form.Files.GetFile("PlantationJournalUploadUrlFile");
            var monitoringReportUrlFile = HttpContext.Request.Form.Files.GetFile("MonitoringReportUrlFile");
            if (socialForestryManagementCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(socialForestryManagementCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.SocialForestryManagementCommitteeFormedFile = fileUrl;
            }
            if (fundManagementSubCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(fundManagementSubCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.FundManagementSubCommitteeFormedFile = fileUrl;
            }
            if (advisoryCommitteeFormedFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(advisoryCommitteeFormedFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.AdvisoryCommitteeFormedFile = fileUrl;
            }
            if (plantationJournalUploadUrlFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(plantationJournalUploadUrlFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.PlantationJournalUploadUrl = fileUrl;
            }
            if (monitoringReportUrlFile is not null)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(monitoringReportUrlFile, null, "NewRaisedPlantation", out var errorMessage);
                if (isSaved == false)
                {
                    return Json(
                        new { Success = false, Message = errorMessage, RedirectUrl = string.Empty },
                        SerializerOption.Default);
                }
                entity.MonitoringReportUrl = fileUrl;
            }

            // Image or document
            var files = HttpContext.Request.Form.Files.GetFiles("PlantationImageOrDocument");
            if (SaveNewRaisedFiles(files, ref entity, out var imageFileError) == false)
            {
                return Json(
                    new { Success = true, Message = imageFileError },
                    SerializerOption.Default);
            }

            var nurseryFile = HttpContext.Request.Form.Files.GetFile("NurseryImage");
            var plantationFile = HttpContext.Request.Form.Files.GetFile("PlantationImage");
            if (SavePlantationNurseryFiles(nurseryFile, plantationFile, ref entity, out var nurseryOrPlantationImageError) == false)
            {
                return Json(
                    new { Success = true, Message = nurseryOrPlantationImageError },
                    SerializerOption.Default);
            }

            var returnResponse = _newRaisedPlantationService.Create(entity);

            if (returnResponse.executionState == ExecutionState.Created)
            {
                var urlRedirect = Url.Action("Index", "NewRaisedPlantation");

                HttpContext.Session.SetString("Message", "New raised plantation has been created successfully.");
                HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                return Json(
                    new { Success = true, Message = "New raised plantation has been created successfully.", RedirectUrl = urlRedirect },
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

    public ActionResult DetailsForEdit(long id)
    {
        if (id == default)
        {
            return NotFound();
        }

        var returnResponse = _newRaisedPlantationService.GetDetailsForEdit(id).entity ?? new NewRaisedPlantationVM();
        return Json(new { Data = returnResponse }, SerializerOption.Default);
    }

    private bool SavePlantationNurseryFiles(IFormFile? nurseryFile, IFormFile? plantationFile, ref NewRaisedPlantationVM entity, out string error)
    {
        if (nurseryFile is not null)
        {
            var (isSaved, fileUrl, _) = _fileHelper.SaveFile(nurseryFile, null, "NewRaisedPlantation", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            entity.NurseryImage = fileUrl;
        }

        if (plantationFile is not null)
        {
            var (isSaved, fileUrl, _) = _fileHelper.SaveFile(plantationFile, null, "NewRaisedPlantation", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            entity.PlantationImage = fileUrl;
        }

        error = string.Empty;
        return true;
    }

    private bool SaveNewRaisedFiles(IReadOnlyList<IFormFile> files, ref NewRaisedPlantationVM entity, out string error)
    {
        foreach (var file in files)
        {
            var (isSaved, fileUrl, _) = _fileHelper.SaveFile(file, null, "NewRaisedPlantation", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }

            var entityFile = new PlantationFileVM
            {
                FileType = FileHelper.GetFileType(file),
                FileUrl = fileUrl,
            };

            if (entity is not null && entity.PlantationFiles is null)
            {
                entity.PlantationFiles = new List<PlantationFileVM>();
            }
            entity?.PlantationFiles?.Add(entityFile);
        }

        error = string.Empty;
        return true;
    }

    public JsonResult GetById(int id)
    {
        var returnResponse = _newRaisedPlantationService.GetDetailsForEdit(id).entity ?? new NewRaisedPlantationVM();
        return Json(new { Data = returnResponse }, SerializerOption.Default);
    }

    public JsonResult Delete(int id)
    {
        var result = _newRaisedPlantationService.SoftDelete(id);
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

    public JsonResult PlantationPlantDelete(int id)
    {
        var result = _PlantationFileService.SoftDelete(id);
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

    public JsonResult GetNextRotationNo(long newRaisedId)
    {
        var returnResponse = _newRaisedPlantationService.GetNextRotationNo(newRaisedId).entity;
        return Json(new { Data = returnResponse }, SerializerOption.Default);
    }
}
